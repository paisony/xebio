// XN530P01 自社品番検索
function XN530P01(copcd, jsyhbn, suhrksmes, hbnkbn, sirskcd) {
	return XN530P01Main("0", copcd, jsyhbn, suhrksmes, "0", hbnkbn, sirskcd);
}

// XN531P01 自社品番検索(削除含む)
function XN531P01(copcd, jsyhbn, suhrksmes, hbnkbn, sirskcd) {
	return XN530P01Main("1", copcd, jsyhbn, suhrksmes, "0", hbnkbn, sirskcd);
}

// XN532P01 自社品番検索・カナ表示
function XN532P01(copcd, jsyhbn, suhrksmes, hbnkbn, sirskcd) {
	return XN530P01Main("0", copcd, jsyhbn, suhrksmes, "1", hbnkbn, sirskcd);
}

// XN533P01 自社品番検索・カナ表示(削除含む)
function XN533P01(copcd, jsyhbn, suhrksmes, hbnkbn, sirskcd) {
	return XN530P01Main("1", copcd, jsyhbn, suhrksmes, "1", hbnkbn, sirskcd);
}

// 自社品番検索 共通処理
// 返却値の内容は以下の通り
// ①自社品番
// ②商品略式名称
// ③ブランドコード
// ④ブランド略式名称
// ⑤仕入先コード
// ⑥仕入先略式名称
// ⑦最新仕入原価
// ⑧部門コード
// ⑨部門略式名称
// ⑩旧自社品番
// ⑪品番区分 //TODO 追加
function XN530P01Main(skjflg, copcd, jsyhbn, suhrksmes, kmflg, hbnkbn, sirskcd) {
	//ウインドウサイズの設定
	var width = 1000; 	//ダイアログの幅
	var height = 600; 	//ダイアログの高さ
	//値またはコントロールから値への変換
	var copcdValue = "";  //TODO 'copcd'は値またはテキストボックスで渡される。
	if (copcd == null) {
	    copcdValue = "";
	} else {
	    if (typeof copcd == "string") {
	        copcdValue = copcd;
	    } else {
	        copcdValue = copcd.value;
	    }
	}
	var hbnkbnValue = ""; //TODO 'hbnkbn'は値またはドロップダウンリストで渡される。
	if (hbnkbn == null) {
	    hbnkbnValue = "";
	} else {
	    if (typeof hbnkbn == "string") {
	        hbnkbnValue = hbnkbn;
	    } else {
	        hbnkbnValue = hbnkbn[hbnkbn.selectedIndex].value;
	    }
	}
	var sirskcdValue = "";  //TODO 'sirskcd'は値またはテキストボックスで渡される。
	if (sirskcd == null) {
	    sirskcdValue = "";
	} else {
	    if (typeof sirskcd == "string") {
	        sirskcdValue = sirskcd;
	    } else {
	        sirskcdValue = sirskcd.value;
	    }
	}
	//引数データ項目　：　①削除フラグ②会社コード③カナフラグ④品番区分(任意)④仕入先コード(任意)
	var params = new Array("SKJFLG", skjflg, "COPCD", copcdValue, "KMFLG", kmflg, "HBNKBN", hbnkbnValue, "SIRSKCD", sirskcdValue);
	var returnValue = pjOpenModalDialog("xn040p01", params, { title: "商品品番検索", mainForm: document.forms[0] }, width, height);
	if (returnValue != undefined) {
		setReturnValue(jsyhbn, returnValue, 0);
		setReturnValue(suhrksmes, returnValue, 1);
		return returnValue;
	}
	return null;
}

// XN530P03 商品SKU検索
function XN530P03(copcd, skucd, suhrksmes) {
	return XN530P03Main("0", copcd, skucd, suhrksmes, "0");
}

// XN531P03 商品SKU検索(削除含む)
function XN531P03(copcd, skucd, suhrksmes) {
	return XN530P03Main("1", copcd, skucd, suhrksmes, "0");
}

