<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSettingDialog.aspx.cs"
	Inherits="pjcommon_ws3Aspx_PrintSettingDialog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>印刷設定</title>
		<style type="text/css">
			#printer_list {
				width: 97px;
			}
			input{
				width:85px;
				padding:1px 10px;
			}
			div#buttonArea{
				margin-top:8px;
				margin-bottom:8px;
			}
		</style>
		<!-- link css -->
	</head>
	<body>
		<form id="form1" runat="server">
			<div style="height: 163px">
				<br />
				<asp:ListBox id="PrinterList" name="PrinterList" runat="server" Height="129px" Rows="10" Width="259px" ></asp:ListBox>
				<div id="buttonArea">
					<input type="button" id="OkButton" value="ＯＫ" onclick="returnValue=PrinterList.options[PrinterList.selectedIndex].value; window.close();" runat="server"/>
					<input type="button" id="closeButton" value="キャンセル" onclick="window.returnValue=initialValue.value; window.close();" runat="server"/>
					<input type="hidden" id="initialValue" runat="server" />
				</div>
			</div>
		</form>
	</body>
</html>
