ymaps.ready(init);
var myMap, myPlacemark;

function init() {
    var details = $('#comapnyDetailsHdn').val();
    myMap = new ymaps.Map("contact-map", {
        center: [details],
        zoom:12
    });
    
    myPlacemark = new ymaps.Placemark([details], {
        hintContent: 'Москва!',
        balloonContent: 'Столица России'
    });

    myMap.geoObjects.add(myPlacemark);
}


