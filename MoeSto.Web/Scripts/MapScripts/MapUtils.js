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

