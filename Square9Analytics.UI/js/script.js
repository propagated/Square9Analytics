//init global variables
var auditData;
var chart;
//chart date range
var startDate = '6/1/2014';//test data
var endDate = '9/1/2014';

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
                text: 'Number of actions taken.', position: 'outer-middle'
            }
        },
        x: {
            label: {
              text: 'Action Dates',
              position: 'outer-left'
            },
            type : 'timeseries',
            tick: {
                fit: true,
                format: "%m-%d-%Y",
                multiline:true
            }
          }}
	});
    
    //init date range picker
    $('#auditlogdates').daterangepicker(
        { 
            timePicker: false, 
            timePickerIncrement: 30, 
            format: 'MM/DD/YYYY' 
        },
        function(start, end, label){
            startDate = start.format('MM/DD/YYYY');
            endDate = end.format('MM/DD/YYYY');
        }
    );

    //listeners
    $( "#buttonGet" ).click(function() {
        //get dates from picker
        getData();
    });

    // $( "#dropdownMenu1" ).click(function() {
    //     $('.dropdown-toggle').dropdown();
    // });
    
    
});

function getData(){
    //call out to analytics api with ajax
    var url = "../../square9analytics/analytics/Actions/GetData?startdate=" + startDate + "&enddate=" + endDate + "&action=indexed";
    $.ajax({
        url: url
    }).success(function(data) {
        auditData = parseLog(data.Log,'Documents Indexed');
        auditData[0].splice(0,0,'x');
        chart.load({
            columns: [
                auditData[0],
                auditData[1]
            ]
            //x: {categories: auditData[0]}
        });

    }).error(function(data) {
        
        console.log(data);
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
// var Log = [
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