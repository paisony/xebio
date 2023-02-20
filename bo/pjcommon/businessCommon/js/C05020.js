var MLWebComponent;
var FileAccessComponent;
// 認証キー
//var LicenseKey = "bc100c70-e68a-4442-89e5-06af4e41defe"; // AWS環境 開発用ライセンス
var LicenseKey = "d0f82074-82fb-478b-8668-46eec2cc0028"; // Nifty開発環境用ライセンス


// サーバURL
var WebServerUrl;
// ライセンスファイルURL
var LicUrl;

// ローカルファイルダウンロード先
var LocalDir = "D:\\TEMP";
var LocalLicDir = "\\Lic";
var LocalLayOutDir = "\\Layout";
var LocalDataDir = "\\DataFile";
var ESC = '\x1B';

// ブラウザからアクセス可能なWEBサーバサイトのアドレスを設定します。
WebServerUrl = location.href;
WebServerUrl = WebServerUrl.split("/").reverse().slice(2).reverse().join("/") + "/Label";
LicUrl = WebServerUrl + "/Lic/MLWebComponent.lic";

//alert(WebServerUrl);

//window.onload = function(){
//	NotifyOldComponent();
//};

//-----------------------------
// バージョン確認
//　MLWebComponentのバージョンを確認し、更新が必要な場合はダウンロードを案内します。
//-----------------------------
function NotifyOldComponent() {
	try {

		var sRequiredVersion = "Multi LABELIST Web Component, Version 5.3.0.1";

		MLWebComponent = document.getElementById("objMLWebComponent");
		FileAccessComponent = document.getElementById("objFileAccessComponent");

		if (MLWebComponent == null) {
			document.getElementById("NotifyReboot").style.display = "block";
			return;
		}

		if (MLWebComponent.Version == sRequiredVersion) {
			//document.getElementById("PrintForm").style.display = "block";
			LicAuthenticate();
			PrinterDriverList();
			return;
		}
		//alert("MLWebComponentの更新が必要です。\nダウンロードが完了したらインストーラを実行してください。");

		var yes = function () {
			location.href = WebServerUrl + "/Instllar/WebComponent-Installer-ja.exe";
		}
		var no = function () { };

		//var msg = getMessage("I103");
		var msg = "【ラベル発行機エラー】MLWebComponentの更新が必要です。ダウンロードが完了したらインストーラを実行してください。";
		if (boOpenInfoDialog(msg, yes, no) == false) {
			// いいえの場合、処理終了
			return false;
		}

		//document.getElementById("NotifyReboot").style.display = "block";
	} catch (e) {
	}
}

//-----------------------------
// ライセンス認証
//　通常はスクリプトファイルを別にして認証キーがわからない様にしてください。
//　カラープリンタレイアウトの利用にはカラープリンタ発行機能を追加したライセンスファイルが必要です。
//-----------------------------
function LicAuthenticate() {
	var LicDir;
	var result;

	LicDir = LocalDir + LocalLicDir;

	//ライセンスファイルをダウンロードする
	result = MLWebComponent.GetFile(LicUrl, LicDir, 2);
	if (result != 0) {
		boOpenErrorDialog("【ラベル発行機エラー】ライセンスファイルダウンロードエラー No." + result);
		return;
	}
	// ライセンス認証
	result = MLWebComponent.Authenticate(LicenseKey, LicDir + "\\MLWebComponent.lic");
	if (result != 0) {
		boOpenErrorDialog("【ラベル発行機エラー】ライセンス認証エラー No." + result);
		return;
	}
	//window.alert("ライセンス認証完了");
}


//-----------------------------
// プリンタドライバ名の取得
//-----------------------------
function PrinterDriverList() {
	var Result;
	var DriverNameList = new Array();
	var objDriver = document.getElementById("PrinterDriver");
	Result = MLWebComponent.GetDriverNameList(1);
	if (Result == "") {
		return;
	}
	DriverNameList = Result.split(",");
	for (i = 0; i < DriverNameList.length; i++) {
		var option = document.createElement("option");
		var text = document.createTextNode(DriverNameList[i]);
		option.appendChild(text);
		objDriver.appendChild(option);
	}
}

