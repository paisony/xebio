$(function () {
    'use strict';
    /*
        カレンダー表示
    */
    var calendarInput = $(".datepicker");
    if (calendarInput && calendarInput.length != 0) {
        calendarInput.datepicker({
            showOn: "button",
            buttonImage: "../Common/boImages/icon-cal.png",
            changeYear: true,
            changeMonth: true,
            firstDay: 1,
            buttonImageOnly: true,
            showAnim: 'fadeIn',
            beforeShow: function (input, inst) {
                inst.dpDiv.css({ marginTop: -27 + 'px', marginLeft: 107 + 'px' });
            }
        });
    }

});
