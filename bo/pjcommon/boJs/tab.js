$(function() {
    'use strict';

    /*************
        タブ機能
    *************/

    // 検索ページタブ
        $(".str-tab-menu ul li a").click(function () {
            $(".str-tab-cont").hide();
            $($(this).attr("href")).toggle();
            $(".str-tab-menu ul li a").removeClass("search-tab-active");
            $(this).toggleClass("search-tab-active");
            return false;
        });

    // 検索ページタブ
        if(selectedTab && selectedTab != '') {
              
          $(".str-tab-menu ul li a").each(function () {
            if ($(this).attr("href") == '#tab' + selectedTab) {
                $(this).click();
            }
          });
        } else {
          $(".str-tab-menu ul li a:first").click();
        }
});