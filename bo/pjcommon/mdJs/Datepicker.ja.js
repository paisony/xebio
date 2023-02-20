jQuery(function($){
     $.datepicker.regional['ja'] = {
        clearText: 'クリア',
        closeText: '閉じる',
        prevText: '<先月',
        nextText: '来月>',
        prevStatus: '来月>',
        yearStatus: '年選択',
        monthStatus: '月選択',
        monthNames: ['1月','2月','3月','4月','5月','6月', '7月','8月','9月','10月','11月','12月'],
        monthNamesShort: ['1月','2月','3月','4月','5月','6月', '7月','8月','9月','10月','11月','12月'],
        weekHeader: '週',
        dayNames: ['日曜日','月曜日','火曜日','水曜日','木曜日','金曜日','土曜日'],
        dayNamesShort: ['日', '月', '火', '水', '木', '金', '土'],
        dayNamesMin: ['日', '月', '火', '水', '木', '金', '土'],
        dateFormat: 'yy/mm/dd',
        firstDay: 1,
        currentStatus: '当月表示', 
        numberOfMonths : 1,
        changeMonth: true,
        changeYear: true,
        TodayCircle:true,
        isRTL: false
	};
	$.datepicker.setDefaults($.datepicker.regional['ja']);
});