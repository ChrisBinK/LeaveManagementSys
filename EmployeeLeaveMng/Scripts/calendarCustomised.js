//var to hold the host
var HOST = 'http://localhost:50322/api/';
//create a variable
var today = new moment();

//CONSTANTS 
var rows = 5;
var cols = 6;


var currentDay = moment(today).startOf('month');
var currentMonth = null;


// GET THE DAYS FOR LEAP YEARS
var febNumberDays = isLeapYear(currentDay.year());

// this dictionary holds the calendar Months and  days
var CalendarMonnthDays = {
    0: "JANUARY, 31",
    1: "FEBRUARY, " + febNumberDays + "",
    2: "MARCH, 31",
    3: "APRIL, 30",
    4: "MAY, 31",
    5: "JUNE, 30",
    6: "JULY, 31",
    7: "AUGUST, 31",
    8: "SEPTEMBER, 30",
    9: "OCTOBER, 31",
    10: "NOVEMBER, 30",
    11: "DECEMBER, 31"
};
function isLeapYear(year) {
    if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
        return 29;
    return 28;
}

function setNextMonth() {

    //update current day to be next month
    currentDay = currentDay.clone().add(1, 'month').startOf('month');

}

function setPrevMonth() {
    // create a new days
    currentDay = currentDay.clone().subtract(1, 'month').startOf('month');
}

function setUpcalendar() {
    
    //get the current Month as an array with month description and Number of days in a month
    currentMonth = CalendarMonnthDays[currentDay.month()].toString().split(',');

    // append the month description to the calendar
    $('#monthDescription').html(currentMonth[0] + " " + currentDay.year());

    var table = "";
    var firstDayOFMonth = currentDay.day()

    var totalNumberOfDaysPerMonth = currentMonth[1];

    var temporaryDate = currentDay.clone();
    //Variable to count the number of days
    var counter = 1;

    for (var r = 0; r <= rows ; r++) {
        table += "<tr>";

        for (var c = 0; c <= 6; c++) {
            //if it is the first row and  the first day of the month does not correspond to col(like sunday, mondays)
            // or when the the counter is greater than numberof days like 31
            // then just insert the an empty cell otherwise insert the day like 1,2,3,4
            if ((r == 0 && firstDayOFMonth > c) || (counter > totalNumberOfDaysPerMonth)) {
                table += "<td>" + "" + "</td>";
            }
            else {

                table += "<td id ='" + temporaryDate.format("YYYY-MM-DDThh:mm") + "'> " + counter + "</td>";
                temporaryDate = temporaryDate.add(1, 'days')
                counter++;
            }

        }
        table += "</tr>";


    }
    counter = 0;

    // append the table to the calendar
    $('#calendarContent').html(table);
    $('td').addClass('calendarCell')

    //disable weekend
    disableWeekend();

}


//disable weekend
function disableWeekend() {

    $('table tr').find('td:eq(0),th:eq(0)').addClass('calendarWeek disabledWeekend');
    $('table tr').find('td:eq(6),th:eq(6)').addClass('calendarWeek disabledWeekend');

    disablePreviousDate();
}

function disablePreviousDate()
{
    // function to disable previous months so that user cannot request leave for previous months
    $('#calendarTable tr').each(function () {
        $('td:not(:empty)', this).each(function () {
            //get table cell values
            var res = $(this).attr('id');
            // check if  the date is prevous days
            var isOldDate = moment().isSameOrBefore(res, 'day');           
            //in case it is an old date, just disable the date so that user should not click on them
            if(isOldDate  == false)
            {
                $(this).addClass('calendarWeek disabledWeekend');
            }
           
    });
     
    });
}
//allow to fire event
$(function () {

    // function to clear the calendar
    function clearCalendar() {
        $('#calendarContent').empty();
        $('#monthDescription').empty();
    }

    //change the user cursor to hand when user hover chevron
    $('#previousMonthArrow').hover(function () {
        $(this).css('cursor', 'pointer');
    });


    //change the user cursor to hand when user hover chevron
    $('#nextMonthArrow').hover(function () {
        $(this).css('cursor', 'pointer');
    });
    // //move to next month when click on chevron next
    $('#nextMonthArrow').click(function () {
        clearCalendar();
        setNextMonth();
        setUpcalendar();

    });
    //move to prev month when click on chevron next
    $('#previousMonthArrow').click(function () {
        clearCalendar();
        setPrevMonth()
        setUpcalendar();
    });

    // click only on calendar cell that are not empty
    $('#calendarContent').on('click', 'td:not(:empty)', function (event) {
        // check if it is not the weekend
        if ($(this).hasClass('disabledWeekend') == false) {

            $('#leaveRequestModal').modal('show');
            //get the id of the cell whhch contains the date
            var selectedDate = event.target.id;
            // get the current time
            var strTime = moment().toDate().toTimeString();
            // create a variable moment to hod he current time
            var tempTime = moment(strTime, 'hh:mm');
            // set the variable to display with the current timee
            var dateToDisplay = moment(selectedDate , "YYYY-MM-DDThh:mm");
            dateToDisplay.set('hour', tempTime.get('hour'));
            dateToDisplay.set('minute', tempTime.get('minute'));
            console.log()
            // display the date
            $('#fromDate').val(dateToDisplay.format('YYYY-MM-DDThh:mm'));
            $('#toDate').val(dateToDisplay.format('YYYY-MM-DDThh:mm'));
        }
    });

    //Method to fill the dropdown in modal calendar for leave request
    //
    $.get(HOST + 'LeaveType/', function (data) {
        var selectHtml = '';
        $.each(data, function (i, item) {
            //create option for the select input with the data retrieve from the database
            selectHtml += '<option value="' + item.LeaveTypeID + '">' + item.LeaveDescription + '</option>';
        });
        //append the html  to the slect element
        $('#leaveType').append(selectHtml);
    });
});


