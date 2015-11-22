using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AzuPassProfileMgr
	{
	/// <summary>
	/// Summary description for clsSettings
	/// </summary>
	public class clsSettings
		{
		public clsSettings()
			{
			//
			// TODO: Add constructor logic here
			//
			}

		#region "VARIABLES PRIVADAS"

		private static string m_ApplicationFullName = string.Empty;
		private static string m_ApplicationShortName = string.Empty;
		private static string m_ApplicationBaseURL = string.Empty;
		private static string m_ApplicationFaseState = string.Empty;
		private static string m_AzuPassServiceURL = string.Empty;
		private static string m_ApplicationVersion = string.Empty;
		private static string m_wsAzuPassShortName = string.Empty;
		private static string m_wsAzuPassLogoURL = string.Empty;
		private static int m_pwdMinChars = 0;
		private static int m_pwdMaxChars = 0;
		//private static bool m_pwdMustDiferUserName = false;
		private static TEICOCF.WebServices.passwordRequeriments m_passwdRequeriments;

		#endregion "FIN DE VARIABLES PRIVADAS"

		#region " ESTRUCTURAS "

		public struct struAzuPassGeneralData
		{
			public System.Data.DataTable dtServiceAdmins;
			public System.Data.DataTable dtServicedApplications;
			public System.Data.DataTable dtCatOcupacionales;
		}

		public static TEICOCF.WebServices.AuthHeader getSoapHeader
		{
			get
			{
				TEICOCF.WebServices.AuthHeader authHeader = new TEICOCF.WebServices.AuthHeader();
				authHeader.AppCliente = clsSettings.AzuPassSoapHeader.AppClient;
				authHeader.Password = clsSettings.AzuPassSoapHeader.Password;
				return authHeader;
			}
		}


		public struct struSessionData
		{
			public System.Data.DataTable dtPerfil;
			public System.Data.DataTable dtFavoritos;
		}

		public struct struAzuPassSoapHeader
		{
			public string AppClient;
			public string Password;
		}

		#endregion " FIN DE ESTRUCTURAS "

		#region " ENUMERACIONES "

		public enum enuAzuPassRoles
		{
			Usuario,
			Administrador
		}

		#endregion " FIN DE ENUMERACIONES "

		#region "PROCEDIMIENTOS PROPERTY"

		public static TEICOCF.WebServices.passwordRequeriments passwdRequeriments
		{
			get
			{
				//TEICOCF.WebServices.passwordRequeriments m_passwdRequeriments = new TEICOCF.WebServices.passwordRequeriments();
				if( m_pwdMinChars == 0 || m_pwdMaxChars == 0 )
				{
					TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
					m_passwdRequeriments = AzuPass.getPasswdRequeriments();
					AzuPass = null;
				}
				return m_passwdRequeriments;
			}

		}

		private static struAzuPassSoapHeader AzuPassSoapHeader
		{
			get
			{
				struAzuPassSoapHeader m_AzuPassSoapHeader;
				m_AzuPassSoapHeader.AppClient = "AzuPassProfileMgr";
				m_AzuPassSoapHeader.Password = "hOG+3EC/W4zJcQPfuQMQ7Q==";
				return m_AzuPassSoapHeader;
			}
		}

		public static struSessionData SessionData
		{
			set
			{
				HttpContext.Current.Session["Perfil"] = value;
			}
			get
			{
				if( HttpContext.Current.Session["Perfil"] == null )
				{
					clsSettings.struSessionData SessionData = new clsSettings.struSessionData();
					HttpContext.Current.Session["Perfil"] = SessionData;
				}
				return (clsSettings.struSessionData)HttpContext.Current.Session["Perfil"];
			}
		}

		public static struAzuPassGeneralData AzuPassGeneralData
		{
			get
			{
				try
				{
					struAzuPassGeneralData m_AzuPassGeneralData = new struAzuPassGeneralData();
					if( HttpContext.Current.Application["AzuPassGeneralData"] != null )
					{
						m_AzuPassGeneralData = (struAzuPassGeneralData)HttpContext.Current.Application["AzuPassGeneralData"];
					}
					TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
					if( m_AzuPassGeneralData.dtServiceAdmins == null )
					{
						try
						{
							m_AzuPassGeneralData.dtServiceAdmins = AzuPass._getServiceAdmins().Tables[0];
						}
						catch( System.Exception )
						{
							m_AzuPassGeneralData.dtServiceAdmins = null;
						}
					}
					if( m_AzuPassGeneralData.dtServicedApplications == null )
					{
						try
						{
							m_AzuPassGeneralData.dtServicedApplications = AzuPass._getServicedApplications( 0 ).Tables[0];
						}
						catch( System.Exception )
						{
							m_AzuPassGeneralData.dtServicedApplications = null;
						}
					}
					/*
					if( m_AzuPassGeneralData.dtCatOcupacionales == null )
					{
						try
						{
							m_AzuPassGeneralData.dtCatOcupacionales = AzuPass._getListCatOcupacionales().Tables[0];
						}
						catch( System.Exception )
						{
							m_AzuPassGeneralData.dtCatOcupacionales = null;
						}
					}
					*/
					HttpContext.Current.Application["AzuPassGeneralData"] = m_AzuPassGeneralData;
				}
				catch( System.Exception )
				{
						HttpContext.Current.Application["AzuPassGeneralData"] = null;
				}
				
				return (struAzuPassGeneralData)HttpContext.Current.Application["AzuPassGeneralData"];
		
			}
		}


		public static string AzuPassServiceURL
		{
			get
			{
				if( m_AzuPassServiceURL == string.Empty )
				{
          m_AzuPassServiceURL = global::AzuPassProfileMgr.Properties.Settings.Default.AzuPassProfileMgr_TEICOCF_WebServices_AzuPass.ToString();
					//m_AzuPassServiceURL = getWebConfigSimpleValue( "TEICOCF.WebServices.AzuPass" );
				}
				return m_AzuPassServiceURL;
			}
		}

		public static string ApplicationFullName
		{
			get
			{
				if( m_ApplicationFullName == string.Empty )
				{
					try
					{
						m_ApplicationFullName = getWebConfigSimpleValue( "ApplicationFullName" );
					}
					catch( System.Exception )
					{
						m_ApplicationFullName = "Administrador de perfiles";
					}
				}
				return m_ApplicationFullName;
			}
		}

		public static string ApplicationShortName
		{
			get
			{
				if( m_ApplicationShortName == string.Empty )
				{
					try
					{
						m_ApplicationShortName = getWebConfigSimpleValue( "ApplicationShortName" );
					}
					catch( System.Exception )
					{
						m_ApplicationShortName = "AzuPassProfileMgr";
					}
				}
				return m_ApplicationShortName;
			}
		}


		public static string ApplicationBaseURL
		{
			get
			{
				if( m_ApplicationBaseURL == string.Empty )
				{
					m_ApplicationBaseURL = HttpContext.Current.Request.Url.AbsoluteUri.Replace( HttpContext.Current.Request.Url.AbsolutePath + HttpContext.Current.Request.Url.Query, HttpContext.Current.Request.ApplicationPath ) + "/";
				}
				return m_ApplicationBaseURL;
			}
		}

		/// <summary>
		/// Versión del emsamblado de este Servicio Web XML.
		/// </summary>
		public static string ApplicationVersion
		{
			get
			{
				if( m_ApplicationVersion.Length == 0 )
				{
					System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();
					System.Reflection.AssemblyName thisAssemblyName = thisAssembly.GetName();
					m_ApplicationVersion = thisAssemblyName.Version.ToString();
					return m_ApplicationVersion;
				}
				else
				{
					return m_ApplicationVersion;
				}
			}
		}

		
		public static TEICOCF.WebServices.enuApplicationState ApplicationFaseState
		{
			get
			{
				if( m_ApplicationFaseState == string.Empty )
				{
					// Get the configuration object to access the related Web.config file.
					Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration( HttpContext.Current.Request.ApplicationPath );
					// Get the object related to the <compilation> section.
					System.Web.Configuration.CompilationSection section = (System.Web.Configuration.CompilationSection)config.GetSection( "system.web/compilation" );
					m_ApplicationFaseState = section.Debug == false ? TEICOCF.WebServices.enuApplicationState.Release.ToString() : TEICOCF.WebServices.enuApplicationState.Debug.ToString();
				}
				return m_ApplicationFaseState == TEICOCF.WebServices.enuApplicationState.Release.ToString() ? TEICOCF.WebServices.enuApplicationState.Release : TEICOCF.WebServices.enuApplicationState.Debug;
			}

		}
		
		public static string wsAzuPassShortName
		{
			get
			{
				if( m_wsAzuPassShortName.Length == 0 )
				{
					try
					{
						TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
						m_wsAzuPassShortName = AzuPass._getServiceShortName();
					}
					catch( System.Exception )
					{
						m_wsAzuPassShortName = "AzuPass";
					}
				}
				return m_wsAzuPassShortName;
			}

		}

		public static string wsAzuPassLogoURL
		{
			get
			{
				if( m_wsAzuPassLogoURL.Length == 0 )
				{
					try
					{
						TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
						m_wsAzuPassLogoURL = AzuPass._getLogoImageSrc();
					}
					catch( System.Exception )
					{
						m_wsAzuPassLogoURL = "";
					}
				}
				return m_wsAzuPassLogoURL;
			}

		}

		
#endregion "FIN DE PROCEDIMIENTOS PROPERTY"

		#region "PROCEDIMIENTOS PRIVADOS"

		private static string getWebConfigSimpleValue( string strKeyName )
			{
			if( System.Configuration.ConfigurationManager.AppSettings[strKeyName] != null )
				{
				return System.Configuration.ConfigurationManager.AppSettings[strKeyName];
				}
			else
				{
				throw new System.Configuration.ConfigurationErrorsException( "La llave '" + strKeyName + "' no existe en la sección 'appSettings' del fichero de configuración 'web.config'" );
				}
			}

		#endregion "FIN DE PROCEDIMIENTOS PRIVADOS"

		#region "MIEMBROS PÚBLICOS"

		public static string getHTML_FootCopyright()
			{
			int intYearInitial = 2007;
			int intYearActual = System.DateTime.Now.Year;
			string strYears = ( intYearInitial < intYearActual ) ? ( intYearInitial.ToString() + "-" + intYearActual.ToString() ) : intYearInitial.ToString();

			string strCopyrightFoot = "<div id=\"copyright\">" +
				"<p>Copyright &#169 " + strYears + " TEICO - Cienfuegos." +
        "</p></div>";
			return strCopyrightFoot;
			}

		#endregion "FIN DE MIEMBROS PÚBLICOS"

		} // Fin de la clase.

	} // Fin del namespace.
