<%@ Page Language="C#" AutoEventWireup="false" Inherits="AzuPassProfileMgr.clswfResendPasswd"
  Culture="es-MX" UICulture="es-MX" CodeBehind="resend_passwd.aspx.cs" %><%@ Register Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
  Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %><%@ Register Src="wucHeader.ascx" TagName="wucHeader" TagPrefix="uc1" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title>AzuPassProfileMgr - Olvid&eacute; mi contrase&ntilde;a</title><link href="estilos/main.css" rel="stylesheet" type="text/css" /><meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type" /></head><body><div id="wrapper"><form id="frmResendPasswd" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager><ajaxToolkit:NoBot ID="NoBotResendPasswd" runat="server" OnGenerateChallengeAndResponse="NoBotResnedPasswd_CustomChallengeResponse"
      ResponseMinimumDelaySeconds="3" CutoffWindowSeconds="60" CutoffMaximumInstances="5" /><table cellspacing="0" id="tbl_ResendPasswd" width="750" border="0" align="center"><tr><td><uc1:wucHeader ID="wucHeader" runat="server" /></td></tr><tr><td align="center">
<asp:Panel ID="panelResendPasswd" runat="server" DefaultButton="btnResendPasswd">
<table id="tbl_Content" cellpadding="0" cellspacing="0" border="0" align="center">
<tr>
<td colspan="6" class="td_input_Header" align="center" style="padding: 2px 2px 2px 2px">
<label id="lblTitle" class="LblNormalBold_N" for="txtEmail">
Reenviarme mensaje de bienvenida</label>
</td>
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
<td class="td_input_Header" style="width: 1px">
</td>
<td class="td_input_Body" width="40px">
</td>
<td valign="top" nowrap="nowrap" class="td_input_Body" style="padding: 5px 2px 2px 2px">
<label id="lblEmail" for="txtEmail">
Correo-<u>e</u>:
</label>
</td>
<td valign="top" nowrap="nowrap" class="td_input_Body" style="padding: 5px 2px 2px 2px">
<asp:TextBox ID="txtEmail" AccessKey="e" runat="server" CssClass="txtInput" Width="200px"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqEmail" runat="server" ErrorMessage="Se requiere el Correo-e."
                    ControlToValidate="txtEmail" ToolTip="Se requiere el Correo-e." Display="Dynamic">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="valRegExpEmail" runat="server" ErrorMessage="El formato del Correo-e no es correcto."
                    ToolTip="El formato del Correo-e no es correcto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail">*</asp:RegularExpressionValidator>
</td>
<td class="td_input_Body" width="40px">
</td>
<td width="1px" class="td_input_Header">
</td>
</tr>
<tr>
<td class="td_input_Header" style="width: 1px">
</td>
<td class="td_input_Body" width="40px">
</td>
<td colspan="2" class="td_input_Body" align="left" style="padding: 2px 2px 2px 2px">
<asp:ValidationSummary ID="valSumResendPasswd" runat="server" Width="225px" />
</td>
<td class="td_input_Body" width="40px">
</td>
<td width="1px" class="td_input_Header">
</td>
</tr>
<tr>
<td class="td_input_Header" style="width: 1px">
</td>
<td class="td_input_Body" width="40px">
</td>
<td colspan="2" class="td_input_Body" align="right" style="padding: 5px 2px 2px 2px">
<asp:Button ID="btnResendPasswd" CssClass="ButtonInput" runat="server" OnClick="btnResendPasswd_Click"
                    Text="Enviar contrasea" />&nbsp;&nbsp;&nbsp;&nbsp;
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
  if (document.getElementById('txtEmail') != null) { document.getElementById('txtEmail').focus(); }
</script>

