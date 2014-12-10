//document load
$(function() {
	var data = parseLog(Log);

	var chart = c3.generate({
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
                categories: data[0]
          }}
	});
    chart.load({
        columns: [data[1]]
    });

    //setup date range picker
    $('#auditlogdates').daterangepicker({ timePicker: false, timePickerIncrement: 30, format: 'MM/DD/YYYY' });
    
    $('#auditlogdates').on('apply.daterangepicker', function(ev,picker) {
        $('#something').text(picker.startDate.format('YYYY-MM-DD'));
        $('#someotherthing').text(picker.endDate.format('YYYY-MM-DD'));
    });

    $("#buttonGet").click(function(){
        var newData = getData();
        chart.load({
            columns: [newData]
        });
    });
});

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

function getData(){
    return ['anal','1','3','4','2'];
}

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