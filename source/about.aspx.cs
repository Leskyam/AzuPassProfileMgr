using System;
using System.Collections;
using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AzuPassProfileMgr
{
	/// <summary>
	/// Descripción breve de Index.
	/// </summary>
	public partial class clswfAbout : System.Web.UI.Page
	{

		// private static System.Data.DataSet dsLogOnPlus;

		protected void Page_Load( object sender, System.EventArgs e )
		{
			try
			{
				System.Text.StringBuilder sbMessage = new System.Text.StringBuilder( "" );
				TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
				string AzuPassFullName = AzuPass._getServiceFullName();
				string AzuPassLogoURL = AzuPass._getLogoImageSrc();
				string AzuPassShortName = AzuPass._getServiceShortName();

				// Nombre de la aplicación.
				this.lblAppName.Text = clsSettings.ApplicationFullName + " <a tabindex=\"-1\" href=\"" + clsSettings.AzuPassServiceURL +
					"\" target=\"_blank\">" + AzuPassShortName + "<sup><img border=\"0\" src=\"" + AzuPassLogoURL + "\"></sup></a>";

				// Hipervínculo al Servicio Web XML AzuPass
				string lnkToAzuPass = "<a tabindex=\"-1\" href=\"" + clsSettings.AzuPassServiceURL + "\" target=\"_blank\">" + AzuPassShortName + "</a>";
				
				// Descripción
				this.lblDescription.Text = "<b>Descripción:</b> " + clsSettings.ApplicationFullName + " " + AzuPassShortName +
					", también llamada " + "(" + clsSettings.ApplicationShortName + "), es un cliente especializado para el manejo " +
					"de los perfiles de usuarios que proporciona el Servicio Web XML " + lnkToAzuPass + "; a través de " +
					"ésta los usuarios pueden crear su propio perfil y luego manipular los datos del mismo en caso que fuera necesario. " +
					"Los administradores del Servicio Web XML " + lnkToAzuPass + " tienen la facultad de, entre otras opciones, " +
					"ver los registros de uso del servicio y de las aplicaciones clientes que lo utilizan y deshabilitar perfiles según " +
					"como se entienda necesario.";

				// Fase de la aplicación.
				this.lblEstadoActual.Text = clsSettings.ApplicationFaseState == 0 ? "Desarrollo" : "Producción";
				
				// Ficheros implementados
				string strAppPath = System.Web.HttpContext.Current.Request.MapPath( System.Web.HttpContext.Current.Request.ApplicationPath );
				//string strPhysicalPath = 
				if( strAppPath.LastIndexOf( System.IO.Path.DirectorySeparatorChar ) == ( strAppPath.Length - 1 ) )
				{
					strAppPath = strAppPath.Substring( 0, strAppPath.Length - 1 );
				}
				string[] implementedOptions = System.IO.Directory.GetFiles( strAppPath, "*.aspx", System.IO.SearchOption.TopDirectoryOnly );
				this.lblEnabledOptions.Text = "<b>Opciones en desarrollo hasta el momento:</b>";
				this.lblEnabledOptions.Text += "<ul>";
				string strHtmlOptions = string.Empty;
				for( int i = 0; i <= ( implementedOptions.Length - 1 ); i++ )
				{
					string strFileName = System.IO.Path.GetFileName( implementedOptions[i] );
					if( strFileName == "about.aspx" || strFileName.IndexOf( "imp_" ) != -1 || strFileName == "test.aspx" )
					{
						continue;
					}
					string pageTitle = strFileName;
					System.Text.StringBuilder sbFileContent = new System.Text.StringBuilder( System.IO.File.ReadAllText( implementedOptions[i], System.Text.Encoding.GetEncoding( "iso-8859-1" ) ) );
					pageTitle = sbFileContent.ToString().Substring( sbFileContent.ToString().IndexOf( "<title>" ) + 7, ( sbFileContent.ToString().IndexOf( "</title>" ) - sbFileContent.ToString().IndexOf( "<title>" ) - 7 ) );
					strHtmlOptions += "<li><a tabindex=\"-1\" href=\"" + strFileName + "\" target=\"_parent\">" + pageTitle + "</a></li>";
				}
				this.lblEnabledOptions.Text += strHtmlOptions.Length != 0 ? strHtmlOptions + "</ul>" : "No existen opciones implementadas aún.";

			}
			catch( System.Exception Ex )
			{
				Response.Write( "<center style=\"font-family:Verdana;color:RGB(255,0,0);margin-bottom:3\">Ha ocurrido un error, el mensaje del mismo se presenta a continuación: " + Ex.Message + "</div>" );
			}

		}	 // Fin de Page_Load

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit( EventArgs e )
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit( e );
		}

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{

		}

		#endregion

		
	} // Fin de la clase

} // Fin el namespace