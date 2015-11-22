<%@ Control Language="C#" AutoEventWireup="false" Inherits="AzuPassProfileMgr.wucLogin"
  CodeBehind="wucLogin.ascx.cs" %>
<asp:Panel ID="panelLogOn" runat="server" DefaultButton="btnLogIn">
  <table cellspacing="0" cellpadding="1" id="tbl_LogOn" align="right" border="0">
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td colspan="2" align="center" bgcolor="#e6e2d8" style="padding: 2px 2px 2px 2px">
        <label class="LblNormalBold_N" for="txtEmail">
          Iniciar sesi&oacute;n</label>
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3" style="padding: 0px 5px 2px 5px">
        <label class="LblNormal_N" for="txtEmail" title="Servicios de identificación de usuarios que se emplean.">
          Servicios:</label>
      </td>
      <td align="left" bgcolor="#f7f6f3" style="padding: 3px 5px 2px 5px">
        <asp:Image ID="imgAzuPassLogo" runat="server" Height="20" Width="40" BorderStyle="None"
          AlternateText="AzuPass" ToolTip="AzuPass" />
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3">
        <label class="LblNormal_N" for="txtEmail" style="padding: 0px 5px 2px 5px">
          Correo-<u>e</u>:</label>
      </td>
      <td nowrap="nowrap" bgcolor="#f7f6f3" style="padding: 0px 5px 2px 5px">
        <asp:TextBox ID="txtEmail" AccessKey="e" runat="server" CssClass="txtInput" Width="200px"
          AutoCompleteType="Email"></asp:TextBox><asp:RequiredFieldValidator ID="valReqEmail"
            runat="server" ControlToValidate="txtEmail" ErrorMessage="Se requiere el Correo-e."
            Display="Dynamic">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="valRegExEmail"
              runat="server" ControlToValidate="txtEmail" ErrorMessage="Correo-e no tiene el formato correcto."
              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">*</asp:RegularExpressionValidator>
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3">
      </td>
      <td nowrap="nowrap" bgcolor="#f7f6f3" style="text-align: left; padding: 0px 5px 2px 5px">
        (pedro.perez@azcuba.cu)
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3">
      </td>
      <td nowrap="nowrap" bgcolor="#f7f6f3" style="padding: 0px 5px 2px 5px">
        &nbsp;
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3" style="padding: 0px 5px 2px 5px">
        <label class="LblNormal_N" for="txtPasswd">
          <u>C</u>ontrase&ntilde;a:</label>
      </td>
      <td nowrap="nowrap" style="background-color: #f7f6f3; padding: 0px 5px 2px 5px">
        <asp:TextBox ID="txtPasswd" AccessKey="C" runat="server" CssClass="txtInput" Width="200px"
          TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="valReqPasswd" runat="server"
            ControlToValidate="txtPasswd" ErrorMessage="Se requiere la Contrase&ntilde;a."
            Display="Dynamic">*</asp:RequiredFieldValidator>
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3">
      </td>
      <td nowrap="nowrap" bgcolor="#f7f6f3" style="text-align: left; padding: 0px 5px 2px 5px">
        <a href="resend_passwd.aspx" tabindex="-1" target="_self" title="Utilice este v&iacute;nculo para que el sistema le reenv&iacute;e su contrase&ntilde;a.">
          &iquest;Ha olvidado la contrase&ntilde;a&#63;</a>
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3">
      </td>
      <td nowrap="nowrap" bgcolor="#f7f6f3" style="padding: 0px 5px 2px 5px">
        &nbsp;
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td colspan="2" align="left" bgcolor="#f7f6f3" style="padding: 0px 2px 2px 2px">
        <asp:ValidationSummary ID="valSumLogin" runat="server" />
        <span id="spLogOnNotification" runat="server"></span>
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td colspan="2" align="right" valign="middle" bgcolor="#f7f6f3" style="padding: 5px 5px 5px 5px">
        <a href="register.aspx" tabindex="-1" target="_self" title="Crear un nuevo registro en AzuPass.">
          Registrarse</a>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogIn" runat="server" Text="Iniciar sesión" CssClass="ButtonInput"
          OnClick="btnLogIn_Click" />&nbsp;
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td width="1" bgcolor="#e6e2d8">
      </td>
      <td bgcolor="#f7f6f3">
      </td>
      <td nowrap="nowrap" bgcolor="#f7f6f3" style="padding: 0px 5px 2px 5px">
        &nbsp;
      </td>
      <td bgcolor="#e6e2d8" style="width: 1px">
      </td>
    </tr>
    <tr>
      <td>
      </td>
      <td height="1" colspan="4" bgcolor="#e6e2d8">
      </td>
    </tr>
  </table>
</asp:Panel>
<asp:Panel ID="panelFavoritos" runat="server">
  <table cellspacing="0" cellpadding="1" id="tbl_Favoritos" align="right" border="0">
    <tr>
      <td>
      </td>
      <td align="left" nowrap="nowrap" width="300px">
        <span id="spFavoritos" runat="server"></span>
      </td>
      <td width="1">
      </td>
    </tr>
  </table>
</asp:Panel>
