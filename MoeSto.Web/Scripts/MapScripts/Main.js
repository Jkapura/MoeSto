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
    function getBalloonContentFooter(data) {
        return '<p>'+  '</p>' ;
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
        var loadingObjectManager = new ymaps.LoadingObjectManager('Map/tile?bbox=%b', {
            // Enabling clusterization.
            clusterize: true,
            splitRequests: true,
            // Cluster options are set with the 'cluster' prefix.
            clusterHasBalloon: false,
            // Object options are set with the geoObject prefix.
            geoObjectOpenBalloonOnClick: false,
            clusterOpenBalloonOnClick: false,
            
            
           
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
            
                var mapController = new MapController("map/GetCompanyDetailsByCoordinates");
                mapController.getCompanyDetailsByCoordinates(
                    clusterCoords,
                    function (data) {
                        
                        var clusterId = e.get('objectId');
                        var cluster = loadingObjectManager.clusters.getById(clusterId);
                        var clusterFeatures = cluster.features;
                        for (var j = 0; j < clusterFeatures.length; j++) {
                            clusterFeatures[0].properties = {
                                //balloonContentHeader: getBalloonContentHeader(data),
                                balloonContentBody: getBalloonContentBody(data[j]) 
                                
                            };
                        }
                        //loadingObjectManager.clusters.balloon.open(cluster.id);
                        loadingObjectManager.objects.balloon.open(clusterFeatures[0].id);
                    },
                    function() {}
                );
            
        });
         

        function hasBalloonData(objectId) {
            return loadingObjectManager.objects.getById(objectId).properties.balloonContent;
        }
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

