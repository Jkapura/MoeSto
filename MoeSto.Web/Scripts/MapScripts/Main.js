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
        createMap(mapState);
        var loadingObjectManager = new ymaps.LoadingObjectManager('Map/tile?bbox=%b', {
            // Enabling clusterization.
            clusterize: true,
            splitRequests: true,
            // Cluster options are set with the 'cluster' prefix.
            clusterHasBalloon: false,
            // Object options are set with the geoObject prefix.
            geoObjectOpenBalloonOnClick: false
        });
        myMap.geoObjects.add(loadingObjectManager);
        
        //var mapController = new MapController('MoeSto/GetObjectsByBounds');
        //mapController.getObjectsByBounds(
        //    bounds,
        //    function (data) {
        //        var objectManager = new ymaps.LoadingObjectManager({
        //            // Чтобы метки начали кластеризоваться, выставляем опцию.
        //            clusterize: true,
        //            // ObjectManager принимает те же опции, что и кластеризатор.
        //            gridSize: 32
        //        });
        //        // Чтобы задать опции одиночным объектам и кластерам,
        //        // обратимся к дочерним коллекциям ObjectManager.
        //        objectManager.objects.options.set('preset', 'islands#greenDotIcon');
        //        objectManager.clusters.options.set('preset', 'islands#greenClusterIcons');
                
        //        myMap.geoObjects.add(objectManager);

        //        objectManager.add(data);
        //    },
        //    function() {});
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

