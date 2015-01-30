//init global variables
var chart;
//chart date range
var startDate;
var endDate;

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
          text: 'Number of actions taken',
          position: 'outer-middle'
        }
      },
      x: {
        label: {
          text: 'Date of Action',
          position: 'outer-left'
        },
        //type: 'timeseries',
        type: 'categories',
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
    padding: {
      right: 50,
      left: 50
    }
  });

  //init date range picker
  startDate = moment().subtract(2, 'months').format("MM/DD/YYYY");
  endDate = moment().format("MM/DD/YYYY");
  var $auditlogdates = $('#auditlogdates');
  $auditlogdates.daterangepicker({
      timePicker: false,
      format: 'MM/DD/YYYY',
      // startDate: startDate,
      // enddate: endDate
    },
    function(start, end, label) {
      startDate = start.format('MM/DD/YYYY');
      endDate = end.format('MM/DD/YYYY');
    }
  );
  //set the dates that will appear in the box
  $auditlogdates.data('daterangepicker').setStartDate(startDate);
  $auditlogdates.data('daterangepicker').setEndDate(endDate);

  //listeners
  $auditlogdates.on('apply.daterangepicker', function(ev, picker) {
    getAPIData(getFilters());
  });

  $("#buttonGet").click(function() {
    getAPIData(getFilters());
  });
});

var getFilters = function() {
  var filters = {
    columns: [], //names as they appear below the chart
    actionKeys: [], //keys as they are returned from the API
    actionVals: [], //action names to be passed to the API
    selectedUser: '' //optional username filter
  };
  $("input:checked").each(function(index) {
    filters.columns.push($(this).attr("name"));
    filters.actionKeys.push($(this).attr("api-name"));
    filters.actionVals.push($(this).val());
  });
  var $dduser = $('#dduser');
  if ($dduser.val()) {
    filters.selectedUser = $dduser.val();
  }

  return filters;
};

//Indexed, AnnotationUpdate, Emailed, Printed, Deleted, and Viewed.
function getAPIData(filters) {
  var url = "../../square9analytics/analytics/Actions/GetData?startdate=" + startDate + "&enddate=" + endDate;
  if (filters.actionVals.length > 0) {
    if (filters.selectedUser) {
      url += "&user=" + encodeURI(filters.selectedUser);
    }
    for (var actionIndex in filters.actionVals) {
      url += "&action=" + filters.actionVals[actionIndex];
    }
    //call out to analytics api with ajax
    $.ajax({
      url: url
    }).done(function(data) {
      if (data.Log) {
        //users dropdown
        resetUserDropdown(data.Users, filters.selectedUser);

        //build rows
        var dataRows = [];
        for (var logIndex in data.Log) {
          var row = [logIndex];
          for (var j in filters.actionKeys) {
            row.push(data.Log[logIndex][filters.actionKeys[j]]);
          }
          dataRows.push(row);
        }

        dataRows.sort(function(a, b) {
          return new Date(a[0]) - new Date(b[0]);
        });
        filters.columns.splice(0, 0, 'x');
        dataRows.splice(0, 0, filters.columns);

        //load chart
        chart.load({
          unload: getUnchecked(),
          rows: dataRows
        });
      }
        }).fail(function(response, textStatus, errorThrown) {
        	console.log("Error: " + errorThrown + ": " + response.responseText);
        	alert("Error: " + errorThrown + ": " + response.responseText);
    });
  } else {
    //nothing checked, unload chart
    resetUserDropdown();
    chart.unload();
  }
}

var getUnchecked = function() {
  //TODO: intersect this against what's actually loaded and only return those
  return $.map($("input:checkbox:not(:checked)"), function(v) {
    return v.name;
    });
};

function resetUserDropdown(users, selectedUser) {
  //clear users dropdown
  if (users) {
    var $dduser = $('#dduser');
    $dduser.empty();
    $dduser.append('<option value="">All Users</option>');
    $dduser.prop('disabled', false);
    for (var userIndex in users) {
      var option = '<option class="username" value="' + users[userIndex] + '"';
      if (selectedUser && selectedUser === users[userIndex]) {
        option += ' selected>';
      } else {
        option += '>';
      }
      option += users[userIndex] + '</option>';
      $dduser.append(option);
    }
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
