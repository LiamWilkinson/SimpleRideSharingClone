var iconStatusMap = {'picking up': 'caricon.png', 'idling': 'cariconred.png', 'dropping off': 'caricongreen.png'};

function getDriverLocation(){
    $.ajax({
        url: "http://localhost:49981/Home/getDriverLocations",
        success: function (drivers) {
            populateDriverInfo(drivers);
            return populateMap(drivers);
        },
        dataType: 'json'
    });
}

function populateMap(drivers) {
    if (drivers.length > 0) {
        for (var i = 0; i < drivers.length; i++) {
            var driver = drivers[i];
            latLng = new google.maps.LatLng(driver.Latitude, driver.Longitude);
            createNewPoint(latLng, driver.Status, driver.Name);
        }
    }
}

function createNewPoint(latLng, status, title){
  var marker = new google.maps.Marker({
      position: latLng,
      map: map,
      icon: '/Content/' + iconStatusMap[status],
      label: {
        text: title + "'s car",
        color: 'white'
      }
    });
    if (typeof markers == 'undefined') {
        markers = [];
    }
    markers.push(marker);
}

function populateDriverInfo(drivers){
  $('.driverInfoBody').html('');
  for (var i = 0; i < drivers.length; i++) {
    var driver = drivers[i];
      var $tr = $('<tr>').append(
        $('<td>').text(driver.Name),
        $('<td>').text(driver.Status),
        $('<td>').text(driver.Latitude),
        $('<td>').text(driver.Longitude)
      ).appendTo('.driverInfoBody');
  }
}