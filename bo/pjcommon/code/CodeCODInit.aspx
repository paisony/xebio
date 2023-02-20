<%@ Register Assembly="com.xebio.bo.Common" Namespace="Common.Advanced.Web.Control" TagPrefix="adv" %>
<%@ Import namespace="Common.Advanced.Codecondition.Code.Util" %>
<%@ Page language="c#" Inherits="Pjcommon.Code.CodeCODInitPage" CodeFile="CodeCODInit.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html lang="ja">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="Content-Style-Type" content="text/css">
		<title>
			<%# WindowTitle %>
		</title>
		<meta http-equiv="Cache-Control" content="no-cache"/>
		<meta http-equiv="Pragma" content="no-cache"/>
		<meta http-equiv="Expires" content="-1"/>
        <script type="text/javascript" src="Code.js" charset="UTF-8"></script>
        <script type="text/javascript" src="../boJs/jquery.min.js" charset="UTF-8"></script>
        
		<%-- キー制御 --%>
        <script type="text/javascript" src="../js/KeySafe.js" charset="UTF-8"></script>
        
        <%-- ファンクションキー制御 --%>
        <script type="text/javascript" src="./Code_event_n.js" charset="UTF-8"></script>	

		
		<script type="text/javascript">
	<!--
    //In order to get the client input value
    var iformid ="<%#formID%>";
            var iTarget;
            var iparIdx;
            var iparLevelid;
            var cogpar;
            var kk;
            var itemValue;
            var extItemID;
            var parentForm = SearchParentForm(iformid);
            itemValue = "";
            extItemID ="<%#extItemID%>";

            if (extItemID.length > 0) {

                meisainumber ="<%#meisaiNumber%>";
		mStartIdx="<%#mStartIndex %>";
		levelno="<%#levelid%>";
		itemname=extItemID.split(",");
		for(var i=0; i<itemname.length; i++){
		    try {
                iparIdx = window.parent.opener.getAdvControlIdxFromName(itemname[i]);
			    if(iparIdx>-1){	
                    iparLevelid = window.parent.opener.getItemInfo_std(iparIdx,"ADVIT_LEVEL");
				    if(iparLevelid!=""&&meisainumber!="0"){
					    cogpar=GetMeisaiItemName(itemname[i],levelno.toUpperCase(),meisainumber);
					    try{
                            iTarget = eval("parentForm."+cogpar);
					    }
					    catch(e){
						    alert("Err:when get your input value from "+cogpar);
					    }
				    }else{
					    try{
                            iTarget = eval("parentForm."+itemname[i]+"");
					    }
					    catch(e){
						    alert("Err:when get your input value from "+cogpar);
					    }
				    }
			    }else{
				    try{
                        iTarget = eval("parentForm."+itemname[i]+"");
				    }
				    catch(e){
					    alert("Err:when get your input value from "+cogpar);
				    }
			    }
			    kk="";
			    if(iTarget!=null){
				    if(iTarget.type!=null){
					    if(iTarget.type=="checkbox"){
						    if(iTarget.checked) {kk="1";} else {kk="0";}
					    }else if(iTarget.type=="select-one"||iTarget.type=="select-multiple"){
                            for (var i = 0; i < iTarget.options.length; i++) {
                                if (iTarget.options[i].selected) {
                                    kk = iTarget.options[i].value;
								    break;
							    }
						    }
					    }else{
						    kk = iTarget.value;
					    }
				    }else{
					    if(iTarget.type==null&&iTarget[0].type=="radio"){
                            for (var i = 0; i < iTarget.length; i++) {
                                if (iTarget[i].checked) {
                                    kk = iTarget[i].value;
                                }
						    }
					    }else{
						    kk="";
					    }
				    }
			    }
			    if(kk!=null){
				    if(kk.length==0){
					    kk = "<%# CodeConstantUtil.CODE_TMPDATA_SEPARATOR %>";
				    }
				    if(i != itemname.length-1){
					    kk += "<%# CodeConstantUtil.CODE_DBINFO_SEPARATOR %>";
                            }
                            itemValue += kk;
                        }
                    } catch (e) {
                        //親画面がなくなっている可能性があるため、例外をキャッチしたら何もせずに画面を閉じる
                        window.close();
                    }
                }
            }

            function SearchParentForm(iformid) {
                try {
                    if (window.opener.document.forms[iformid] != null)
                        return window.opener.document.forms[iformid];
                    else if (window.opener.document.forms[iformid] != null)
                        return window.opener.document.forms[iformid];
                    else
                        return window.opener.document.forms[0];
                } catch (e) {
                    //親画面がなくなっている可能性があるため、例外をキャッチしたら何もせずに画面を閉じる
                    window.close();
                    return false;
                }
            }
            function gosubmit() {

                document.getElementById("loading").extItemValue.value = itemValue;
                document.getElementById("loading").submit();
                return false;
            }
            -->
        </script>
	</head>
	<body onload="return gosubmit();">
		<form id="loading" runat="server" method="post" onprerender="CodeCODInit_PreRender">
			<input type="hidden" name="extItemValue" id="extItemValue" runat="server"/> <img src="<%# url %>/pjcommon/images/hourglass.gif" alt="お待ちください。" align="left" height="48" width="32"/>
			&nbsp;&nbsp;<asp:Label id="WaitMessage" runat="server" Font-Size="Medium" Font-Bold="True">しばらくお待ちください。</asp:Label><br/>
			<br/>
			&nbsp;&nbsp;
			<asp:Label id="DataAccessMessage" runat="server" ForeColor="teal" Font-Size="X-Small">データベースアクセス中です。</asp:Label>
			<br/>
			<br/>
			<br/>
			<br/>
			<br/>
			<br/>
			<br/>
		</form>
	</body>
</html>