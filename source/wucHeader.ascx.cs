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
	public partial class wucHeader : System.Web.UI.UserControl
	{
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      //this.lnkLogOut.Click += new System.EventHandler(this.lnkLogOut_Click);
    }

		protected void Page_Load( object sender, EventArgs e )
    {
      /*
			if( !Page.IsPostBack )
			{
				if( Request.Browser.Browser.IndexOf( "IE" ) == -1 )
				{
					Response.Write( "<center style=\"font-family:Verdana;color:RGB(255,0,0);margin-bottom:3\"><b>Esta aplicación se muestra y funciona mejor utilizando Windows Internet Explorer&#174; como navegador.</b></div>" );
				}
			}
      */

      if( Application["Visitas"] != null )
			{
				this.spVisitas.InnerHtml = "Se han registrado " + Application["Visitas"] + " visitas desde el inicio de la aplicación.";
			}
			this.spFecha.InnerHtml = System.DateTime.Now.ToLongDateString();
			this.lblAppFullName.Text = "<img align=\"absmiddle\" height=\"20\" width=\"40\" border=\"0\" src=\"imagenes/logo_small.gif\"> " + clsSettings.ApplicationFullName + " " + clsSettings.wsAzuPassShortName;
			this.lblAppVersion.Text = "Versión: " + clsSettings.ApplicationVersion + " ";
			this.lnkAdministrar.Style["display"] = HttpContext.Current.User.IsInRole( clsSettings.enuAzuPassRoles.Administrador.ToString() ) ? "inline" : "none";
			this.lnkLogOut.Style["display"] = HttpContext.Current.User.Identity.IsAuthenticated ? "inline" : "none";
			this.spNavBar.InnerHtml = getNavBar_HTML();
			
			if( HttpContext.Current.User.Identity.IsAuthenticated )
			{
				if( clsSettings.SessionData.dtPerfil != null )
				{
					System.Text.StringBuilder sbWelcomeMessage = new System.Text.StringBuilder( "" );
					sbWelcomeMessage.Append( clsSettings.SessionData.dtPerfil.Rows[0]["Sexo"].ToString() == "M" ? "Bienvenido " : "Bienvenida " );
					sbWelcomeMessage.Append( clsSettings.SessionData.dtPerfil.Rows[0]["Nombre"] + " " + clsSettings.SessionData.dtPerfil.Rows[0]["Apellidos"] );
					/*
					if( HttpContext.Current.User.IsInRole( clsSettings.enuAzuPassRoles.Administrador.ToString() ) )
					{
						sbWelcomeMessage.Append( ". Role asignado por " + clsSettings.wsAzuPassShortName + " " + clsSettings.enuAzuPassRoles.Administrador.ToString() );
					}
					*/
					int daysToBerthday = System.DateTime.Now.DayOfYear - System.Convert.ToDateTime( clsSettings.SessionData.dtPerfil.Rows[0]["FechaNac"] ).DayOfYear;
					int daysToServiceAniversary = System.DateTime.Now.DayOfYear - System.Convert.ToDateTime( clsSettings.SessionData.dtPerfil.Rows[0]["FechaRegistro"] ).DayOfYear;

					string strBerthday = string.Empty;

					switch( daysToBerthday )
					{
						case -1:
							{
								strBerthday = ". El equipo de \"" + clsSettings.wsAzuPassShortName + "\" lo felicita de antemano por su cumpleaños";
								break;
							}
						case 0:
							{
								strBerthday = ". El equipo de \"" + clsSettings.wsAzuPassShortName + "\" lo felicita por su cumpleaños hoy";
								break;
							}
						case 1:
							{
								strBerthday = ". El equipo de \"" + clsSettings.wsAzuPassShortName + "\" espera que halla pasado un día feliz por su cumpleaños ayer";
								break;
							}
						default:
							{
								break;
							}
					}

					string strServiceAniversary = string.Empty;
					switch( daysToServiceAniversary )
					{
						case -1:
							{
								if( strBerthday == string.Empty )
								{
									strServiceAniversary = ". El equipo de \"" + clsSettings.wsAzuPassShortName + "\" lo felicita de antemano porque se acerca un aniversario de su registro con este servicio";
								}
								else
								{
									strServiceAniversary = " y porque se acerca un aniversario de su registro con este servicio";
								}
								break;
							}
						case 0:
							{
								if( strBerthday == string.Empty )
								{
									if( System.Convert.ToDateTime( clsSettings.SessionData.dtPerfil.Rows[0]["FechaRegistro"] ).ToShortDateString() == System.DateTime.Now.ToShortDateString() )
									{
										strServiceAniversary = ". El equipo de \"" + clsSettings.wsAzuPassShortName + "\" lo felicita por su nuevo registro con este servicio";
									}
									else
									{
										strServiceAniversary = ". El equipo de \"" + clsSettings.wsAzuPassShortName + "\" lo felicita porque se cumple un aniversario de su registro con este servicio";
									}
								}
								else
								{
									if( System.Convert.ToDateTime( clsSettings.SessionData.dtPerfil.Rows[0]["FechaRegistro"] ).ToShortDateString() == System.DateTime.Now.ToShortDateString() )
									{
										strServiceAniversary = " y por su nuevo registro con este servicio";
									}
									else
									{
										strServiceAniversary = " y porque se cumple un aniversario de su registro con este servicio";
									}
								}
								break;
							}
						case 1:
							{
								if( strBerthday == string.Empty )
								{
									if( System.Convert.ToDateTime( clsSettings.SessionData.dtPerfil.Rows[0]["FechaRegistro"] ).AddYears( 1 ) < System.DateTime.Now )
									{
										strServiceAniversary = ". El equipo de \"" + clsSettings.wsAzuPassShortName + "\" lo felicita porque ayer cumplió aniversario de ser usuario de este servicio";
									}
								}
								else
								{
									if( System.Convert.ToDateTime( clsSettings.SessionData.dtPerfil.Rows[0]["FechaRegistro"] ).AddYears(1)< System.DateTime.Now )
									{

										strServiceAniversary = " y porque ayer cumplió aniversario de ser usuario de este servicio";
									}
								}
								break;
							}
						default:
							{
								break;
							}
					}
					sbWelcomeMessage.Append( strBerthday + strServiceAniversary );
					sbWelcomeMessage.Append( "." );
					this.spWelcomeBar.InnerHtml = sbWelcomeMessage.ToString();
					this.spWelcomeBar.Style["display"] = "block";
				}

			}
    }


		protected void lnkLogOut_Click( object sender, EventArgs e )
		{
			Response.Redirect( forceToSignOut(), false );
		}

		#region " PROCEDIMIENTOS PRIVADOS "

		private string forceToSignOut()
		{
			try
			{
				string strAppPath = clsSettings.ApplicationBaseURL;
				FormsAuthentication.SignOut();
				if( HttpContext.Current.Session != null )
				{
					//HttpContext.Current.Session.Abandon();
				}

				return strAppPath;

			}

			catch( System.Exception )
			{
				//System.Diagnostics.Debug.WriteLine(Ex.ToString());
				return string.Empty;
			}

		}

		private string getNavBar_HTML()
		{

			System.Text.StringBuilder sbNavBar_Todos = new System.Text.StringBuilder( "" );
			System.Text.StringBuilder sbNavBar_Todos_Final = new System.Text.StringBuilder( "" );
			System.Text.StringBuilder sbNavBar_Usuarios = new System.Text.StringBuilder( "" );
			// <a href=\"index.aspx\" target=\"_self\" tabindex=\"-1\">Inicio</a> | <a href=\"ayuda.aspx\" target=\"_self\" tabindex=\"-1\">Ayuda</a> | <a href=\"about.aspx\" target=\"_self\" tabindex=\"-1\">Acerca de</a> 
			// Los elementos que son comunes a todos y que van al final de la barra de navegación.
			sbNavBar_Todos_Final.Append( createLink( sbNavBar_Todos_Final, "ayuda.aspx", "Ayuda", "_self", false ));
			sbNavBar_Todos_Final.Append( createLink( sbNavBar_Todos_Final, "about.aspx", "Acerca de", "_blank", true ) );
			// Siempre agregar los vínculos comunes a los usuarios identificados y los anónimos.
			sbNavBar_Todos.Append( createLink( sbNavBar_Todos, "index.aspx", "Inicio", "_self", false ) );
			if( HttpContext.Current.User.Identity.IsAuthenticated )
			{
				if( HttpContext.Current.User.IsInRole( clsSettings.enuAzuPassRoles.Usuario.ToString() ) )
				{
					// Procesar los vínculos para los Usuarios.
					// sbNavBar_Usuarios
					sbNavBar_Usuarios.Append( createLink( sbNavBar_Usuarios, "profile.aspx", "Mi perfil", "_self", false ) );
				}
			}
			System.Text.StringBuilder[] sb = { sbNavBar_Todos, sbNavBar_Usuarios, sbNavBar_Todos_Final };
			return formarNavBar(sb);
		}

		private string createLink(System.Text.StringBuilder sb, string pageName, string linkTitle, string target, bool isPopup)
		{
			string strLink = string.Empty;
			if( HttpContext.Current.Request.Url.AbsoluteUri.IndexOf( pageName )==-1 )
			{
				if( sb.ToString().Length > 0 )
				{
					strLink +=" | ";
				}
				if( !isPopup )
				{
					strLink += "<a href=\"" + pageName + "\" target=\"" + target + "\" tabindex=\"-1\">" + linkTitle + "</a>";
				}
				else
				{
					if( Request.Browser.Browser.IndexOf( "IE" ) > -1 )
					{
						//btnOpen3.Attributes.Add("onclick", "window.showModalDialog('child.aspx', null,'status:no;dialogWidth:370px;dialogHeight:220px;dialogHide:true;help:no;scroll:no');") 
						strLink += "<a style=\"cursor: pointer;\" onclick=\"JavaScript:window.showModalDialog('" + pageName + "', null,'center:yes;status:no;dialogWidth:450px;dialogHeight:400px;dialogHide:true;help:no;scroll:no');\" tabindex=\"-1\">" + linkTitle + "</a>";
					}
					else
					{
						// window.open(this.popupURL("fullscreen.html"), "ha_fullscreen",
				    // "toolbar=no,menubar=no,personalbar=no,width=640,height=480," +
				    // "scrollbars=no,resizable=yes");
						strLink += "<a style=\"cursor: pointer;\" onclick=\"JavaScript:window.open('" + pageName + "', null,'toolbar=no,menubar=no,personalbar=no,width=450,height=400,scrollbars=no,resizable=false,location=yes');\" tabindex=\"-1\">" + linkTitle + "</a>";
					}
				}
			}
			return strLink;
		}

		private string formarNavBar( System.Text.StringBuilder[] arySbNavBar )
		{
			System.Text.StringBuilder sbResult = new System.Text.StringBuilder( "" );
			for( int i = 0; i <= ( arySbNavBar.Length-1); i++ )
			{
				if( sbResult.ToString().Length > 0 & !sbResult.ToString().EndsWith(" | "))
				{
					sbResult.Append( " | " );
				}
				sbResult.Append( arySbNavBar[i].ToString() );
			}
			return sbResult.ToString();
		}

		#endregion " FIN DE PROCEDIMIENTOS PRIVADOS "

	} // FIn de la clase. 

} // Fin del namespace.