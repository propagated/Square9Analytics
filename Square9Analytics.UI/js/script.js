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
    		columns: [],
        type: 'bar'
    	},

    	axis: { 
    		y: { 
    			label: { 
    				text: 'Number of actions taken', position: 'outer-middle'
    			}
    		},
    		x: {
    			label: {
    				text: 'Date of Action',
    				position: 'outer-left'
    			},
                //type: 'timeseries',
    			type : 'categories',
    			tick: {
                    //timeseries properties
    				//fit: true,
    				//format: "%m-%d-%Y",

    				//rotate:45,
                    multiline: false,

                    //culling: false, //show all ticks (dates may overlap with big data sets)
                    culling: {
                        max: 11 // the number of tick texts will be adjusted to less than this value
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
    $('#auditlogdates').on('apply.daterangepicker', function(ev, picker) {
        //stub for possible update enhancement
    });

    $( "#buttonGet" ).click(function() {
        var selectedUser = "";
        if ($('#dduser').val()){
            selectedUser = $('#dduser').val();
            url += "&user=" + encodeURI(selectedUser);
        }
        getAPIData(selectedUser);
    });
});

//Indexed, AnnotationUpdate, Emailed, Printed, Deleted, and Viewed.
function getAPIData(selectedUser){
    var columns = []; //names as they appear below the chart
    var actionKeys = []; //keys as they are returned from the API
    var url = "../../square9analytics/analytics/Actions/GetData?startdate=" + startDate + "&enddate=" + endDate;
    $("input:checked").each(function (index){
        columns.push($(this).attr("name"));
        actionKeys.push($(this).attr("api-name"));
        url += "&action=" + $(this).val();
    });

    //call out to analytics api with ajax
    $.ajax({
    	url: url
    }).done(function(data) {
    	if (data.Log) {
            //users dropdown
            if (!selectedUser)
            {
                resetUserDropdown(data.Users);
            }
            
            //build rows
            columns.splice(0,0,'x');
            var dataRows = [columns];
            // data.Log.forEach(function(element, index, array){
            //     console.Log(index);
            // });

            for (var logIndex in data.Log){
              var row = [logIndex];
              for (var j in actionKeys){
                row.push(data.Log[logIndex][actionKeys[j]]);
              }
              dataRows.push(row);
            }

            var unchecked = getUnchecked();

            //load chart
            chart.load({
              unload: unchecked,
              rows: dataRows
            });
        }
    }).fail(function(XMLHttpRequest, textStatus, errorThrown) {
    	console.log(textStatus);
    	console.log(errorThrown);
    });
}

//parse AuditLog data
var parseLog = function(log){
	
};

var getUnchecked = function(){
    //TODO: intersect this against what's actually loaded and only return those
    return $.map($("input:checkbox:not(:checked)"), function(v){
      return v.name;
  });
};

function resetUserDropdown(users){
    //clear users dropdown
    $('#dduser').empty();
    $('#dduser').append('<option value="">All Users</option>');
    for(var userIndex in users) {
       $('#dduser').append('<option class="username" value="'+ users[userIndex] +'">' + users[userIndex] + '</option>');
       $('#dduser').prop('disabled', false);
    }
}




//test data
// var testData = { "Log": {
//     "11/25/2014": {
//         "Document Indexed": 1,
//         "Document Viewed": 2
//     },
//     "12/3/2014": {
//         "Document Indexed": 1,
//         "Document Viewed": 2
//     },
//     "12/4/2014": {
//         "Document Indexed": 1,
//         "Document Viewed": 5
//     },
//     "12/18/2014": {
//         "Document Indexed": 5,
//         "Document Viewed": 5
//     },
//     "12/19/2014": {
//         "Document Indexed": 4,
//         "Document Viewed": 7
//     },
//     "1/19/2015": {
//         "Document Indexed": 3,
//         "Document Viewed": 12
//     },
//     "11/18/2014": {
//         "Document Viewed": 3,
//         "Document Indexed": 0
//     },
//     "12/17/2014": {
//         "Document Viewed": 3,
//         "Document Indexed": 0
//     },
//     "1/13/2015": {
//         "Document Viewed": 4,
//         "Document Indexed": 0
//     },
//     "1/20/2015": {
//         "Document Viewed": 1,
//         "Document Indexed": 0
//     }
// }
// };

//var x1 = ['x', '2013-10-31', '2013-12-31', '2014-01-31', '2014-02-28', '2014-03-8', '2014-03-20', '2014-03-21', '2014-03-22'];
//var data1 = ['Documents Indexed', 4,4,4,3,2,6,2,1];
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