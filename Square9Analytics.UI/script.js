// Code goes here

$(function() {
  $('#auditlogdates').daterangepicker({ timePicker: false, timePickerIncrement: 30, format: 'MM/DD/YYYY' });

  $('#auditlogdates').on('apply.daterangepicker', function(ev,picker) {
    $('#something').text(picker.startDate.format('YYYY-MM-DD'));
    $('#someotherthing').text(picker.endDate.format('YYYY-MM-DD'));
  });
  
  $("#buttonGet").click(function(){
    getData();
    
  });
  

  //var data = [5];
  var data = [3, 6, 2, 7, 5, 2, 1, 3, 8, 9, 2, 5, 7],
  w = 400,
  h = 200,
  margin = 20,
  y = d3.scale.linear().domain([0, d3.max(data)]).range([0 + margin, h - margin]),
  x = d3.scale.linear().domain([0, data.length]).range([0 + margin, w - margin]);
  
  var vis = d3.select("body")
    .append("svg:svg")
    .attr("width", w)
    .attr("height", h);
 
  var g = vis.append("svg:g")
    .attr("transform", "translate(0, 200)");
  
  var line = d3.svg.line()
    .x(function(d,i) { return x(i); })
    .y(function(d) { return -1 * y(d); });
  
  g.append("svg:path").attr("d", line(data));
  
  g.append("svg:line")
    .attr("x1", x(0))
    .attr("y1", -1 * y(0))
    .attr("x2", x(w))
    .attr("y2", -1 * y(0));
 
  g.append("svg:line")
    .attr("x1", x(0))
    .attr("y1", -1 * y(0))
    .attr("x2", x(0))
    .attr("y2", -1 * y(d3.max(data)));
    
    g.selectAll(".xLabel")
    .data(x.ticks(5))
    .enter().append("svg:text")
    .attr("class", "xLabel")
    .text(String)
    .attr("x", function(d) { return x(d) })
    .attr("y", 0)
    .attr("text-anchor", "middle");
 
  g.selectAll(".yLabel")
    .data(y.ticks(4))
    .enter().append("svg:text")
    .attr("class", "yLabel")
    .text(String)
    .attr("x", 0)
    .attr("y", function(d) { return -1 * y(d) })
    .attr("text-anchor", "right")
    .attr("dy", 4);
    
  g.selectAll(".xTicks")
    .data(x.ticks(5))
    .enter().append("svg:line")
    .attr("class", "xTicks")
    .attr("x1", function(d) { return x(d); })
    .attr("y1", -1 * y(0))
    .attr("x2", function(d) { return x(d); })
    .attr("y2", -1 * y(-0.3));
 
g.selectAll(".yTicks")
    .data(y.ticks(4))
    .enter().append("svg:line")
    .attr("class", "yTicks")
    .attr("y1", function(d) { return -1 * y(d); })
    .attr("x1", x(-0.3))
    .attr("y2", function(d) { return -1 * y(d); })
    .attr("x2", x(0));
    
  
  //chartData(data);
});


function getData(){
  
  var data = {
    "Users": [
      "Peter",
      "Jon"
    ],
    "Log": [
      {
        "Date": "1/1/2001",
        "Action": "Document Indexed"
      },
      {
        "Date": "1/2/2001",
        "Action": "Document Indexed"
      },
      {
        "Date": "1/3/2001",
        "Action": "Document Indexed"
      },
      {
        "Date": "1/3/2001",
        "Action": "Document Indexed"
      }
    ]
  };
  return data;
  //hit API
  // $.ajax({
    // type: "GET",
  //   url: 'http://localhost/square9analytics/analytics/Actions',
  //   success: function (data) {
  //       chartData(data);
  //   },
  //   error: function (error) {
  //       console.log("ERROR " + error);
  //   }
  // });
}

//data=array
function chartData(data){
  d3.select(".chart")
  .selectAll("div")
    .data(data)
  .enter().append("div")
    .style("width", function(d) { return d * 10 + "px"; })
    .text(function(d) { return d; });
}