ymaps.ready(init);
var myMap, myGeoObject;

function init() {
    
    var oldLatitude = $('#hdnLatitude').text();
    var oldLongitude = $('#hdnLongitude').text();
    $('#latitude').val(oldLatitude);
    $('#longitude').val(oldLongitude);
    myMap = new ymaps.Map("contact-map", {
        center: [oldLatitude, oldLongitude],
        zoom: 12,
        controls: ['zoomControl', 'typeSelector', 'fullscreenControl', "searchControl"]
    }, {
        searchControlProvider: 'yandex#search'
    });
    var searchControl = new ymaps.control.SearchControl({
        options: {
            // The search will be performed across toponyms and businesses.
            provider: 'yandex#search'
        }
    });
    myGeoObject = new ymaps.GeoObject({
        // Описание геометрии.
        geometry: {
            type: "Point",
            coordinates: [oldLatitude, oldLongitude]
        },
        // Свойства.
        properties: {
            // Контент метки.

        }
    }, {
        // Опции.
        // Иконка метки будет растягиваться под размер ее содержимого.
        preset: 'islands#dotIcon',
        iconColor: '#735184',
        // Метку можно перемещать.
        draggable: true
    });
    myGeoObject.events.add("dragstart", function (event) {
        var tempLatitude = $('#latitude').val(),
            tempLongitude = $('#longitude').val();
        $('#latitude').val("");
        $('#longitude').val("");
    });
    myGeoObject.events.add("dragend", function (event) {
        var newLatitude = myGeoObject.geometry._coordinates[0],
            newLongitude = myGeoObject.geometry._coordinates[1];
        var myReverseGeocoder = ymaps.geocode([newLatitude, newLongitude]);
        $('#latitude').val(newLatitude);
        $('#longitude').val(newLongitude);
    });
    myMap.geoObjects.add(myGeoObject);

}