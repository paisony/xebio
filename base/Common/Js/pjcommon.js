// All Rights Reserved, Copyright (c) 2008-2009 FUJITSU SYSTEM SOLUTIONS
// FUJITSU SYSTEM SOLUTIONS LIMITED CONFIDENTIAL

// �J�����_�[�\��
function openCalendar(ctrlid)
{
	var dleft = window.event.clientX+10;
	var dtop = window.event.clientY+30;
	var rtn;
	// IE7
	if(typeof document.body.style.maxHeight != "undefined")
	{
	    rtn=window.open('../Common/CalendarDialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:250px;dialogHeight:251px;dialogTop:' + dtop + ';dialogLeft:' + dleft);	    
	}
	// IE6�ȉ��̃o�[�W����
	else
	{
	    rtn=window.open('../Common/CalendarDialog.html',window,'scroll:off;resizable:off;status:off;help:no;dialogWidth:255px;dialogHeight:295px;dialogTop:' + dtop + ';dialogLeft:' + dleft);	    
	}
	
	if (rtn != null)
	{
		document.getElementById(ctrlid).value = rtn;
	}
}
