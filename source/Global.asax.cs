using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace AzuPassProfileMgr 
{
	/// <summary>
	/// Descripci�n breve de Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Variable del dise�ador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			Application["Visitas"] = 0;
			Application["AzuPassGeneralData"] = null;
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			// Visitas totales desde el inicio de la aplicaci�n.
			int Visitas = (int)Application["Visitas"];
			Visitas += 1;
			Application["Visitas"] = Visitas;
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			if( Request.Url.AbsolutePath.IndexOf( "about.aspx" ) == -1 & 
				Request.Url.AbsolutePath.IndexOf( "test.aspx" ) == -1 & 
				clsSettings.ApplicationFaseState == TEICOCF.WebServices.enuApplicationState.Debug)
			{
                Response.Write("<div align=\"center\"><h3>APLICACI�N EN DESARROLLO.</h3></div>");
                Response.Write("<div align=\"center\">Nota. El valor del atributo 'debug' del fichero Web.Config est&aacute; establecido en 'true'.</div>");
                Response.Write("<div align=\"center\"><a tabindex=\"-1\" href=\"JavaScript:window.history.back();\">Atr�s.</a></div>");
				Response.Write( "<hr></hr>" );
			}
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
      //Colocar el Copyright s�lo al pi� de las p�ginas ".aspx"
      if (Request.Url.AbsolutePath.IndexOf(".aspx") > -1)
      {
        Response.Write(clsSettings.getHTML_FootCopyright());
      }
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
			try
			{
				HttpApplication app = (HttpApplication)sender;
					
				if( app.Request.IsAuthenticated && app.User.Identity is System.Web.Security.FormsIdentity )
				{
					// Array para almacenar temporalmente los Roles del usuario.
					// El usuario identificado siempre pertenece al role "Usuario".
					string strRoles = "Usuario";
					// Revisar si tambi�n pertenece al role "Administrador"
					System.Data.DataTable dtAdmins = clsSettings.AzuPassGeneralData.dtServiceAdmins.Copy();
					for( int i = 0; i <= ( dtAdmins.Rows.Count - 1 ); i++ )
					{
						if( dtAdmins.Rows[i]["e_mail"].ToString().ToLower() == app.User.Identity.Name.ToLower() )
						{
							strRoles += "|Administrador";
							break;
						}
					}
					HttpContext.Current.User = new System.Security.Principal.GenericPrincipal( (System.Web.Security.FormsIdentity)app.User.Identity, strRoles.Split('|') );
				}
			}
			catch( System.Exception Ex)
			{
				System.Diagnostics.Debug.WriteLine(Ex.ToString());
				;
			}

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

		// EVENTOS QUE NO APARECEN EN EL GLOBAL.ASAX PREDETERMINADO.

		protected void Application_OnAcquireRequestState( Object sender, EventArgs e )
		{
			/* No se utiliza porque ya lo implemento en clsSettings.SessionData
			try
			{
				// S�lo ejecutar cuando el objeto Session "exista".
				if( HttpContext.Current.Session != null )
				{
					if( HttpContext.Current.Session["Perfil"] == null )
					{
						if( HttpContext.Current.User.Identity.IsAuthenticated )
						{
							clsSettings.struSessionData SessionData = new clsSettings.struSessionData();
							HttpContext.Current.Session["Perfil"] = SessionData;
						}
					}
				}
			}
			catch( System.Exception )
			{
				;
			}
			*/
		}

			
		#region C�digo generado por el Dise�ador de Web Forms
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}

#endregion

	} // Fin de la clase.

} // Fin del namespace.

