using System;

namespace AzuPassProfileMgr
{
	/// <summary>
	/// Descripción breve de clsProcessMessage.
	/// </summary>
	public class clsProcessMessage
	{
		public clsProcessMessage()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public static string spNotifyInformationName = "spNotificationZone";

		#region "*** PROCEDIMIENTOS PÚBLICOS ***"

		/// <summary>
		/// Procesar errores que se mostrarán en la parte superior a lo largo de toda la página,
		/// inmediatamente después del encabezado de la página, en los elementos <TR> y <SPAN>
		/// </summary>
		/// <param name="tr_Notify">Objeto <tr> del lado del servidor.</param>
		/// <param name="sp_Notify">Objeto <span> del lado del servidor.</param>
		/// <param name="strErrorMessage">Mensaje de error.</param>
		public void ShowSpanInfoNotification( System.Web.UI.HtmlControls.HtmlGenericControl sp_Notify, string Message)
		{
			//class="spErrorNotification" 
			if( sp_Notify.InnerHtml == string.Empty )
			{
				sp_Notify.InnerHtml += "<ul style='padding-left: 1px; padding-bottom: 1px; margin-left: 1px; margin-top: 1px'>INFORMACIÓN: ";
			}
			sp_Notify.InnerHtml += "<li style='margin-left: 20px;'>" + Message + "</li>";
			sp_Notify.Attributes["class"] = "spNotifyInformation";
			sp_Notify.Style["display"] = "block";
		}

		/// <summary>
		/// Procesar errores que se mostrarán en la parte superior a lo largo de toda la página,
		/// inmediatamente después del encabezado de la página, en los elementos <TR> y <SPAN>
		/// </summary>
		/// <param name="tr_Notify">Objeto <tr> del lado del servidor.</param>
		/// <param name="sp_Notify">Objeto <span> del lado del servidor.</param>
		/// <param name="strErrorMessage">Mensaje de error.</param>
		public void ShowSpanErrorNotification( System.Web.UI.HtmlControls.HtmlGenericControl sp_Notify, System.Exception Ex)
		{
			//class="spErrorNotification" 
			if( sp_Notify.InnerHtml == string.Empty )
			{
				sp_Notify.InnerHtml += "<ul style='padding-left: 1px; padding-bottom: 1px; margin-left: 1px; margin-top: 1px'>ERROR: ";
			}
			string strMessage = string.Empty;
			if( Ex.GetType().FullName == "System.Web.Services.Protocols.SoapException" )
			{
				strMessage = "Servicio " + clsSettings.wsAzuPassShortName + " reporta:<br>";
			}
			strMessage += Ex.Message;
			sp_Notify.InnerHtml += "<li style='margin-left: 20px;'>" + strMessage + "</li>";
			sp_Notify.Attributes["class"] = "spNotifyError";
			sp_Notify.Style["display"] = "block";
		}

		/// <summary>
		/// Procesar errores que se mostrarán en la parte superior a lo largo de toda la página,
    /// inmediatamente después del encabezado de la página, en las etiquetas TR y SPAN.
		/// </summary>
		/// <param name="tr_Notify">Etiqueta TR del lado del servidor.</param>
    /// <param name="sp_Notify">Etiqueta SPAN del lado del servidor.</param>
		/// <param name="strWariningHeader">Encabezado para el mensaje de advertencia.</param>
		/// <param name="strWariningMessage">Contenido del mensaje de advertencia.</param>
		public void ShowSpanWarningNotification( System.Web.UI.HtmlControls.HtmlGenericControl sp_Notify,
			string strWarningHeader, string strWarningMessage )
		{
			if( sp_Notify.InnerHtml == string.Empty )
			{
				sp_Notify.InnerHtml += "<ul style='padding-left: 1px; padding-bottom: 1px; margin-bottom: 0px; margin-left: 1px; margin-top: 1px'>ADVERTENCIA(S): " + strWarningHeader;
			}
      sp_Notify.InnerHtml += "<li style='text-align:justify; list-style-position: outside; margin-left: 20px;'>" + strWarningMessage + "</li>";
			sp_Notify.Style["display"] = "block";
			sp_Notify.Attributes["class"] = "spNotifyWarning";
		}

		public void ClearPageErrorNotification( System.Web.UI.HtmlControls.HtmlGenericControl sp_Notify )
		{
			sp_Notify.InnerHtml = string.Empty;
			sp_Notify.Style["display"] = "none";
		}

		#endregion "*** FIN DE PROCEDIMIENTOS PÚBLICOS ***"


	} // Fin de la clase.

} // Fin del namespace.
