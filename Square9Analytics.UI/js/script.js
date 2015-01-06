//init global variables
var auditData;
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
                text: 'Number of actions taken.', position: 'outer-middle'
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
          }}
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
        if (data.Log.length > 0){
            auditData = parseLog(data.Log,'Documents Indexed');
            auditData[0].splice(0,0,'x');
            chart.load({
                //unload: ['x', 'Documents Indexed'],
                columns: [
                    auditData[0],
                    auditData[1]
                ]
            });
        }
        else{
            chart.load({
                unload: ['x', 'Documents Indexed'],
                columns: [

                ]
            });
        }

        // testing
        // setTimeout(function () {
        //     chart.load({
        //         unload: ['x', 'Documents Indexed'],
        //         // columns: [
        //         //     ['x', 130, 120, 150, 140, 160, 150],
        //         //     ['data4', 30, 20, 50, 40, 60, 50],
        //         // ]
        //     });
        // }, 2000);

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