<%@ Control Language="C#" AutoEventWireup="false" Inherits="AzuPassProfileMgr.wucHeader" CodeBehind="wucHeader.ascx.cs" %>
<table cellpadding="3" cellspacing="0" border="0" width="100%">
	<tr>
		<td id="td_HeaderLeft" nowrap="nowrap" align="left" width="50%">
			<asp:Label ID="lblAppFullName" runat="server" Text="lblAppFullName" CssClass="LblAppTitle_A"></asp:Label></td>
		<td id="td_HeaderRight" nowrap="nowrap" align="right" width="50%" style="background-color: #336699">
			<asp:Label ID="lblAppVersion" runat="server" Text="lblAppVersion" CssClass="LblTiny_B"></asp:Label></td>
	</tr>
	<tr>
		<td id="td_Visitas" nowrap="nowrap" align="left" style="background-color: #336699" width="50%">
			<span id="spVisitas" runat="server" class="LblTiny_B"></span>
		</td>
		<td nowrap="nowrap" align="right" style="background-color: #336699" width="50%">
			<span id="spFecha" runat="server" class="LblTiny_B"></span>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="padding: 0px 0px 0px 0px" align="left">
			<span id="spWelcomeBar" runat="server" class="spNotifyInformation"></span>
		</td>
	</tr>
	<tr>
		<td colspan="2" nowrap="nowrap" style="padding: 3px 3px 3px 3px">
			<table id="tbl_NavBar" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td align="center" width="100%">
						<span id="spNavBar" runat="server" style="width:100%;text-align: center"></span>
					</td>
					<td align="right">
						<a id="lnkAdministrar" href="administrar.aspx" tabindex="-1" target="_self" runat="server">Administrar</a>&nbsp;&nbsp;<asp:LinkButton ID="lnkLogOut" runat="server" Text="Salir" OnClick="lnkLogOut_Click" CausesValidation="False"></asp:LinkButton>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td colspan="2" align="left">
			<span id="spNotificationZone" runat="server"></span>
		</td>
	</tr>
</table>

<script language="javascript" type="text/javascript">
	// Imagen curva de fondo que acompaña al texto de la versión.
	document.getElementById('td_HeaderRight').style.backgroundImage = "url(imagenes/curve_header_center.gif)";
	document.getElementById('td_HeaderRight').style.backgroundRepeat = "no-repeat";
	document.getElementById('td_HeaderRight').style.backgroundPosition = "left";
	
</script>

