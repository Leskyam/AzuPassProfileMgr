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
	public partial class clswfChangePasswd : System.Web.UI.Page
	{
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      this.lnkChangePasswd.Click += new System.EventHandler(this.lnkChangePasswd_Click);
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
					ProcessMessage.ShowSpanWarningNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), "Características de la nueva contraseña.", AzuPass.getChangeProfilePasswdWarning() );
					ProcessMessage = null;
					TEICOCF.WebServices.passwordRequeriments passwdReq = AzuPass.getPasswdRequeriments();
					AzuPass = null;
					this.valRegExpNewPasswd.ValidationExpression += "{" + clsSettings.passwdRequeriments.pwdMinChars + "," + clsSettings.passwdRequeriments.pwdMaxChars + "}";
					this.valRegExpNewPasswd.ToolTip = this.valRegExpNewPasswd.ErrorMessage = "Contraseña nueva debe tener entre " + clsSettings.passwdRequeriments.pwdMinChars + " y " + clsSettings.passwdRequeriments.pwdMaxChars + " caracteres.";
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

		protected void lnkChangePasswd_Click( object sender, EventArgs e )
		{
			try
			{
				TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
				AzuPass.AuthHeaderValue = clsSettings.getSoapHeader;
				if( AzuPass.changeProfilePasswd( HttpContext.Current.User.Identity.Name, this.txtCurrentPasswd.Text, this.txtNewPasswd.Text ) )
				{
					clsProcessMessage ProcessMessage = new clsProcessMessage();
					string Message = "Su contraseña ha sido cambiada satisfactoriamente. La sesión de trabajo actual se cerrará y " +
						"usted será redireccionado a la <a target=\"_self\" tabIndex=\"-1\" href=\"" + clsSettings.ApplicationBaseURL + 
						"\">página de inicio</a> de la aplicación donde podrá identificarse con la nueva contraseña.";
					ProcessMessage.ShowSpanInfoNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Message );
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
						sbScript.Append( strTab + strTab + "timeOut -= 1; " + strNewLine );
						sbScript.Append( strTab + strTab + "document.getElementById(\"lblTitle\").innerHTML = \"Esta página se redireccionará en: \" + timeOut + \" min\"; " + strNewLine );
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
				}
				else
				{
					clsProcessMessage ProcessMessage = new clsProcessMessage();
					string Message = "No se ha cambiado su contraseña, se desconoce la razón de este comportamiento. Por favor, le sugerimos que lo intente " +
						"nuevamente. Si el problema persiste sírvase contactar con los administradores del servicio " + clsSettings.wsAzuPassShortName + ".";
					ProcessMessage.ShowSpanWarningNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), "Cambio de contraseña no efectuado.", Message );
					ProcessMessage = null;
				}
				AzuPass = null;
			}
			catch( System.Exception Ex )
			{
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Ex );
				ProcessMessage = null;
			}

		}	// Fin de lnkChangePasswd_Click

	} // Fin de la clase.

} // Fin del namespace.
