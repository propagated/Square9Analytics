//init global variables
var auditData;
var chart;
//chart date range
var startDate;
var endDate;

//document load
$(function() {
    //test data TODO: move to getData post api call
    auditData = parseLog(Log);

    //init chart
	chart = c3.generate({
	data: {
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
              position: 'middle'
            },
                type: 'category',
                categories: auditData[0]
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
    
});

function getData(){
    //call out to analytics api with ajax
    // $.ajax({
    //     url: ""
    // });

    
    chart.load({
        columns: [auditData[1]]
    });
    //return ['anal','1','3','4','2'];
}

//parse AuditLog data
var parseLog = function(data){
	var parsedDates = {};

    var dates = [];
    var counts = [];


	for (var i = 0; i < data.length;i++)
	{
		var date = data[i].Date;
		//parsedDates[date] = parsedDates[date] ? parsedDates[date] + 1 : 1;
        parsedDates[date] = parsedDates[date] ? parsedDates[date] + 1 : 1;
    }
    counts.push('anal'); //for posterity
    for (var property in parsedDates) {
        if (parsedDates.hasOwnProperty(property)) {
            dates.push(property);
            counts.push(parsedDates[property]);
        }
    }
    //dates.splice(0,0,'dates');
    // return dates;
    // //{date:count,date:count}
    // //{[dates],[count]}
    
    // for (i = 1; i < parsedDates.count; i++)
    // {
    //     dates[i] = Object.keys(parsedDates)[i];
    //     counts[i] = parsedDates[dates[i]];
    // }

	return [dates , counts];
};

//test data
var Log = [
    {
        'Date': '2013-09-15',
        'Action': 'Document Indexed'
    },
    {
        'Date': '2013-09-15',
        'Action': 'Document Indexed'
    },
    {
        'Date': '2013-09-24',
        'Action': 'Document Indexed'
    },
    {
        'Date': '2013-09-30',
        'Action': 'Document Indexed'
    },
    {
        'Date': '2013-09-30',
        'Action': 'Document Indexed'
    },
    {
        'Date': '2013-10-03',
        'Action': 'Document Indexed'
    }
];