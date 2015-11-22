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
	public partial class clswfIndex : System.Web.UI.Page
	{
    override protected void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      //this.ScriptManager1.EnableScriptGlobalization = true;
      //this.ScriptManager1.EnableScriptLocalization = true;

    }

    protected void Page_Load( object sender, EventArgs e )
		{

			try
			{
				// Limpiar la muestra del error.
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ClearPageErrorNotification( (System.Web.UI.HtmlControls.HtmlGenericControl)this.wucHeader.FindControl( "spNotificationZone" ) );
				ProcessMessage = null;
			}
			catch( System.Exception )
			{
				;
			}

			try
			{
				if( !Page.IsPostBack )
				{
					clsSettings.struAzuPassGeneralData AzuPassGeneralData = new clsSettings.struAzuPassGeneralData();
					AzuPassGeneralData = clsSettings.AzuPassGeneralData;

					// Administradores del Servicio AzuPass.
					string headerAzuPassAdmins = "<span class=\"LblNormalBold_N\">Administradores del servicio " + clsSettings.wsAzuPassShortName + "</span>";
					string contentAzuPassAdmins = string.Empty;
					if( AzuPassGeneralData.dtServiceAdmins != null )
					{
						contentAzuPassAdmins = "<ul>";
						for( int i = 0; i <= ( AzuPassGeneralData.dtServiceAdmins.Rows.Count - 1 ); i++ )
						{
							contentAzuPassAdmins += "<li><a tabindex=\"-1\" href=\"mailto:" + AzuPassGeneralData.dtServiceAdmins.Rows[i][0].ToString() + "?subject=Mensaje desde " + clsSettings.ApplicationShortName + "&body=Soy usuario de " + clsSettings.ApplicationShortName + " y necesito que...\">" + AzuPassGeneralData.dtServiceAdmins.Rows[i][0].ToString() + "</a></li>";
						}
						contentAzuPassAdmins += "</ul>";
					}

          this.WSAdminsList.InnerHtml = clsUtiles.getRoundedItem(headerAzuPassAdmins, contentAzuPassAdmins, clsUtiles.enuRoundBoxColor.Gris);

					// Aplicaciones que utilizan el Servicio AzuPass.
					string headerAzuPassServicedApplications = "<span class=\"LblNormalBold_N\">Aplicaciones que utilizan el servicio " + clsSettings.wsAzuPassShortName + "</span>";
					string contentAzuPassServicedApplications = string.Empty;
					if( AzuPassGeneralData.dtServicedApplications != null )
					{
						contentAzuPassServicedApplications = "<ul>";
						for( int i = 0; i <= ( AzuPassGeneralData.dtServicedApplications.Rows.Count - 1 ); i++ )
						{
							contentAzuPassServicedApplications += "<li><a tabindex=\"-1\" href=\"" + AzuPassGeneralData.dtServicedApplications.Rows[i]["appURL"] + "\">" + AzuPassGeneralData.dtServicedApplications.Rows[i]["appName"] + "</a></li>";
						}
						contentAzuPassServicedApplications += "</ul>";
					}

          this.WSServicedApplications.InnerHtml = clsUtiles.getRoundedItem(headerAzuPassServicedApplications, contentAzuPassServicedApplications, clsUtiles.enuRoundBoxColor.Gris);
					/*
					HttpBrowserCapabilities bc = Request.Browser;
					Response.Write( "<p>Browser Capabilities:</p>" );
					Response.Write( "Type = " + bc.Type + "<br>" );
					Response.Write( "Name = " + bc.Browser + "<br>" );
					Response.Write( "Version = " + bc.Version + "<br>" );
					Response.Write( "Major Version = " + bc.MajorVersion + "<br>" );
					Response.Write( "Minor Version = " + bc.MinorVersion + "<br>" );
					Response.Write( "Platform = " + bc.Platform + "<br>" );
					Response.Write( "Is Beta = " + bc.Beta + "<br>" );
					Response.Write( "Is Crawler = " + bc.Crawler + "<br>" );
					Response.Write( "Is AOL = " + bc.AOL + "<br>" );
					Response.Write( "Is Win16 = " + bc.Win16 + "<br>" );
					Response.Write( "Is Win32 = " + bc.Win32 + "<br>" );
					Response.Write( "Supports Frames = " + bc.Frames + "<br>" );
					Response.Write( "Supports Tables = " + bc.Tables + "<br>" );
					Response.Write( "Supports Cookies = " + bc.Cookies + "<br>" );
					Response.Write( "Supports VB Script = " + bc.VBScript + "<br>" );
					Response.Write( "Supports JavaScript = " + bc.EcmaScriptVersion + "<br>" );
					Response.Write( "Supports Java Applets = " + bc.JavaApplets + "<br>" );
					Response.Write( "Supports ActiveX Controls = " + bc.ActiveXControls + "<br>" );
					Response.Write( "CDF = " + bc.CDF + "<br>" );
					*/
				}
			}
			catch( System.Exception Ex)
			{
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Ex );
				ProcessMessage = null;
			}

		} // Fin de Page_Load


} // Fin de la clase.

} // Fin del namespace.