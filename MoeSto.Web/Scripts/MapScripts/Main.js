var myMap;

// Дождёмся загрузки API и готовности DOM.
ymaps.ready(init);

function init() {
    function getBalloonContentBody(data) {
        return '<div class="companyDetailsWrapper"><div class="companyDetailsImg imgWrapper"><p class="companyDetailsName">' +
            (data.Name != null ? data.Name : "") +
            '</p></div><div class="companyDetailsCommon"><p>' +
            (data.Address != null ? data.Address : "") + '</p><p>' +
            (data.Phones != null ? data.Phones : "") + '</p><a class="companyDetailsEmail" href="mailto:' +
            (data.Email != null ? data.Email : "") + '">' +
            (data.Email != null ? data.Email : "") + '</a></div></div>';

    }

    function isClusterized(features) {
        for (var i = 0; i < features.length; i++) {
            var latitude = features[i].geometry.coordinates[0];
            var longitude = features[i].geometry.coordinates[1];
            for (var j = 1; j < features.length; j++) {
                if (latitude != features[j].geometry.coordinates[0] && longitude != features[j].geometry.coordinates[1]) {
                    return true;
                }
            }
             return false;
        }
        return false;
    }

    ymaps.geolocation.get().then(function (res) {
        var mapContainer = $('#map'),

            //get map box coordinates
            bounds = res.geoObjects.get(0).properties.get('boundedBy'),
            // Calculating the viewport for the user's current location.
            mapState = ymaps.util.bounds.getCenterAndZoom(
                bounds,
                [mapContainer.width(), mapContainer.height()]
            );
        createMap(mapState);
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
            clusterBalloonItemContentLayout: customItemContentLayout,
        });
        loadingObjectManager.objects.events.add(['click'], function(e){
            var objectId = e.get('objectId'),
                object = loadingObjectManager.objects.getById(objectId);
           
                var mapController = new MapController("map/GetCompanyDetails");
                mapController.getCompanyDetailsById(
                    objectId,
                    function(data) {
                        object.properties = {
                            //balloonContentHeader: getBalloonContentHeader(data),
                            balloonContentBody: getBalloonContentBody(data),
                            ballonContentFooter: getBalloonContentFooter(data)
                        };
                        loadingObjectManager.objects.balloon.open(objectId);
                       
                    },
                    function() {}
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
            if (!isClusterized(cluster.features)) {
                
                var mapController = new MapController("map/GetCompanyDetailsByCoordinates");
                mapController.getCompanyDetailsByCoordinates(
                    clusterCoords,
                    function(data) {

                        var clusterId = e.get('objectId');
                        var cluster = loadingObjectManager.clusters.getById(clusterId);

                        if (cluster && cluster.features) {
                            var clusterFeatures = cluster.features;
                            for (var i = 0; i < clusterFeatures.length; i++) {
                                clusterFeatures[i].properties = {
                                    balloonContentHeader: data[i].Name,
                                    balloonContentBody: '<p>' + data[i].Address + ' ' + data[i].Phones + '</p>'
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
                    function() {}
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
    function createMap(state) {
        myMap = new ymaps.Map('map', state);
    }
   
     
    
}

