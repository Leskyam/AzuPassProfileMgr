<%@ Page Language="C#" AutoEventWireup="false" Inherits="AzuPassProfileMgr.clswfChangeEmail" Culture="es-MX" UICulture="es-MX" CodeBehind="change_email.aspx.cs" %><%@ Register Src="wucHeader.ascx" TagName="wucHeader" TagPrefix="uc1" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title>AzuPassProfileMgr - Cambiar mi correo-e</title><link href="estilos/main.css" rel="stylesheet" type="text/css" /></head><body><div id="wrapper"><form id="frmChangeEmail" runat="server"><table cellspacing="0" id="tbl_ChangeEmail" width="750" border="0" align="center"><tr><td><uc1:wucHeader ID="wucHeader" runat="server" /></td></tr><tr><td align="center">
<asp:Panel ID="panelChangeEmail" runat="server" DefaultButton="lnkChangeEmail">
<table id="tbl_Content" cellpadding="0" cellspacing="0" border="0" align="center">
<tr>
<td colspan="6" class="td_input_Header" align="center" style="padding: 2px 2px 2px 2px">
<label id="lblTitle" class="LblNormalBold_N" for="txtNewEmail">
Cambiar mi correo-e</label></td>
</tr>
<tr>
<td class="td_input_Header" style="width: 1px">
</td>
<td colspan="4" class="td_input_Body" height="15px">
</td>
<td width="1px" class="td_input_Header">
</td>
</tr>
<tr>
<td class="td_input_Header" style="width: 1px" align="left">
</td>
<td class="td_input_Body" width="40px" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblNewEmail" for="txtNewEmail">
<u>N</u>uevo correo-e:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtNewEmail" AccessKey="n" runat="server" CssClass="txtInput" Width="160px"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqNewEmail" runat="server" ErrorMessage="Se requiere el Nuevo correo-e." ControlToValidate="txtNewEmail" ToolTip="Se requiere el Nuevo correo-e." Display="Dynamic">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="valRegExpNewEmail" runat="server" ErrorMessage="El formato del Nuevo correo-e no es correcto." ToolTip="El formato del Nuevo correo-e no es correcto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtNewEmail">*</asp:RegularExpressionValidator></td>
<td class="td_input_Body" width="40px" align="left">
</td>
<td width="1px" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td class="td_input_Header" style="width: 1px" align="left">
</td>
<td class="td_input_Body" width="40px" align="left">
</td>
<td colspan="2" class="td_input_Body" align="left" style="padding: 2px 2px 2px 2px">
<asp:ValidationSummary ID="valSumChangeEmail" runat="server" Width="260px" />
</td>
<td class="td_input_Body" width="40px" align="left">
</td>
<td width="1px" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td class="td_input_Header" style="width: 1px">
</td>
<td class="td_input_Body" width="40px">
</td>
<td colspan="2" class="td_input_Body" align="right" style="padding: 5px 2px 2px 2px">
<asp:LinkButton ID="lnkChangeEmail" runat="server" OnClick="lnkChangeEmail_Click">Cambiar correo-e</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
</td>
<td class="td_input_Body" width="40px">
</td>
<td width="1px" class="td_input_Header">
</td>
</tr>
<tr>
<td class="td_input_Header" style="width: 1px">
</td>
<td colspan="4" class="td_input_Body" height="10px">
</td>
<td width="1px" class="td_input_Header">
</td>
</tr>
<tr>
<td colspan="6" class="td_input_Header">
</td>
</tr>
</table>
</asp:Panel></td></tr></table></form></div></body></html><script language="javascript" type="text/javascript">
if(document.getElementById('txtNewEmail')!=null){document.getElementById('txtNewEmail').focus();}
</script>