////-----------------------------
//// 通信パラメータの変更
////-----------------------------
//function changePrinterSetting() {
//	var objSetting = document.getElementById("PrinterSetting");
//	if(objSetting.options[objSetting.selectedIndex].text == "DRV:" || objSetting.options[objSetting.selectedIndex].text == "DRVX:"){
//		document.getElementById("SettingParam").style.display = "none";
//		document.getElementById("PrinterDriver").style.display = "block";
//	}else{
//		document.getElementById("SettingParam").style.display = "block";
//		document.getElementById("PrinterDriver").style.display = "none";
//	}
//}

//-----------------------------
// レイアウトダウンロード
//-----------------------------
function LabelLayoutDownload(layout) {
	var objLayout;
	var LayoutUrl;
	var LayoutDir;
	var result;

	LayoutUrl = WebServerUrl + "/Layout/" + layout;
	LayoutDir = LocalDir + LocalLayOutDir;

	//レイアウトファイルをダウンロードする
	result = MLWebComponent.GetFile(LayoutUrl, LayoutDir, 2);
	if (result != 0) {
		boOpenErrorDialog("【ラベル発行機エラー】レイアウトファイルダウンロードエラー No." + result);
		return;
	}
	//window.alert("レイアウトファイルダウンロード完了");
}

//-----------------------------
// データファイルダウンロード
//-----------------------------
function LabelDataDownload(filenm) {
	var objData;
	var DataUrl;
	var DataDir;
	var result;

	DataUrl = WebServerUrl + "/DataFile/" + filenm;
	//DataUrl = fileurl;
	DataDir = LocalDir + LocalDataDir;

	//データファイルをダウンロードする
	result = MLWebComponent.GetFile(DataUrl, DataDir, 2);
	if (result != 0) {
		boOpenErrorDialog("【ラベル発行機エラー】データファイルダウンロードエラー No." + result);
		return;
	}
	//window.alert("データファイルダウンロード完了");
}

//-------------------------
// ポートオープン
// 戻り値 ：[0]正常[1]失敗
//--------------------------
function PortOpen() {
	var result;
	var conf = false;
	
	while (result != 0) {
		result = MLWebComponent.OpenPort(1);
		if (result != 0) {
			conf = confirm("タイムアウトエラー(ラベル発行機の接続状態を確認して下さい。)\nリトライしますか？");
			$(document).ready(function () { sleep(10); });
			if (!conf) {
				return 1;
			}
		}
	}
	//if (document.getElementById("MessageFlg").checked) {
	//	window.alert("ポートオープン");
	//}
	return 0;
}

//-------------------------
// ポートクローズ
// 戻り値 ：[0]正常[1]失敗
//--------------------------
function PortClose() {
	var result;

	result = MLWebComponent.ClosePort();
	if (result != 0) {
		//	エラー表示不要
		//boOpenErrorDialog("【ラベル発行機エラー】ポートクローズエラー No." + result);
		return 1;
	}
	//if (document.getElementById("MessageFlg").checked) {
	//	window.alert("ポートクローズ");
	//}
	return 0;
}