// XN532P03 商品SKU検索・カナ表示
function XN532P03(copcd, skucd, suhrksmes) {
	return XN530P03Main("0", copcd, skucd, suhrksmes, "1");
}

// XN533P03 商品SKU検索・カナ表示(削除含む)
function XN533P03(copcd, skucd, suhrksmes) {
	return XN530P03Main("1", copcd, skucd, suhrksmes, "1");
}

// 商品SKU検索 共通処理
// 返却値の内容は以下の通り
// ①ＳＫＵコード
// ②自社品番
// ③商品略式名称
// ④カラーコード
// ⑤カラー略式名称
// ⑥サイズコード
// ⑦サイズ略式名称
// ⑧メーカー品番
// ⑨販売完了日
function XN530P03Main(skjflg, copcd, skucd, suhrksmes, kmflg) {
	//ウインドウサイズの設定
    var width = 1009; 	//ダイアログの幅
    var height = 600; 	//ダイアログの高さ
	//引数データ項目　：　①削除フラグ②会社コード③カナフラグ
	var params = new Array("SKJFLG", skjflg, "COPCD", copcd.value, "KMFLG", kmflg);
	var returnValue = pjOpenModalDialog("xn050p01", params, { title: "商品ＳＫＵ検索", mainForm: document.forms[0] }, width, height);
	if (returnValue != undefined) {
		setReturnValue(skucd, returnValue, 0);
		setReturnValue(suhrksmes, returnValue, 2);
		return returnValue;
	}
	return null;
}

// XN530P04 商品スキャンコード検索
function XN530P04(copcd, scncd, hbnkbn, sirskcd) {
	return XN530P04Main("0", copcd, scncd, hbnkbn, sirskcd);
}

// XN531P04 商品スキャンコード検索(削除含む)
function XN531P04(copcd, scncd, hbnkbn, sirskcd) {
	return XN530P04Main("1", copcd, scncd, hbnkbn, sirskcd);
}

// 商品スキャンコード検索 共通処理
// 返却値の内容は以下の通り
// ①スキャンコード
// ②ＳＫＵコード
// ③メーカー品番
// ④仕入先コード
// ⑤仕入先略式名称
// ⑥最新仕入原価
// ⑦品番区分 //TODO 追加
function XN530P04Main(skjflg, copcd, scncd, hbnkbn, sirskcd) {
	//ウインドウサイズの設定
	var width = 1000; 	//ダイアログの幅
	var height = 600; 	//ダイアログの高さ
	//値またはコントロールから値への変換
	var hbnkbnValue = ""; //TODO 'hbnkbn'は値またはドロップダウンリストで渡される。
	var sirskcdValue = "";  //TODO 'sirskcd'は値またはテキストボックスで渡される。
	if (hbnkbn == null) {
	    hbnkbnValue = "";
	} else {
	    if (typeof hbnkbn == "string") {
	        hbnkbnValue = hbnkbn;
	    } else {
	        hbnkbnValue = hbnkbn[hbnkbn.selectedIndex].value;
	    }
	}
	var sirskcdValue = "";  //TODO 'sirskcd'は値またはテキストボックスで渡される。
	if (sirskcd == null) {
	    sirskcdValue = "";
	} else {
	    if (typeof sirskcd == "string") {
	        sirskcdValue = sirskcd;
	    } else {
	        sirskcdValue = sirskcd.value;
	    }
	}
	//引数データ項目　：　①削除フラグ②会社コード
	var params = new Array("SKJFLG", skjflg, "COPCD", copcd.value, "HBNKBN", hbnkbnValue, "SIRSKCD", sirskcdValue);
	var returnValue = pjOpenModalDialog("xn060p01", params, { title: "商品スキャンコード検索", mainForm: document.forms[0] }, width, height);
	if (returnValue != undefined) {
		setReturnValue(scncd, returnValue, 0);
		return returnValue;
	}
	return null;
}

// XN530P05	品種検索
function XN530P05(copcd, bmncd, bmnrksmes, hnscd, hnsrksmes) {
	return XN530P05Main("0", copcd, bmncd, bmnrksmes, hnscd, hnsrksmes);
}

