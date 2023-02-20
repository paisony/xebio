// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL
// 改版履歴
// 2012/03/24 WT)Banno OT1障害対応[QA-0667]

/*
 関数名：PwdStrengthCheck(パスワード強度チェック)
 コメント：パスワード文字列の組み合わせによる安全性を評価する。

           パスワードに使用可能な文字種（パスワード用文字種）は
           半角英大文字，半角英小文字，半角数字の3種類。

 引数：inputPwd 入力パスワード

 戻り値：0 パスワードの文字長が0の時 
       1 パスワードにパスワード用文字種以外の文字が使用されている
       2 パスワードの桁数が8～10桁以外の時または、桁数に関係なく1種類の文字種が使用されている時

       3 パスワード桁数が8～10桁、かつ2種類の文字種が使用されている
       4 パスワード桁数が8～10桁、かつ3種類の文字種が使用されている
*/

function PwdStrengthCheck(inputPwd)
{
    //文字が入力されているか

	if(inputPwd.length == 0){
         return 0;
    }
    
    //不正な文字のチェック
	//if(inputPwd.match(/[^0-9a-zA-Z]/)){
    //     return 1;
    //}
    
	//パスワード文字長のチェック(6桁～8桁以外は不正とする)（ゼビオ）
	if(inputPwd.length < 6){
		//弱（桁数不足）
		return 2;
	}

	var charTypeNum = 0
	//文字種のチェック
	if(inputPwd.match(/[0-9]/)){
		charTypeNum += 1;
	}
	// --------------- 2012/03/24 WT)Banno OT障害対応[QA-667] Update Start ---------------
	if(inputPwd.match(/[A-Z]/)){
		charTypeNum += 1;
	} else {
		if(inputPwd.match(/[a-z]/)){
			charTypeNum += 1;
		}
	}
	//if(inputPwd.match(/[^0-9a-zA-Z]/)){
	//	charTypeNum += 1;
	//}
	// --------------- 2012/03/24 WT)Banno OT障害対応[QA-667] Update  End  ---------------
	
	//２文字種で強度：強（ゼビオ）
	if (charTypeNum == 1)
		return 2;
	else if (charTypeNum == 2)
		return 4;
	else if (charTypeNum >= 3)
		return 4;
	else
		return 0;
}