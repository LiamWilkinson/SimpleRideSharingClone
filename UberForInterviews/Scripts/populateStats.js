function getDriverStats() {
    $.ajax({
        url: "http://localhost:49981/Home/getDriverStats",
        success: function (data) {
            populateStats(data);
        },
        dataType: 'json'
    });
}

function populateStats(stats) {
    //clear stats body table
    $('.statsBody').html('');
    //fill in stats body table with json
    $.each(stats, function(i, item) {
    var $tr = $('<tr>').append(
        $('<td>').text(item.status),
        $('<td>').text(item.count)
    ).appendTo('.statsBody');
  });
}