// XN531P05	品種検索(削除含む)
function XN531P05(copcd, bmncd, bmnrksmes, hnscd, hnsrksmes) {
	return XN530P05Main("1", copcd, bmncd, bmnrksmes, hnscd, hnsrksmes);
}

// 品種検索 共通処理
// 返却値の内容は以下の通り
// ①部門コード
// ②部門略式名称
// ③品種コード
// ④品種略式名称
function XN530P05Main(skjflg, copcd, bmncd, bmnrksmes, hnscd, hnsrksmes) {
	//ウインドウサイズの設定
	var width = 830; 	//ダイアログの幅
	var height = 600; 	//ダイアログの高さ
	//NULLまたはコントロールから値への変換
	var bmncdValue = ""; //TODO 'bmncd'はNULLまたはテキストボックスで渡される。
	if (bmncd != null) {
	    bmncdValue = bmncd.value;
	}
	//引数データ項目　：　①削除フラグ②会社コード③部門コード
	var params = new Array("SKJFLG", skjflg, "COPCD", copcd.value, "BMNCD", bmncdValue);
	var returnValue = pjOpenModalDialog("xn080p01", params, { title: "品種検索", mainForm: document.forms[0] }, width, height);
	if (returnValue != undefined) {
		setReturnValue(bmncd, returnValue, 0);
		setReturnValue(bmnrksmes, returnValue, 1);
		setReturnValue(hnscd, returnValue, 2);
		setReturnValue(hnsrksmes, returnValue, 3);
		return returnValue;
	}
	return null;
}

// XN530P06 品目検索
function XN530P06(copcd, bmncd, bmnrksmes, hnscd, hnsrksmes, hnmcd, hnmrksmes) {
	return XN530P06Main("0", copcd, bmncd, bmnrksmes, hnscd, hnsrksmes, hnmcd, hnmrksmes);
}

// XN531P06 品目検索(削除含む)
function XN531P06(copcd, bmncd, bmnrksmes, hnscd, hnsrksmes, hnmcd, hnmrksmes) {
	return XN530P06Main("1", copcd, bmncd, bmnrksmes, hnscd, hnsrksmes, hnmcd, hnmrksmes);
}

// XN530P06 品目検索 共通処理
// 返却値の内容は以下の通り
// ①部門コード
// ②部門略式名称
// ③品種コード
// ④品種略式名称
// ⑤品目コード
// ⑥品目略式名称
function XN530P06Main(skjflg, copcd, bmncd, bmnrksmes, hnscd, hnsrksmes, hnmcd, hnmrksmes) {
	//ウインドウサイズの設定
	var width = 830; 	//ダイアログの幅
	var height = 600; 	//ダイアログの高さ
	//NULLまたはコントロールから値への変換
	var bmncdValue = ""; //TODO 'bmncd'はNULLまたはテキストボックスで渡される。
	var hnscdValue = ""; //TODO 'hnscd'はNULLまたはテキストボックスで渡される。
	if (bmncd != null) {
	    bmncdValue = bmncd.value;
	}
	if (hnscd != null) {
	    hnscdValue = hnscd.value;
	}
	//引数データ項目　：　①削除フラグ②会社コード③部門コード④品種コード
	var params = new Array("SKJFLG", skjflg, "COPCD", copcd.value, "BMNCD", bmncdValue, "HNSCD", hnscdValue);
	var returnValue = pjOpenModalDialog("xn090p01", params, { title: "品目検索", mainForm: document.forms[0] }, width, height);
	if (returnValue != undefined) {
		setReturnValue( bmncd, returnValue, 0);
		setReturnValue(bmnrksmes, returnValue, 1);
		setReturnValue(hnscd, returnValue, 2);
		setReturnValue(hnsrksmes, returnValue, 3);
		setReturnValue(hnmcd, returnValue, 4);
		setReturnValue(hnmrksmes, returnValue, 5);
		return returnValue;
	}
	return null;
}