//-----------------------------------
// プリンタ状態チェック
// 戻り値：0：状態取得成功、状態正常
// 　　　　1：状態取得成功、状態異常
// 　　　　2：状態取得失敗
//-----------------------------------
function StatusCheck() {
	var PrinterStatus;
	var stRet;
	var result;
	try {
		// プリンタステータスを取得する 
		stRet = MLWebComponent.GetStatus();
		PrinterStatus = stRet.charAt(2);
		// ステータス取得正常
		if (PrinterStatus == "A" || PrinterStatus == "G" || PrinterStatus == "S") {
			// ステータス正常
			return 0;
		} else {
			// ステータス異常
			//boOpenErrorDialog("プリンタステータス = " + PrinterStatus);
			return 1;
		}
	} catch (e) {
		result = (e.number & 0xffff) - 512;
		switch (result) {
			case 0: break;
			case 5: boOpenErrorDialog("【ラベル発行機エラー】ポートがオープンされていません"); break;
			case 7: boOpenErrorDialog("【ラベル発行機エラー】ステータス要求送信中にエラーが発生しました"); break;
			case 8: boOpenErrorDialog("【ラベル発行機エラー】ステータス要求送信中にタイムアウトが発生しました"); break;
			case 9: boOpenErrorDialog("【ラベル発行機エラー】ステータス受信中にエラーが発生しました"); break;
			case 10: boOpenErrorDialog("【ラベル発行機エラー】ステータス受信中にタイムアウトが発生しました"); break;
			default: boOpenErrorDialog("【ラベル発行機エラー】ステータス取得エラー No." + result); break;
		}
		return 2;
	}
}
//-------------------------
// IP編集
//-------------------------
function ipEdit(ip) {
	if (ip.length != 12) {
		return ip;
	}
	while (ip != (ip = ip.replace(/^(-?\d+)(\d{3})/, "$1.$2")));
	return ip;
}
//-------------------------
// ラベル発行
//-------------------------
function cmdPrint(ip, layoutfile, datafile) {
	//var LocalDir;

	var objLayout, objData, objSetting, objDriver;
	var result, stRet;

	//LocalDir = document.getElementById("LocalSaveFolder").value;

	// ローカルレイアウトファイルパスを指定
	MLWebComponent.LayoutFile = LocalDir + LocalLayOutDir + "\\" + layoutfile;
	// ローカルデータファイルパスを指定
	FileAccessComponent.FilePath = LocalDir + LocalDataDir + "\\" + datafile;
	FileAccessComponent.FileDataType = 1;

	// プリンタ接続先の設定
	MLWebComponent.Setting = "LAN:" + ipEdit(ip);

	if (MLWebComponent.Setting.substring(0, 4) == "USB:") {
		MLWebComponent.Protocol = 1; // ステータス4
	} else {
		MLWebComponent.Protocol = 0; // ステータス3
	}
//MLWebComponent.Protocol = 1; // ステータス4

	// タイムアウト値を設定(s) 
	MLWebComponent.Timeout = 50;

	// ポートを開く
	result = PortClose();
	result = PortOpen();
	if (result != 0) {
		return;
	}

	var command;
	var ret;

	command = '';
	command = command + ESC + 'A';		// データ送出開始指定
	command = command + ESC + 'PM2';	// 動作モード指定(2:カッタ動作（ヘッド位置）)
	command = command + ESC + 'Z';		// データ送出終了指定
	ret = sendCommand(command);
	if (ret < 0) {
		// 異常終了
		return;
	}
	
	command = '';
	command = command + ESC + 'A';		// データ送出開始指定
	command = command + ESC + 'IG0';	// センサ種指定(0:反射センサ1 （アイマーク）)
	command = command + ESC + 'Z';		// データ送出終了指定
	ret = sendCommand(command);
	if (ret < 0) {
		// 異常終了
		return;
	}

	// CSVファイルを開く
	result = FileAccessComponent.OpenFile();
	if (result != 0) {
		boOpenErrorDialog("データファイルオープンエラー No." + result);
		result = PortClose();
		return;
	}

	// ファイルのレコード数分、ループする
	var conf = true;
	while (!FileAccessComponent.EOF) {
		var rowData = FileAccessComponent.RowData;
		// メッセージが設定されている場合、メッセージ表示
		if (rowData.indexOf("MESSAGE:") >= 0) {
			var msgwk = rowData.split("\t");
			var msg = msgwk[0].replace("MESSAGE:", "");
			conf = confirm(msg);
		}
		if (conf)
		{
			if (rowData.indexOf("MESSAGE:") < 0) {
				MLWebComponent.PrnData = FileAccessComponent.RowData;
				// 通信設定がプリンタドライバ出力以外の場合ステータスチェックする
				if ((MLWebComponent.Setting.substring(0, 3) != "DRV") && (MLWebComponent.Setting.substring(0, 4) != "DRVX")) {

					var yes = function () {
						// ダイアログクローズ
						displayModal(false);
						var datalist = rowData.split(",");
						var layoutinfo = datalist(datalist.length - 1).replace("\"", "");
						// 自分を呼び出す
						setTimeout("cmdPrint('" + ip + "', '" + layoutinfo + "', '" + datafile + "');", 100);

					};
					var no = function () { };

					stRet = 1;
					var loopCnt = 1;
					while (stRet != 0) {
						// プリンタステータスをチェックする
						stRet = StatusCheck();
						// ステータスが取得できない、異常な場合は終了する
						if (stRet == 2) {
							result = PortClose();
							result = FileAccessComponent.CloseFile();
							return;
						}
						if (loopCnt > 5) {
							// 一定時間経過したらリトライの確認
							if (boOpenInfoDialog("タイムアウトエラー(ラベル発行機の接続状態を確認して下さい。)リトライしますか？", yes, no) == false) {
								//if (confirm("タイムアウトエラー(ラベル発行機の接続状態を確認して下さい。)\nリトライしますか？") == false) {
								// いいえの場合、処理終了
								result = PortClose();
								result = FileAccessComponent.CloseFile();
								return;
							}
						}
						if (loopCnt > 2) {
							// 1秒間スリープ
							sleep(1000);
						}
						loopCnt++;
					}
				}

				// 発行を行う
				result = MLWebComponent.Output();
				if (result != 0) {
					boOpenErrorDialog("【ラベル発行機エラー】発行処理エラー No." + result);
					result = PortClose();
					result = FileAccessComponent.CloseFile();
					return;
				}
			}
		}
		result = FileAccessComponent.MoveNext();
		if (result != 0) {
			boOpenErrorDialog("【ラベル発行機エラー】レコードエラー No." + result);
			result = PortClose();
			result = FileAccessComponent.CloseFile();
			return;
		}
	}

	// CSVファイルを閉じる
	result = FileAccessComponent.CloseFile();
	//if (document.getElementById("DataDelFlg").checked) {
	result = FileAccessComponent.RemoveFile();
	if (result != 0) {
		boOpenErrorDialog("【ラベル発行機エラー】データファイル削除エラー No." + result);
		result = PortClose();
		return;
	}
	//}

	// 通信ポートをクローズする
	result = PortClose();
	//if (document.getElementById("MessageFlg").checked) {
	//	window.alert("発行完了");
	//}

}
// スリープ処理
function sleep(time) {
	var d1 = new Date().getTime();
	var d2 = new Date().getTime();
	while (d2 < d1 + time) {
		d2 = new Date().getTime();
	}
	return;
}

function getSvIP(svip) {
	var wkUrl = WebServerUrl.split("/");
	wkUrl[2] = svip;
	WebServerUrl = wkUrl.join("/");
}

function sendCommand(command) {
	var RecvData;
	var BinaryCommand;
	//中略(コマンド生成) JavaScript では「¥x@@」（@は16 進数）でバイナリデータも指定可能です。
	try {
		//alert(command);
		RecvData = MLWebComponent.SendStringData(0, command, 0, '');
		return 0;
	} catch(e){
		/*
			5 ポートがオープンされていません。
			7 コマンド送信中にエラーが発生しました。
			8 コマンド送信中にタイムアウトが発生しました。
			9 応答受信中にエラーが発生しました。
			10 応答受信中にタイムアウトが発生しました。
			54 コマンド文字列が空です。
			55 カラープリンタドライバへの出力はできません。
		*/
		//alert('コマンド送信エラー[' + e + ']');
		boOpenErrorDialog("【ラベル発行機エラー】コマンド送信エラー[" + e + "]");
		return -1;
	}
}
