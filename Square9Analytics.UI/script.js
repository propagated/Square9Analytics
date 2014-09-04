// Code goes here

$(function() {
  $('#auditlogdates').daterangepicker({
    timePicker: false,
    timePickerIncrement: 30,
    format: 'MM/DD/YYYY'
  });

  $('#auditlogdates').on('apply.daterangepicker', function(ev, picker) {
    $('#something').text(picker.startDate.format('YYYY-MM-DD'));
    $('#someotherthing').text(picker.endDate.format('YYYY-MM-DD'));
  });

  $("#buttonGet").click(function() {
    getData();

  });

  var data = [4];

  chartData(data);
});


function getData() {
  //hit API
  $.ajax({
    type: "GET",
    url: 'http://localhost/square9analytics/analytics/Actions',
    success: function(data) {
      chartData(data);
      },
    error: function(error) {
      console.log("ERROR " + error);
    }
  });
}

//data=array
function chartData(data) {
  d3.select(".chart")
    .selectAll("div")
    .data(data)
    .enter().append("div")
    .style("width", function(d) {
      return d * 10 + "px";
    })
    .text(function(d) {
      return d;
    });
}