// XN530P07 店舗検索
function XN530P07(copcd, tnpcd, tnprksmes, tnptrikbn, tnptrikbnflg, egyhi) {
	return XN530P07Main("0", copcd, tnpcd, tnprksmes, "1", tnptrikbn, tnptrikbnflg, egyhi);
}

// XN531P07 店舗検索(削除含む)
function XN531P07(copcd, tnpcd, tnprksmes, tnptrikbn, tnptrikbnflg, egyhi) {
	return XN530P07Main("1", copcd, tnpcd, tnprksmes, "1", tnptrikbn, tnptrikbnflg, egyhi);
}

// XN530P09 物流センター検索
function XN530P09(copcd, tnpcd, tnprksmes) {
	return XN530P07Main("0", copcd, tnpcd, tnprksmes, "1", "12", "", "");
}

// XN531P09 物流センター検索(削除含む)
function XN531P09(copcd, tnpcd, tnprksmes) {
	return XN530P07Main("1", copcd, tnpcd, tnprksmes, "1", "12", "", "");
}

// XN530P10 損益部門検索
function XN530P10(copcd, tnpcd, tnprksmes) {
    return XN530P07Main("0", copcd, tnpcd, tnprksmes, "0", "", "", "");
}

// XN531P10 損益部門検索(削除含む)
function XN531P10(copcd, tnpcd, tnprksmes) {
    return XN530P07Main("1", copcd, tnpcd, tnprksmes, "0", "", "", "");
}

// 店舗検索 共通処理
// 返却値の内容は以下の通り
// ①店舗コード
// ②店舗略式名称
// ③店齢情報
// ④店舗形態コード１
// ⑤店舗形態略式名称１
// ⑥店舗形態コード２
// ⑦店舗形態略式名称２
// ⑧店舗形態コード３
// ⑨店舗形態略式名称３
// ⑩店舗階層コード１
// ⑪店舗階層略式名称１
// ⑫店舗階層コード２
// ⑬店舗階層略式名称２
// ⑭店舗階層コード３
// ⑮店舗階層略式名称３
// ⑯店舗取扱区分 //TODO 追加
// ⑰会社コード //TODO 追加
function XN530P07Main(skjflg, copcd, tnpcd, tnprksmes, tnpsnebmnkbn, tnptrikbn, tnptrikbnflg, egyhi) {
	//ウインドウサイズの設定
	var width = 980;		//ダイアログの幅
	var height = 700; 	//ダイアログの高さ
	//値またはコントロールから値への変換
	var copcdValue = "1"; //TODO 'copcd'はNULLまたはテキストボックスで渡される。
	if (copcd == null) {
	    copcdValue = "";
	} else {
	    if (copcd != null && copcd != undefined) {
	        copcdValue = copcd.value;
	    } 
	}
	var tnptrikbnValue = ""; //TODO 'tnptrikbn'は値またはドロップダウンリストで渡される。
	var tnptrikbnflgValue = ""; //TODO 'tnptrikbnflg'は値で渡される。"1"の場合"以外"としそれ以外は"全て"とする。
	var egyhiValue = ""; //TODO 'egyhi'は値で渡される。NULLでない場合、"営業日に稼働している店舗のみ"とする。
	if (tnptrikbn == null) {
	    tnptrikbnValue = "";
	} else {
	    if (typeof tnptrikbn == "string") {
	        tnptrikbnValue = tnptrikbn;
	    } else {
	        tnptrikbnValue = tnptrikbn.value;
	    }
	}
	if (tnptrikbnflg == null) {
	    tnptrikbnflgValue = "";
	} else {
    	tnptrikbnflgValue = tnptrikbnflg;
    }
    if (egyhi == null) {
        egyhiValue = "";
    } else {
        egyhiValue = egyhi;
    }
	//引数データ項目　：　①削除フラグ②会社コード(任意)③店舗取扱区分④店舗取扱区分フラグ(任意)⑤営業日(任意)
	var params = new Array("SKJFLG", skjflg, "COPCD", copcdValue, "TNPSNEBMNKBN", tnpsnebmnkbn, "TNPTRIKBN", tnptrikbnValue, "TNPTRIKBNFLG", tnptrikbnflgValue, "EGYHI", egyhiValue);
	var returnValue = pjOpenModalDialog("xn100p01", params, {title:"店舗検索", mainForm:document.forms[0]}, width, height);
	if (returnValue != undefined) {
		setReturnValue(tnpcd, returnValue, 0);
		setReturnValue(tnprksmes, returnValue, 1);
		return returnValue;
	}
	return null;
}

