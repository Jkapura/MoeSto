var myMap;

// Дождёмся загрузки API и готовности DOM.
ymaps.ready(init);

function init() {
    ymaps.geolocation.get().then(function (res) {
        var mapContainer = $('#map'),
            //get map box coordinates
            bounds = res.geoObjects.get(0).properties.get('boundedBy'),
            // Calculating the viewport for the user's current location.
            mapState = ymaps.util.bounds.getCenterAndZoom(
                bounds,
                [mapContainer.width(), mapContainer.height()]
            );
        functions.mapFunctions.createMap(mapState);
        //Layout for carousel
        var customItemContentLayout = ymaps.templateLayoutFactory.createClass(
            // The "raw" flag means that data is inserted "as is" without escaping HTML.
            //'<h2 class=ballon_header>{{ properties.balloonContentHeader|raw }}</h2>' +
            '<div class=ballon_body><div class=ballon_header>{{properties.balloonContentHeader}}</div>{{ properties.balloonContentBody|raw }}</div>' //+
            //'<div class=ballon_footer>{{ properties.balloonContentFooter|raw }}</div>'
        );
        var loadingObjectManager = new ymaps.LoadingObjectManager('Map/tile?bbox=%b', {
            splitRequests: true,
            // Enabling clusterization.
            clusterize: true,
            //options for GeoObjects
            geoObjectOpenBalloonOnClick: false,
            geoObjectHideIconOnBalloonOpen: false,
            //options foe clusters
            clusterHasBalloon: true,
            clusterDisableClickZoom: false,
            clusterOpenBalloonOnClick: false,
            clusterHideIconOnBalloonOpen: false,
            clusterBalloonContentLayout: 'cluster#balloonCarousel',
            clusterBalloonItemContentLayout: customItemContentLayout

        });

        $('#clearFilterButton').click(function () {

            loadingObjectManager.setFilter(function (obj) {
                return undefined;
            });
        });
        $('.slt_formSaleCity').change(function () {
            loadingObjectManager.setFilter(function () {

                return undefined;
                
            });
            var city = $('.slt_formSaleCity').val();
            
            loadingObjectManager.setFilter(function (obj) {
                return obj.properties.city == city;
            });
            
            var myGeocoder = ymaps.geocode(city);
            myGeocoder.then(
            function (res) {
                var coords = res.geoObjects.get(0).geometry.getCoordinates();
                myMap.setCenter(coords);

            });
        });

        //event that happens on placemark click
        loadingObjectManager.objects.events.add(['click'], function (e) {

            var objectId = e.get('objectId'),
                object = loadingObjectManager.objects.getById(objectId);
            var mapController = new MapController("map/GetCompanyDetails");
            mapController.getCompanyDetailsById(
                objectId,
                function (data) {
                    object.properties = {
                        //balloonContentHeader: getBalloonContentHeader(data),
                        balloonContentBody: functions.mapFunctions.getBalloonContentBody(objectId,data),
                        //ballonContentFooter: getBalloonContentFooter(data)
                        city: data.City
                    };
                    loadingObjectManager.objects.balloon.open(objectId);
                },
                function () { }
            );

        });


        //event that happens on cluster click
        loadingObjectManager.clusters.events.add(['click'], function (e) {
            //get cluster id
            var clusterId = e.get('objectId'),
                //get cluster object
                cluster = loadingObjectManager.clusters.getById(clusterId),
                //get cluster coordinates (?)
                clusterCoords = cluster.features[0].geometry.coordinates;
            if (!functions.mapFunctions.isClusterized(cluster.features)) {

                var mapController = new MapController("map/GetCompanyDetailsByCoordinates");
                mapController.getCompanyDetailsByCoordinates(
                    clusterCoords,
                    function (data) {
                        var clusterId = e.get('objectId');
                        var cluster = loadingObjectManager.clusters.getById(clusterId);
                        if (cluster && cluster.features) {
                            var clusterFeatures = cluster.features;
                            for (var i = 0; i < clusterFeatures.length; i++) {
                                clusterFeatures[i].properties = {
                                    balloonContentHeader: data[i].Name,
                                    balloonContentBody: '<p>' + data[i].Address + ' ' + data[i].Phones + '</p>',
                                    balloonContentFooter: '<p>' + data[i].Address + ' ' + data[i].Phones + '</p>'
                                }
                            }
                            if (myMap.getZoom() == 19) {
                                loadingObjectManager.clusters.balloon.open(clusterId);
                            } else {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    },
                    function () { }
                );
            }
        });
        


        myMap.geoObjects.add(loadingObjectManager);
        
    }, function (e) {
        // If the location cannot be obtained, we just create a map.
        createMap({
            center: [55.751574, 37.573856],
            zoom: 5
        });
    });
    



}


