<%@ Page Language="C#" AutoEventWireup="false" Inherits="AzuPassProfileMgr.clswfRegister"
  Culture="es-MX" UICulture="es-MX" CodeBehind="register.aspx.cs" %><%@ Register Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
  Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %><%@ Register Src="wucHeader.ascx" TagName="wucHeader" TagPrefix="uc1" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"><html xmlns="http://www.w3.org/1999/xhtml" lang="es-mx"><head runat="server"><title>AzuPassProfileMgr - Registrarme</title><link href="estilos/main.css" rel="stylesheet" type="text/css" /><meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type" /></head><body><div id="wrapper"><form id="frmRegister" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager><ajaxToolkit:NoBot ID="NoBotRegister" runat="server" OnGenerateChallengeAndResponse="NoBotRegister_CustomChallengeResponse"
      ResponseMinimumDelaySeconds="5" CutoffWindowSeconds="60" 
      CutoffMaximumInstances="5" /><table cellspacing="0" id="tbl_Register" width="750" border="0" align="center"><tr><td><uc1:wucHeader ID="wucHeader" runat="server" /></td></tr><tr><td align="center">
<asp:Panel ID="panelRegister" runat="server" DefaultButton="btnRegister">
<table id="tbl_Content" cellpadding="0" cellspacing="0" border="0" align="center">
<tr>
<td colspan="6" class="td_input_Header" align="center" style="padding: 2px 2px 2px 2px">
<label class="LblNormalBold_N" for="txtNombre">
Datos personales para nuevo registro</label>
</td>
</tr>
<tr>
<td width="1" class="td_input_Header">
</td>
<td colspan="4" class="td_input_Body" height="15">
</td>
<td width="1" class="td_input_Header">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblNombre" for="txtNombre">
* <u>N</u>ombre:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtNombre" AccessKey="N" runat="server" CssClass="txtInput" Width="160px"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqNombre" runat="server" ErrorMessage="Se requiere el Nombre."
                    ControlToValidate="txtNombre" ToolTip="Se requiere el Nombre.">*</asp:RequiredFieldValidator>
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblApellidos" for="txtApellidos">
* <u>A</u>pellidos:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtApellidos" AccessKey="A" runat="server" CssClass="txtInput" Width="160px"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqApellidos" runat="server" ErrorMessage="Se requieren los Apellidos."
                    ControlToValidate="txtApellidos" ToolTip="Se requieren los Apellidos.">*</asp:RequiredFieldValidator>
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblEmail" for="txtEmail">
* Correo-<u>e:</u>
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtEmail" AccessKey="e" runat="server" CssClass="txtInput" Width="160px"></asp:TextBox>
<asp:RequiredFieldValidator ID="valReqEmail" runat="server" ErrorMessage="Se requiere el Correo-e."
                    ControlToValidate="txtEmail" Display="Dynamic" ToolTip="Se requiere el Correo-e.">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="valRegExEmail" runat="server" ErrorMessage="El formato de Correo-e no es correcto."
                    Display="Dynamic" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ToolTip="El formato de Correo-e no es correcto.">*</asp:RegularExpressionValidator>
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
              
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblFechaNac" for="txtFechaNac">
* <u>F</u>echa de nac.
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtFechaNac" AccessKey="F" runat="server" CssClass="txtInput" Width="160px"></asp:TextBox>
<ajaxToolkit:CalendarExtender CssClass="MyCalendar" ID="calendarFechaNac" runat="server"
                    FirstDayOfWeek="Monday" TargetControlID="txtFechaNac"></ajaxToolkit:CalendarExtender>
<asp:RequiredFieldValidator ID="valReqFechaNac" runat="server" ControlToValidate="txtFechaNac"
                    Display="Dynamic" ErrorMessage="Se requiere la Fecha de nac." ToolTip="Se requiere la Fecha de nac.">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="valRegExFechaNac" runat="server" ControlToValidate="txtFechaNac"
                    Display="Dynamic" ErrorMessage="Fecha de nac. no tiene el formato correcto." ValidationExpression="\d{2}(/\d{2})(/\d{4})?"
                    ToolTip="Fecha de nac. no tiene el formato correcto.">*</asp:RegularExpressionValidator>
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblSexo" for="radioSexo">
* <u>S</u>exo:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:RadioButtonList ID="radioSexo" runat="server" RepeatDirection="Horizontal" CssClass="txtInput"
                    AccessKey="S" RepeatLayout="Flow">
<asp:ListItem Value="F" Selected="True">Femenino</asp:ListItem>
<asp:ListItem Value="M">Masculino</asp:ListItem>
</asp:RadioButtonList>
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblCatOcupacional" for="cboCatOcupacional">
* <u>C</u>at. Ocupacional:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:DropDownList ID="cboCatOcupacional" runat="server" CssClass="txtInput" AccessKey="C">
</asp:DropDownList>
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<label id="lblIntereses" for="txtIntereses">
<u>I</u>ntereses:
</label>
</td>
<td valign="top" class="td_input_Body" style="padding: 5px 2px 2px 2px" align="left">
<asp:TextBox ID="txtIntereses" runat="server" TextMode="MultiLine" CssClass="txtInput"
                    AccessKey="I" Height="50px" Width="185px"></asp:TextBox>
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="left">
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td colspan="2" class="td_input_Body" align="left" style="width: 200px; padding: 2px 2px 2px 2px">
<asp:ValidationSummary ID="valSumRegister" runat="server" />
</td>
<td class="td_input_Body" width="40" align="left">
</td>
<td width="1" class="td_input_Header" align="left">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header" align="right">
</td>
<td class="td_input_Body" width="40" align="right">
</td>
<td colspan="2" class="td_input_Body" align="right" style="padding: 5px 2px 2px 2px">
<asp:Button ID="btnRegister" runat="server" CssClass="ButtonInput" OnClick="btnRegister_Click" Text="Registrarme" />
</td>
<td class="td_input_Body" width="40" align="right">
</td>
<td width="1" class="td_input_Header" align="right">
</td>
</tr>
<tr>
<td width="1" class="td_input_Header">
</td>
<td colspan="4" class="td_input_Body" height="10">
</td>
<td width="1" class="td_input_Header">
</td>
</tr>
<tr>
<td colspan="6" class="td_input_Header">
</td>
</tr>
</table>
</asp:Panel></td></tr></table></form></div></body></html><script language="javascript" type="text/javascript">
  if (document.getElementById('txtNombre') != null) { document.getElementById('txtNombre').focus(); }
</script>