// XN530P11 店舗仮店舗検索
function XN530P11(copcd, tnpcd, tnprksmes, tnptrikbn, tnptrikbnflg, egyhi, krqjsihikbn, hnykbn3) {
    return XN530P11Main("0", copcd, tnpcd, tnprksmes, "1", tnptrikbn, tnptrikbnflg, egyhi, krqjsihikbn, hnykbn3);
}
// XN531P11 店舗仮店舗検索
function XN531P11(copcd, tnpcd, tnprksmes, tnptrikbn, tnptrikbnflg, egyhi, krqjsihikbn, hnykbn3) {
    return XN530P11Main("1", copcd, tnpcd, tnprksmes, "1", tnptrikbn, tnptrikbnflg, egyhi, krqjsihikbn, hnykbn3);
}
// 店舗仮店舗検索 共通処理
// 返却値の内容は以下の通り
// ①店舗コード
// ②店舗略式名称
// ③店齢情報
// ④店舗形態コード１
// ⑤店舗形態略式名称１
// ⑥店舗形態コード２
// ⑦店舗形態略式名称２
// ⑧店舗形態コード３
// ⑨店舗形態略式名称３
// ⑩店舗階層コード１
// ⑪店舗階層略式名称１
// ⑫店舗階層コード２
// ⑬店舗階層略式名称２
// ⑭店舗階層コード３
// ⑮店舗階層略式名称３
// ⑯店舗取扱区分
// ⑰会社コード
function XN530P11Main(skjflg, copcd, tnpcd, tnprksmes, tnpsnebmnkbn, tnptrikbn, tnptrikbnflg, egyhi, krqjsihikbn, hnykbn3) {
    //ウインドウサイズの設定
    var width = 980; 	//ダイアログの幅
    var height = 700; 	//ダイアログの高さ
    //値またはコントロールから値への変換
    var copcdValue = "1"; //TODO 'copcd'はNULLまたはテキストボックスで渡される。
    if (copcd == null) {
        copcdValue = "";
    } else {
        if (copcd != null && copcd != undefined) {
            copcdValue = copcd.value;
        }
    }
    var tnptrikbnValue = ""; //TODO 'tnptrikbn'は値またはドロップダウンリストで渡される。
    var tnptrikbnflgValue = ""; //TODO 'tnptrikbnflg'は値で渡される。"1"の場合"以外"としそれ以外は"全て"とする。
    var egyhiValue = ""; //TODO 'egyhi'は値で渡される。NULLでない場合、"営業日に稼働している店舗のみ"とする。
    if (tnptrikbn == null) {
        tnptrikbnValue = "";
    } else {
        if (typeof tnptrikbn == "string") {
            tnptrikbnValue = tnptrikbn;
        } else {
            tnptrikbnValue = tnptrikbn.value;
        }
    }
    if (tnptrikbnflg == null) {
        tnptrikbnflgValue = "";
    } else {
        tnptrikbnflgValue = tnptrikbnflg;
    }
    if (egyhi == null) {
        egyhiValue = "";
    } else {
        egyhiValue = egyhi;
    }
    var krqjsihikbnValue = krqjsihikbn;
    if (krqjsihikbn == null || krqjsihikbn == "") {
        krqjsihikbnValue = "0";
    }
    var hnykbn3Value = hnykbn3;
    if (hnykbn3 == null || hnykbn3 == "") {
        hnykbn3Value = "0";
    }
    //引数データ項目　：　①削除フラグ②会社コード(任意)③店舗取扱区分④店舗取扱区分フラグ(任意)⑤営業日(任意)⑥仮店舗フラグ（任意）⑦切替日判定フラグ（任意）⑧汎用区分３判定区分
    var params = new Array("SKJFLG", skjflg, "COPCD", copcdValue, "TNPSNEBMNKBN", tnpsnebmnkbn, "TNPTRIKBN", tnptrikbnValue, "TNPTRIKBNFLG", tnptrikbnflgValue, "EGYHI", egyhiValue, "KRITNPKBN", "1", "KRQJSIHIKBN", krqjsihikbnValue, "HNYKBN3", hnykbn3Value);
    var returnValue = pjOpenModalDialog("xn100p01", params, { title: "店舗検索", mainForm: document.forms[0] }, width, height);
    if (returnValue != undefined) {
        setReturnValue(tnpcd, returnValue, 0);
        setReturnValue(tnprksmes, returnValue, 1);
        return returnValue;
    }
    return null;
}
// -------------------------- 共通部分 ---------------------------------------
// ModalDialogの返却値を画面項目に設定します。
function setReturnValue(item, returnValue, index) {
	if (item != null && item != undefined) {
		item.value = returnValue[index];
	}
}

