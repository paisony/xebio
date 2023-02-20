/*-----------------------------------------------------------------------------
非同期マスタ参照メソッド
-----------------------------------------------------------------------------*/

//検索共通関数
function searchCommonInner_RO(conditionColumns, resultColumns, readOnlyColumns, aspxName) {

    mdAsynchronousCancel = "";

    if (AjaxModel.dataClear) {
        resetResultColumns(resultColumns);
    }
    var requestUrl = MD_ASYNCHRONOUS_ROOT_PATH + aspxName;
    var xmlObject = createXmlObject(conditionColumns, resultColumns, readOnlyColumns);
    if (!xmlObject) {
        return;
    }
    //readOnlyColumnsをreadOnlyにする
    if (readOnlyColumns != null) {
        for (i = 0, n = readOnlyColumns.length; i < n; i++) {
            readOnlyColumns[i].setAttribute("readOnly", "readOnly");
        }
    }

    send(xmlObject, requestUrl);
}

//検索共通関数（ＡＳＰＸのＵＲＬを指定）
function searchCommonInner_RO_Url(conditionColumns, resultColumns, readOnlyColumns, requestUrl) {

    mdAsynchronousCancel = "";

    if (AjaxModel.dataClear) {
        resetResultColumns(resultColumns);
    }
    //var requestUrl = MD_ASYNCHRONOUS_ROOT_PATH + aspxName;
    var xmlObject = createXmlObject(conditionColumns, resultColumns, readOnlyColumns);
    if (!xmlObject) {
        return;
    }
    //readOnlyColumnsをreadOnlyにする
    if (readOnlyColumns != null) {
        for (i = 0, n = readOnlyColumns.length; i < n; i++) {
            readOnlyColumns[i].setAttribute("readOnly", "readOnly");
        }
    }

    send(xmlObject, requestUrl);
}

//検索共通関数で名称が取得できない場合の処理
function searchCommonError(conditionColumns, errItem, resultColumns) {

    if (resultColumns == null || errItem == null) {
        return;
    }
    for (var r in resultColumns) {
        tmp = resultColumns[r];
        if (!tmp) {
            continue;
        }
        // 名称に紐づけられたbindを削除
        $(tmp).unbind('mdSetAfter');
        $(tmp).unbind('mdDontSetAfter');
        // 検索結果があるとき、エラー表示を外す
        $(tmp).bind('mdSetAfter', function () {
            for (var i = 0; i < errItem.length; i++) {
                if (errItem[i] == null) {
                    continue;
                }

                var beforClass = errItem[i].className;
                if (errItem[i].className.indexOf('error-input-code') != -1) {
                    errItem[i].className = beforClass.replace(" error-input-code", "");
                }
            }
        });

        // 検索結果がないとき、エラー表示を行う
        $(tmp).bind('mdDontSetAfter', function () {
            for (var i = 0; i < errItem.length; i++) {
                if (errItem[i] == null) {
                    continue;
                }
                if (errItem[i].className.indexOf('error-input-code') == -1) {
                    errItem[i].className += " error-input-code";
                }
            }
        });
    }
}

function searchCommonInner(conditionColumns, resultColumns, aspxName) {
    var readOnlyColumns = null;
    searchCommonInner_RO(conditionColumns, resultColumns, readOnlyColumns, aspxName);
}

function searchCommonInner_Url(conditionColumns, resultColumns, aspxName) {
    var readOnlyColumns = null;
    searchCommonInner_RO_Url(conditionColumns, resultColumns, readOnlyColumns, aspxName);
}

/*---------------------------------------------------------------------------*/

// 項目IDからコントロールを取得します。
function getCTL(iItemID, iMeiNo) {
    return getAdvControlFromItemID(iItemID, iMeiNo);
}

//プログラム終了
function endProgram(programId) {
    $.ajax({
        async: false,
        type: "POST",
        cache: false,
        processData: false,
        url: MD_ASYNCHRONOUS_ROOT_PATH + "BtnsryEndProgram.aspx",
        data: "programId=" + programId,
        dataType: "text",
        success: responseEnd
    });
}
function responseEnd(data, status) {
    window.parent.close();
}
