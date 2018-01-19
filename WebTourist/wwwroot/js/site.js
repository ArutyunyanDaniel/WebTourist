var map;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 13,
        center: { lat: 47.234524, lng: 38.884903 },
        mapTypeId: 'terrain'
    });

    map.addListener('click', function (e) {
        placeMarkerAndPanTo(e.latLng, map);
    });
    var flightPlanCoordinates = [
        { lat: 37.772, lng: -122.214 },
        { lat: 21.291, lng: -157.821 },
        { lat: -18.142, lng: 178.431 },
        { lat: -27.467, lng: 153.027 }
    ];
    DrawRoute(flightPlanCoordinates);
    //var flightPath = new google.maps.Polyline({
    //    path: flightPlanCoordinates,
    //    geodesic: true,
    //    strokeColor: '#FF0000',
    //    strokeOpacity: 1.0,
    //    strokeWeight: 2
    //});

    //flightPath.setMap(map);
}

function DrawRoute(route) {
    console.log(route);
    var flightPath = new google.maps.Polyline({
        path: route,
        geodesic: true,
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 2
    });

    flightPath.setMap(map);
}

function ShowMarker(latLng, name, description, map) {


    var marker = new google.maps.Marker({
        position: latLng,
        map: map,
        title: name,
        icon: "/Icon/museum.png"
    });
    var infowindow = new google.maps.InfoWindow({
        content: description
    });

    marker.addListener('click', function () {
        infowindow.open(map, marker);
    });

}

function consoleWriteSt(nn) {
    console.log(nn);
}

function coordArray(coordString) {
    var coords = coordString.split(",");
    var temp = coords.slice(1, -1);
    var arr = [];


    while (temp.length) {

        var item = temp[0].split(' ');
        temp.splice(0, 2);
        var partFirst = parseFloat(item[0]);
        var partsecond = parseFloat(item[1]);
        var ll = new google.maps.LatLng(partFirst, partsecond);

        placeMarkerAndPanTo(ll, map);

        arr.push({ lat: ll.lat(), lng: ll.lng() });
    }
    DrawRoute(arr);
}

function placeMarkerAndPanTo(latLng, map) {
    var marker = new google.maps.Marker({
        position: latLng,
        map: map

    });
    map.panTo(latLng);

    var infowindow = new google.maps.InfoWindow({
        content: "Your location."
    });

    marker.addListener('click', function () {
        infowindow.open(map, marker);
    });
}



function getLatLngFromString(ll) {

    ll = ll.slice(1, -1);
    var latlng = ll.split(' ');
    return new google.maps.LatLng(parseFloat(latlng[0]), parseFloat(latlng[1]));
}

function disMes() {
    alert('asdasd');
}