// ModalDialogを表示します。
// frameUrl: ダイアログ内の画面遷移を有効にするためのダミーIFRAMEのURL
// contentUrl: IFRAME内に表示する画面のURL
// dialogArgs: ModalDialogに渡すオブジェクトの連想配列 showModalDialog()⇒window.open()により不要
// feature: ModalDialogの幅、高さなどの連想配列
function openModalDialog(frameUrl, contentUrl, dialogArgs, feature) {

	//dialogArgs.mainWindow=window;		//メインウィンドウのwindowオブジェクト
	//dialogArgs.contentUrl = contentUrl;	//ModalDialogのフレーム内に表示するURL

	//画面中央に配置するために余白を求める
	var w = (screen.width - feature['width']) / 2;
	var h = (screen.height - feature['height']) / 2;

	feature['top'] = h;
	feature['left'] = w;

	var strFeature="";
	if(typeof(feature)==typeof("")) {
		strFeature=feature;
	}
	else {
		//featureをwindow.open()に渡せる文字列型にする
		for(var key in feature) {
			var value=new String(feature[key]);
			if(key.match(/(width|height|top|left)/i) && value.match(/^\d+$/)) {
				value+='px';
			}
			strFeature+=key+'='+value+', ';
		}
	}

	// コールバックにて後続ボタンアクションを呼び出す
	window['callback'] = function () {
		delete_dom_obj('screenLock');
		if (document.getElementById('Result_flg').value == 'True') {
			callbackaction();
		}
	}

	//showModalDialog(frameUrl,dialogArgs,strFeature);
	return window.open(frameUrl, contentUrl, strFeature);
}

//モードレスダイアログのウィンドウを表示
function openModelessDialog(frameUrl, contentUrl, dialogArgs, feature) {

	dialogArgs.mainWindow=window;			//メインウィンドウのwindowオブジェクト
	dialogArgs.contentUrl=contentUrl;		//ModalDialogのフレーム内に表示するURL

	var strFeature="";
	if(typeof(feature)==typeof("")) {
		strFeature=feature;
	}
	else {
		//featureをshowModalDialog()に渡せる文字列型にする
		for(var key in feature) {
			var value=new String(feature[key]);
			if(key.match(/(width|height|top|left)/i) && value.match(/^\d+$/)) {
				value+='px';
			}
			strFeature+=key+':'+value+'; ';
		}
	}
	// TODO yusy 一旦修正showModelessDialog⇒window.open
	return window.open(frameUrl, dialogArgs, strFeature);
}

//ModalDialogに内に表示するIFRAME
var FRAME_URL='../pjcommon/modaldialog/iframe.html';

