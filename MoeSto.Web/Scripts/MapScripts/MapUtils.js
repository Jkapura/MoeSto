var functions = {
    mapFunctions: {
        getCurrentPosition: function (geolocation, map) {
            geolocation.get({
                provider: 'browser',
                mapStateAutoApply: true
            }).then(function (result) {
                // We'll mark the position obtained through the browser in blue. If the browser does not
                // support this functionality, the placemark will not be added to the map.
                result.geoObjects.options.set('preset', 'islands#blueCircleIcon');
                map.geoObjects.add(result.geoObjects);
            });
        },
        getCenterOfMap: function (geolocation, map) {
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
        },
        //return markup template for single geoObject balloon
        getBalloonContentBody: function (id, data) {
            return '<div class="companyDetailsWrapper"><a href="Company/View/' + id + '" target="_blank"><div class="companyDetailsImg imgWrapper"><p class="companyDetailsName">' +
                (data.Name != null ? data.Name : "") +
                '</p></div></a><div class="companyDetailsCommon"><p>' +
                (data.Address != null ? data.Address : "") + '</p><p>' +
                (data.Phones != null ? data.Phones : "") + '</p><a class="companyDetailsEmail" href="mailto:' +
                (data.Email != null ? data.Email : "") + '">' +
                (data.Email != null ? data.Email : "") + '</a></div></div>';
        },
        //whether features are cluster
        isClusterized: function (features) {
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
        },
        //create map
        createMap: function (state) {
            myMap = new ymaps.Map('map', state);
        }
    },
    mapBindings: {
        sityChangeBinding: function (manager) {
            var city = $('.slt_formSaleCity').val();
            var myGeocoder = ymaps.geocode(city);
            myGeocoder.then(
            function (res) {
                var coords = res.geoObjects.get(0).geometry.getCoordinates();
                myMap.setCenter(coords);
                manager.setFilter(function (obj) {
                    return obj.properties.city == city;
                });
            });
            
        }
    }
}


