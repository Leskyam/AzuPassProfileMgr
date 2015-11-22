<%@ Page Language="C#" AutoEventWireup="false" Inherits="AzuPassProfileMgr.clswfChangePasswd"
  Culture="es-MX" UICulture="es-MX" CodeBehind="change_passwd.aspx.cs" %><%@ Register Src="wucHeader.ascx" TagName="wucHeader" TagPrefix="uc1" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title>AzuPassProfileMgr - Cambiar mi contrasea</title><link href="estilos/main.css" rel="stylesheet" type="text/css" /></head><body><div id="wrapper"><form id="frmChangePasswd" runat="server"><table cellspacing="0" id="tbl_ChangePasswd" width="750" border="0" align="center"><thead><tr><td><uc1:wucHeader ID="wucHeader" runat="server" /></td></tr></thead><tr><td align="center">
<asp:Panel ID="panelChangePasswd" runat="server" DefaultButton="lnkChangePasswd">
<table id="tbl_Content" cellpadding="0" cellspacing="0" border="0" align="center">
<tr>
<td colspan="6" class="td_input_Header" align="center" style="padding: 2px 2px 2px 2px">
<label id="lblTitle" class="LblNormalBold_N" for="txtNombre">
Cambiar mi contrasea</label>
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
<td class="td_input_Header" style="width: 1px" align="left">
</td>
<td class="td_input_Body" width="40px" align="left">
</td>
<td valign="top" nowrap="nowrap" class="td_input_Body" style="padding: 5px 2px 2px 2px"
                  align="left">
<label id="lblCurrentPasswd" for="txtCurrentPasswd">
Contrasea <u>a</u>ctual:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtCurrentPasswd" AccessKey="a" runat="server" CssClass="txtInput"
                    Width="130px" TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqCurrentPasswd" runat="server" ErrorMessage="Se requiere la Contrasea actual."
                    ControlToValidate="txtCurrentPasswd" ToolTip="Se requiere la Contrasea actual.">*</asp:RequiredFieldValidator>
</td>
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
<td valign="top" nowrap="nowrap" class="td_input_Body" style="padding: 5px 2px 2px 2px"
                  align="left">
<label id="lblNewPasswd" for="txtNewPasswd">
Contrasea <u>n</u>ueva:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtNewPasswd" AccessKey="n" runat="server" CssClass="txtInput" Width="130px"
                    TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqNewPasswd" runat="server" ErrorMessage="Se requiere la Contrasea nueva."
                    ControlToValidate="txtNewPasswd" ToolTip="Se requiere la Contrasea nueva." Display="Dynamic">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="valRegExpNewPasswd" runat="server" ErrorMessage="La Contrasea nueva no cumple con los requerimientos esperados."
                    ToolTip="La Contrasea nueva no cumple con los requerimientos esperados." ValidationExpression="[\w\*\+\?\(\)\|\\\!\.\[\]\^\{\}\$\#\/\-_]"
                    ControlToValidate="txtNewPasswd">*</asp:RegularExpressionValidator>
</td>
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
<td valign="top" nowrap="nowrap" class="td_input_Body" style="padding: 5px 2px 2px 2px"
                  align="left">
<label id="lblConfirmNewPasswd" for="txtConfirmNewPasswd">
<u>C</u>onfirmar nueva:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtConfirmNewPasswd" AccessKey="F" runat="server" CssClass="txtInput"
                    Width="130px" TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqConfirmNewPasswd" runat="server" ControlToValidate="txtConfirmNewPasswd"
                    Display="Dynamic" ErrorMessage="Se requiere Confirmar nueva." ToolTip="Se requiere Confirmar nueva.">*</asp:RequiredFieldValidator>
<asp:CompareValidator ID="valCompConfirmPasswd" runat="server" ControlToCompare="txtNewPasswd"
                    ControlToValidate="txtConfirmNewPasswd" ErrorMessage="La Contrasea nueva y la confirmacin no coinciden."
                    ToolTip="La Contrasea nueva y la confirmacin no coinciden." Display="Dynamic">*</asp:CompareValidator>
</td>
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
<asp:ValidationSummary ID="valSumChangePasswd" runat="server" Width="250px" />
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
<asp:LinkButton ID="lnkChangePasswd" runat="server" OnClick="lnkChangePasswd_Click">Cambiar contrasea</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
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
  if (document.getElementById('txtCurrentPasswd') != null) { document.getElementById('txtCurrentPasswd').focus(); }
</script>