//ModalDialogを表示します。
//pgid: 表示する画面のプログラムID
//dialogArgs: ModalDialogに渡すオブジェクトの連想配列
//width,height: ダイアログの幅と高さ
function pjOpenModalDialog(pgid, dialogArgs, width, height) {
	var contentUrl='../../'+pgid+'/'+pgid+'Init.aspx';
	var feature=getFeature(width,height);
	return openModalDialog(FRAME_URL,contentUrl,dialogArgs,feature);
}
//ModalDialogを表示します。
//pgid: 表示する画面のプログラムID
//param: URLパラメータに設定する連想配列
//dialogArgs: ModalDialogに渡すオブジェクトの連想配列
//width: ダイアログの幅
//height: ダイアログの高さ
function pjOpenModalDialog(pgid, param, dialogArgs, width, height) {
	contentUrl = '../../'+pgid+'/'+pgid+'Init.aspx?';
	contentUrl = createQueryString(contentUrl,param);
	var feature = getFeature(width, height);
	return openModalDialog(FRAME_URL, contentUrl, dialogArgs, feature);
}
//ModalDialogを表示します（サーバより起動）
//pgid: 表示する画面のプログラムID
//param: URLパラメータに設定する連想配列
//dialogArgs: ModalDialogに渡すオブジェクトの連想配列
function pjOpenModalDialogServer(pgid, param, dialogArgs) {
	var width = getBrowserWidth();
	var height = getBrowserHeight();
	contentUrl = '../../'+pgid+'/'+pgid+'Init.aspx?';
	contentUrl = contentUrl + param;
	var feature = getFeature(width, height);
	return openModalDialog(FRAME_URL, contentUrl, dialogArgs, feature);
}

//モードレスダイアログのウィンドウを表示
function pjOpenModelessDialog(pgid, dialogArgs, width, height) {
	var contentUrl='../../'+pgid+'/'+pgid+'Init.aspx';
	var feature=getFeature(width,height);
	return openModelessDialog(FRAME_URL,contentUrl,dialogArgs,feature);
}
function pjOpenModelessDialog(pgid, param, dialogArgs, width, height) {
	contentUrl = '../../'+pgid+'/'+pgid+'Init.aspx?';
	contentUrl = createQueryString(contentUrl,param);
	var feature = getFeature(width, height);
	return openModelessDialog(FRAME_URL, contentUrl, dialogArgs, feature);
}

//ModalDialogに表示するURLを取得します。
//btnInfo: ボタンの項目IDと明細のIndexが格納された配列
function getContentUrl(frmId, param) {
	var isExists_IsInit = false;
	var isExists_Commode = false;

	var pgid = ADVIT_TARGETPGID;
	var contentUrl='../'+pgid+'/'+frmId+'.aspx?';

	for (i=0; i< param.length; i++) {
		if (i%2 == 0) {
			if (param[i].toUpperCase() == 'ISINIT') {
				isExists_IsInit=true;
			}
			if (param[i].toUpperCase() == 'COMMODE') {
				isExists_Commode=true;
			}
		}
	}

	if(!isExists_IsInit && !isExists_Commode) {
		contentUrl = contentUrl + 'IsInit=True&Commode=UPD';
	}
	else if(!isExists_IsInit) {
		contentUrl = contentUrl + 'IsInit=True';
	}
	else if(!isExists_Commode) {
		contentUrl = contentUrl + 'Commode=UPD';
	}

	return contentUrl;
}

//モーダル画面の詳細を取得します
//width:ダイアログの幅
//height:ダイアログの高さ
function getFeature(width,height) {
	var feature=new Array();
	feature['width']=width;			//ダイアログの幅
	feature['height']=height + 4;		//ダイアログの高さ
	feature['resizable']='no';				//ダイアログはリサイズ可能
	feature['status'] = 'yes';				//ステータスバーの非表示
	feature['location'] = 'no';			//アクセスバー非表示
	return feature;
}

//QueryStringを作成します。
//contentUrl:IFRAME内に表示する画面のURL
//param:URLパラメータに設定する連想配列
function createQueryString(contentUrl,param) {
	for (i=0; i < param.length; i++) {
		if (i%2 == 0) {
			contentUrl += "&" + param[i] + "=";
		} else if (i%2 == 1) {
			contentUrl += encodeURI(param[i]);
		}
	}
	contentUrl += "&dialog=true";
	return contentUrl;
}
