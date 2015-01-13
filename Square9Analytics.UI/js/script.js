//init global variables
//var auditData;
var chart;
//chart date range
var startDate;// = '10/1/2014';//test data
var endDate;// = '9/1/2014';

//document load
$(function() {
    //init chart
    chart = c3.generate({
    	data: {
    		x: 'x',
    		columns: []
    	},
    	axis: { 
    		y: { 
    			label: { 
    				text: 'Number of actions taken', position: 'outer-middle'
    			}
    		},
    		x: {
    			label: {
    				text: 'Action Dates',
    				position: 'inner-left'
    			},
    			type : 'timeseries',
    			tick: {
    				fit: true,
    				format: "%m-%d-%Y",
    				rotate:45,

          		//culling: false, //show all ticks (dates may overlap with big data sets)
          		culling: {
                max: 15 // the number of tick texts will be adjusted to less than this value
              }
            }
          }
        },
        padding:{
        	right:50,
        	left:50
        }
      });
    
    //init date range picker
    startDate = moment().subtract(2, 'months').format("MM/DD/YYYY");
    endDate = moment().format("MM/DD/YYYY");
    $('#auditlogdates').daterangepicker(
    { 
    	timePicker: false, 
    	timePickerIncrement: 30, 
    	format: 'MM/DD/YYYY',
            // startDate: startDate,
            // enddate: endDate
          },
          function(start, end, label){
          	startDate = start.format('MM/DD/YYYY');
          	endDate = end.format('MM/DD/YYYY');
          }
          );
    //set the dates that will appear in the box
    $('#auditlogdates').data('daterangepicker').setStartDate(startDate);
    $('#auditlogdates').data('daterangepicker').setEndDate(endDate);

    //listeners
    $( "#buttonGet" ).click(function() {
    	//unload any unchecked boxes prior to timeout hack
    	$("input:checkbox:not(:checked)").each(function (index){
          //cleanChart($(this).attr("name"));
          chart.unload({
          	done: function(){
          		//chart unload animation breaks async load, timeout hack workaround
							//until API supports multiple actions 1 call to avoid multiple unload() calls
							setTimeout(function(){
								$("input:checked").each(function (index){
									getAPIData($(this).val(), $(this).attr("name"));
								});
							},230);
						}
					});
        });
    });

    //user dropdown?
    // $( "#dropdownMenu1" ).click(function() {
    //     $('.dropdown-toggle').dropdown();
    // });
});

//Indexed, AnnotationUpdate, Emailed, Printed, Deleted, and Viewed.
function getAPIData(action, title){
    //call out to analytics api with ajax
    var url = "../../square9analytics/analytics/Actions/GetData";

    //TODO: get user from dropdown issue #20

    var user = null;
    if (user){
    	url += "/" + user;
    }
    url += "?startdate=" + startDate + "&enddate=" + endDate + "&action=" + action;

    $.ajax({
    	url: url
    }).done(function(data) {
    	if (data.Log.length > 0){
    		var auditData = parseLog(data.Log, title);
          //TODO: parse data.Users into dropdown issue #20

          auditData[0].splice(0,0,'x');

          //c3 unload animation breaks loading the chart when called outside chart.load()
          //if called shorter than 230ms apart. because this is a callback, calling unload()
          //breaks any instance of load being called.
          // var unchecked = $.map($("input:checkbox:not(:checked)"), function(v){
          // 	return v.name;
          // });
    chart.load({
          	//unload: [unchecked],
          	columns: [
          	auditData[0],
          	auditData[1]
          	]
          });
  }

        //testing function, this will fire automatically to test c3 transitions
        // setTimeout(function () {
        //     chart.load({
        //         //unload: ['x', 'Documents Indexed'],
        //         columns: [
        //             x1,
        //             data1
        //         ]
        //     });
        // }, 2000);

}).fail(function(XMLHttpRequest, textStatus, errorThrown) {
	console.log(textStatus);
	console.log(errorThrown);
});
}

//parse AuditLog data
var parseLog = function(data, auditAction){
	var parsedDates = {};

	var dates = [];
	var counts = [];

	for (var i = 0; i < data.length;i++)
	{
		var date = data[i].Date;
		//parsedDates[date] = parsedDates[date] ? parsedDates[date] + 1 : 1;
		parsedDates[date] = parsedDates[date] ? parsedDates[date] + 1 : 1;
	}
	counts.push(auditAction);
	for (var property in parsedDates) {
		if (parsedDates.hasOwnProperty(property)) {
			dates.push(property);
			counts.push(parsedDates[property]);
		}
	}
	return [dates , counts];
};

// //test data
// var parseTestLog = [
//     {
//         'Date': '2013-09-15',
//         'Action': 'Document Indexed'
//     },
//     {
//         'Date': '2013-09-15',
//         'Action': 'Document Indexed'
//     },
//     {
//         'Date': '2013-09-24',
//         'Action': 'Document Indexed'
//     },
//     {
//         'Date': '2013-09-30',
//         'Action': 'Document Indexed'
//     },
//     {
//         'Date': '2013-09-30',
//         'Action': 'Document Indexed'
//     },
//     {
//         'Date': '2013-10-03',
//         'Action': 'Document Indexed'
//     }
// ];

//var x1 = ['x', '2013-10-31', '2013-12-31', '2014-01-31', '2014-02-28', '2014-03-8', '2014-03-20', '2014-03-21', '2014-03-22'];
//var data1 = ['Documents Indexed', 4,4,4,3,2,6,2,1];