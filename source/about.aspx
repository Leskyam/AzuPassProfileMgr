<%@ Page language="c#" Inherits="AzuPassProfileMgr.clswfAbout" Culture="es-MX" UICulture="es-MX" CodeBehind="about.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html>
	<head>
		<title>AzuPassProfileMgr - Acerca de</title>
		<link href="estilos/main.css" rel="stylesheet" type="text/css" />
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type" />
	</head>
	<body>
		<div id="wrapper"><form id="frmAbout" method="post" runat="server">
			<table class="" border="0" cellpadding="5" cellspacing="0" width="100%" align="center">
				<tr>
					<td align="center"><asp:Label ID="lblAppName" runat="server" CssClass="LblAppTitle_A"></asp:Label></td>
				</tr>
				<tr>
					<td><asp:Label ID="lblDescription" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td><b>Estado actual:</b> <asp:Label ID="lblEstadoActual" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td><b>Pronstico de perodo de prueba:</b> De mediados de 
					Enero a comienzo de Febrero.</td>
				</tr>
				<tr>
					<td><b>Pronstico de puesta en produccin:</b> A mediados de 
					Febrero.</td>
				</tr>
				<tr>
					<td><asp:Label ID="lblEnabledOptions" runat="server"></asp:Label></td>
				</tr>
				
			</table>
		</form></div>
	</body>
</html>
