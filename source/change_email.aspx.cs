using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AzuPassProfileMgr
{
	public partial class clswfChangeEmail : System.Web.UI.Page
	{
		private static string UserPasswd = string.Empty;

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      //this.lnkChangeEmail.Click += new System.EventHandler(this.lnkChangeEmail_Click);
    }

		protected void Page_Load( object sender, EventArgs e )
		{
			try
			{
				// Limpiar la muestra del error.
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ClearPageErrorNotification( (System.Web.UI.HtmlControls.HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ) );

				if( !Page.IsPostBack )
				{
					TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
					AzuPass.AuthHeaderValue = clsSettings.getSoapHeader;
					ProcessMessage.ShowSpanWarningNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), "Referentes al cambio del correo-e.", AzuPass.getChangeProfileEmailWarning() );
					ProcessMessage = null;
				}
				ProcessMessage = null;
			}
			catch( System.Exception Ex )
			{
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Ex );
				ProcessMessage = null;
			}

		} // Fin de Page_Load

		protected void lnkChangeEmail_Click( object sender, EventArgs e )
		{
			try
			{
				// Obtener el Password actual del usuario.
				FormsIdentity UserId = (FormsIdentity)User.Identity;
				FormsAuthenticationTicket UserTicket = UserId.Ticket;
				UserPasswd = UserTicket.UserData;

				TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
				AzuPass.AuthHeaderValue = clsSettings.getSoapHeader;
				string resultMessage = AzuPass.changeProfileEmail( HttpContext.Current.User.Identity.Name, UserPasswd, this.txtNewEmail.Text );
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanInfoNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), resultMessage );
				ProcessMessage = null;
				if( !ClientScript.IsStartupScriptRegistered( "RedirectAfterPasswdChange" ) )
				{
					// Cadena que representa el TAB.
					string strTab = System.Web.UI.HtmlTextWriter.DefaultTabString;
					// Las comillas dobles.
					//char strQuote = System.Web.UI.HtmlTextWriter.DoubleQuoteChar;
					// Nueva línea
					string strNewLine = System.Environment.NewLine;

					System.Text.StringBuilder sbScript = new System.Text.StringBuilder();
					sbScript.Append( "<script language=\"JavaScript\"><!-- " + System.Environment.NewLine );
					sbScript.Append( strTab + "var timeOut = 3;" + strNewLine );
					sbScript.Append( strTab + "function SessionTimeout() " + strNewLine );
					sbScript.Append( strTab + "{" + strNewLine );
					sbScript.Append( strTab + strTab + "document.getElementById(\"lblTitle\").innerHTML = \"Esta página se redireccionará en: \" + timeOut + \" min\"; " + strNewLine );
					sbScript.Append( strTab + strTab + "timeOut -= 1; " + strNewLine );
					sbScript.Append( strTab + strTab + "if(timeOut <= 0) " + strNewLine );
					sbScript.Append( strTab + strTab + "{ " + strNewLine );
					sbScript.Append( strTab + strTab + strTab + "RedirectToInicio(); " + strNewLine );
					sbScript.Append( strTab + strTab + "} " + strNewLine );
					sbScript.Append( strTab + strTab + "window.setTimeout(\"SessionTimeout()\", 60000); " + strNewLine );
					sbScript.Append( strTab + "} " + strNewLine );
					sbScript.Append( strTab + "SessionTimeout(); " + strNewLine );
					sbScript.Append( strNewLine );
					sbScript.Append( strTab + "function RedirectToInicio() " + strNewLine );
					sbScript.Append( strTab + strTab + "{ " + strNewLine );
					sbScript.Append( strTab + strTab + strTab + "window.open(\"" + clsSettings.ApplicationBaseURL + "\", \"_self\", null, false); " + strNewLine );
					sbScript.Append( strTab + strTab + "} " + strNewLine );
					sbScript.Append( strNewLine );
					sbScript.Append( "//--></script>" + strNewLine );
					ClientScript.RegisterStartupScript( System.Type.GetType( "System.String" ), "RedirectAfterPasswdChange", sbScript.ToString() );
					// Terminar la sesión
					if( HttpContext.Current.Session != null )
					{
						FormsAuthentication.SignOut();
						//HttpContext.Current.Session.Abandon();
					}
				}
				AzuPass = null;
			}
			catch( System.Exception Ex )
			{
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Ex );
				ProcessMessage = null;
			}


		} // Fin de lnkChangeEmail_Click

	} // Fin de la clase.

} // Fin del namespace.
