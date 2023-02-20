<%@ Register Assembly="com.xebio.bo.Common" Namespace="Common.Advanced.Web.Control" TagPrefix="adv" %>
<%@ Import namespace="Common.Advanced.Codecondition.Code.Util" %>
<%@ Page language="c#" Inherits="Pjcommon.Code.CodeCOGPage" CodeFile="CodeCOG.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head>
		<title>
			<%# WindowTitle %>
		</title>
		<adv:ContentType id="ContentType1" runat="server" />
		<meta http-equiv="Cache-Control" content="no-cache"/>
		<meta http-equiv="Pragma" content="no-cache"/>
		<meta http-equiv="Expires" content="-1"/>
        <script type="text/javascript" src="Code.js" charset="UTF-8"></script>
        
		
		<%-- キー制御 --%>
        <script type="text/javascript" src="../js/KeySafe.js" charset="UTF-8"></script>
        
		<script type="text/javascript">
    	<!--
		// 検索結果の出力
		<%# ResultJS %>
		<%# MappingJS %>
		
	
		
		var icogMsg001 = "<%# IcogMsg001 %>";
	
        meisainumber="<%# codeContext.Command.MNo %>";
        levelid="<%# codeContext.Command.MID %>"
        codeId="<%# codeContext.CodeID %>";
        ItemId="<%# codeContext.Command.ItemID %>";
        mStartIdx="<%# codeContext.Command.MStartIndex %>";
        
		//共通ファンクションの定義
		String.prototype.Trim = function(){
			return this.replace(/(^\s*)|(\s*$)/g,"");
		}
		function SearchParentForm(iformid){
		    try {
			    if(window.opener.document.forms[iformid] != null)
				    return window.opener.document.forms[iformid];
			    else if(window.opener.document.forms[iformid] != null)
				    return window.opener.document.forms[iformid];
			    else
				    return window.opener.document.forms[0];
			} catch (e) {
        	    //親画面がなくなっている可能性があるため、例外をキャッチしたら何もせずに画面を閉じる
			    window.close();
			    return false;
			}
		}

	    function getKeyItem(){
		    var iformid ="<%# codeContext.Command.FormID %>";
		    var iTarget;
		    var iparIdx;
		    var iparLevelid;
		    var cogpar;
		    var iExtData;
		    var itemValue="";
		    var extItemID="<%#ExtItemID%>";
		    var parentForm = SearchParentForm(iformid);

    	
		    var cogpar;
		    var a;
		    var kk = "";
    	
		    var itemname="<%#KeyItemName%>";
		    itemname = itemname.split(",");
    	
    	    try {
		        for(var i=0; i<itemname.length; i++) {
			        if(levelid!=""&&meisainumber!="0"){
				        cogpar=GetMeisaiItemName(itemname[i],levelid.toUpperCase(),meisainumber);
			        }
        	
			        if(levelid!=""&&meisainumber!="0") {
				        try {
					        kk+=eval("window.opener.document.forms[0]."+cogpar).value;
				        } catch(e) {
					        alert("Err:when get your input value from "+cogpar);
				        }
			        } else {
				        try {
					        kk+=eval("window.opener.document.forms[0]."+itemname[i]+"").value;
				        } catch(e) {
					        alert("Err:when get your input value from "+cogpar);
				        }
			        }
			        if (i < itemname.length-1) {
				        kk+=",";
			        }
		        }
        		
	            if(extItemID.length>0){
		            itemname=extItemID.split(",");
		            for(var i=0; i<itemname.length; i++){
			            iparIdx=window.parent.opener.getAdvControlIdxFromName(itemname[i]);
			            if(iparIdx>-1){	
				            iparLevelid=window.parent.opener.getItemInfo_std(iparIdx,"ADVIT_LEVEL");
				            if(iparLevelid!=""&&meisainumber!="0"){
					            cogpar=GetMeisaiItemName(itemname[i],levelid.toUpperCase(),meisainumber);
					            try{
						            iTarget=eval("parentForm."+cogpar);
					            }
					            catch(e){
						            alert("Err:when get your input value from "+itemname[i]);
					            }
				            }else{
					            try{
						            iTarget=eval("parentForm."+itemname[i]+"");
					            }
					            catch(e){
						            alert("Err:when get your input value from "+itemname[i]);
					            }
				            }
			            }else{
				            try{
					            iTarget=eval("parentForm."+itemname[i]+"");
				            }
				            catch(e){
					            alert("Err:when get your input value from "+cogpar);
				            }
			            }
			            iExtData="";
			            if(iTarget!=null){
				            if(iTarget.type!=null){
					            if(iTarget.type=="checkbox"){
						            if(iTarget.checked) iExtData="1"; else iExtData="0";
					            }else if(iTarget.type=="select-one"||iTarget.type=="select-multiple"){
						            for (var i=0;i<iTarget.options.length;i++){
							            if(iTarget.options[i].selected){
								            iExtData=iTarget.options[i].value;
								            break;
							            }
						            }
					            }else{
						            iExtData = iTarget.value;
					            }
				            }else{
					            if(iTarget.type==null&&iTarget[0].type=="radio"){
						            for (var i=0;i<iTarget.length;i++){
							            if(iTarget[i].checked)
								            iExtData = iTarget[i].value;
						            }
					            }else{
						            iExtData="";
					            }
				            }
			            }
			            if(iExtData!=null){
				            if(iExtData.length==0){
					            iExtData = "<%# CodeConstantUtil.CODE_TMPDATA_SEPARATOR %>";
				            }
				            if(i != itemname.length-1){
					            iExtData += "<%# CodeConstantUtil.CODE_DBINFO_SEPARATOR %>";
				            }
				            itemValue += iExtData;
			            }
		            }
            		
	            }
	        } catch (e) {
        	    //親画面がなくなっている可能性があるため、例外をキャッチしたら何もせずに画面を閉じる
			    window.close();
			    return false;
	        }
	        var form = document.getElementById("loading");
		    form.extItemValue.value = itemValue;
		    form.clientValue.value = kk;
		    form.submit();
		    return false;
	    }

	    function notFound(keyBlank){
    		
    		if (!keyBlank) {
    		    alert(icogMsg001);
		    }
		    //window.close();
    		
		    var searchByItem;
		    var iparIdx;
		    var iparType;
    		
		    searchByItem = "<%#KeyItemName%>";
    	
    	    try {
		        //Clear the data
		        for(i = 0; i < mapping.length; i++) {
			        iparIdx=window.parent.opener.getAdvControlIdxFromName(mapping[i][1].toUpperCase().Trim());
			        iparType=window.parent.opener.getItemInfo_std(iparIdx,"ADVIT_TYPE");
			        if(iparType==null) iparType="";
			        if(parseInt(meisainumber)!=0) {
				        try {
					        if(mapping[i][1].Trim()!=searchByItem.Trim()) {
						        if(iparType=="TXR")
							        SetValue(GetMeisaiTarget(meisainumber,levelid.toUpperCase(),mapping[i][1].Trim()), "");
					        }
				        } catch(e) { 
					        alert("Err:When set value to "+GetMeisaiItemName(mapping[i][1],levelid.toUpperCase(),meisainumber));
				        }
			        } else {
				        if(mapping[i][1].Trim()+""!=searchByItem.Trim()) {
					        try {
						        if(iparType=="TXR")
							        SetValue(eval("window.opener.document.forms[0]."+mapping[i][1].Trim()), "");
					        } catch(e) {
						        alert("Err:When set value to "+mapping[i][1]);
					        }
				        }					
			        }
		        }
        	
		        //Set focus
		        if(parseInt(meisainumber)!=0) {
			        eval("window.opener.document.forms[0]."+GetMeisaiItemName(searchByItem,levelid.toUpperCase(),meisainumber)).focus();
		        } else {
			        eval("window.opener.document.forms[0]."+searchByItem+"").focus();
		        }
		    } catch (e) {
        	    //親画面がなくなっている可能性があるため、例外をキャッチしたら何もせずに画面を閉じる
		    }
    		
		    window.close();
		    return false;
	    }

	    function gofinish(){
	        SetParentWin(resultValues);
	    }
	
        //-->
		</script>
	</head>
	<body id="body" runat="server">
		<form id="loading" method="post" runat="server" onprerender="CodeCOG_PreRender">
			<input type="hidden" name="extItemValue" id="extItemValue" runat="server"/> <input type="hidden" name="clientValue" id="clientValue" runat="server"/>
			<img src="<%# Url %>/pjcommon/images/hourglass.gif" alt="お待ちください。" align="left" height="48" width="28"/>
			&nbsp;&nbsp;<asp:Label id="WaitMessage" runat="server" Font-Size="Medium" Font-Bold="True">しばらくお待ちください。</asp:Label><br/>
			<br/>
			&nbsp;&nbsp;<asp:Label id="DataAccessMessage" runat="server" ForeColor="teal" Font-Size="X-Small">データベースアクセス中です。</asp:Label>
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
