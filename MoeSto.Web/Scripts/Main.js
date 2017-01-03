var myMap;

// Дождёмся загрузки API и готовности DOM.
ymaps.ready(init);

function init() {
    
    ymaps.geolocation.get().then(function (res) {
        var mapContainer = $('#map'),
            bounds = res.geoObjects.get(0).properties.get('boundedBy'),
            // Calculating the viewport for the user's current location.
            mapState = ymaps.util.bounds.getCenterAndZoom(
                bounds,
                [mapContainer.width(), mapContainer.height()]
                
            );
        createMap(mapState);
    }, function (e) {
        // If the location cannot be obtained, we just create a map.
        createMap({
            center: [55.751574, 37.573856],
            zoom: 5
        });
    });
    function createMap(state) {
        map = new ymaps.Map('map', state);
    }
}

function getCurrentPosition(geolocation, map) {
    geolocation.get({
        provider: 'browser',
        mapStateAutoApply: true
    }).then(function (result) {
        // We'll mark the position obtained through the browser in blue. If the browser does not
        // support this functionality, the placemark will not be added to the map.
        result.geoObjects.options.set('preset', 'islands#blueCircleIcon');
        map.geoObjects.add(result.geoObjects);
    });
}

function getCenterOfMap(geolocation, map) {
    geolocation.get({
        provider: 'yandex',
        mapStateAutoApply: true
    }).then(function (result) {
        // We'll mark the position calculated by IP in red.
        result.geoObjects.options.set('preset', 'islands#redCircleIcon');
        result.geoObjects.get(0).properties.set({
            balloonContentBody: 'Мое местоположение'
        });
        map.geoObjects.add(result.geoObjects);
    });
}