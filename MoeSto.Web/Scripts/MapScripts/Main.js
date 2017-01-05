var myMap;

// Дождёмся загрузки API и готовности DOM.
ymaps.ready(init);

function init() {

   

    function getBalloonContentBody(data) {
        //return '<div class="companyDetailsImg"><span class="companyDetailsName">'+ (data.Name!=null?data.Name:"") +'</span></div><p class="companyDetailsCommon">' + (data.Address != null ? data.Address : "") + '</p><p>' + (data.Phones != null ? data.Phones : "") + '</p><a class="companyDetailsEmail" href="mailto:' + (data.Email != null ? data.Email : "") + '">' + (data.Email != null ? data.Email : "") + '</a>';
        return '<div class="companyDetailsWrapper"><div class="companyDetailsImg"><p class="companyDetailsName">' +
            (data.Name != null ? data.Name : "") +
            '</p></div><p class="companyDetailsCommon">' +
            (data.Address != null ? data.Address : "") + '</p><p>' +
            (data.Phones != null ? data.Phones : "") + '</p><a class="companyDetailsEmail" href="mailto:' + (data.Email != null ? data.Email : "") + '">' +
            (data.Email != null ? data.Email : "") + '</a></div>';

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

         

        //loadingObjectManager.events.add('click', function () {

           
        //    if (myMap.balloon.isOpen()) {
        //        balloon.setData({ content: Math.random() });
        //    } else {
        //        balloon = myMap.balloon.open(myMap.getCenter(), Math.random());
        //    }
        //});

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

