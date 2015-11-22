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

	public partial class wucLogin : System.Web.UI.UserControl
	{
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      //this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
    }

    protected void Page_Load( object sender, EventArgs e )
		{

      // Limpiar las notificaciones de error.
			clsProcessMessage ProcessMessage = new clsProcessMessage();
			ProcessMessage.ClearPageErrorNotification((HtmlGenericControl)this.spLogOnNotification);
			ProcessMessage = null;

			// Imagen del logo del servicio AzuPass.
			this.imgAzuPassLogo.ImageUrl = clsSettings.wsAzuPassLogoURL;

			this.panelLogOn.Visible = !HttpContext.Current.User.Identity.IsAuthenticated;
			this.panelFavoritos.Visible = HttpContext.Current.User.Identity.IsAuthenticated;

			if( HttpContext.Current.User.Identity.IsAuthenticated )
			{
        if (clsSettings.SessionData.dtFavoritos == null)
        {
          // Obtener el Password actual del usuario.
          FormsIdentity UserId = (FormsIdentity)HttpContext.Current.User.Identity;
          FormsAuthenticationTicket UserTicket = UserId.Ticket;
          string UserPasswd = UserTicket.UserData;
          TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
          clsSettings.struSessionData SessionData;
          SessionData.dtFavoritos = AzuPass._getProfileFavorites(UserTicket.Name, UserPasswd, 5).Tables[0];
        }

				if(clsSettings.SessionData.dtFavoritos!=null)
				{
					// Establecer los vínculos a Favoritos.
					System.Data.DataTable dtFavoritos = clsSettings.SessionData.dtFavoritos.Copy();
					string headerFavoritos = "<span class=\"LblNormalBold_N\">Mis sitios favorios según " + clsSettings.wsAzuPassShortName + "</span>";
					string contentFavoritos  = string.Empty;
					contentFavoritos = "<ul>";
					for( int i = 0; i <= ( dtFavoritos.Rows.Count - 1 ); i++ )
					{
						contentFavoritos += "<li><a tabindex=\"-1\" href=\"" + dtFavoritos.Rows[i]["appURL"] + "\">" + dtFavoritos.Rows[i]["appName"] + "</a></li>";
					}
					contentFavoritos += "</ul>";
 					this.spFavoritos.InnerHtml = clsUtiles.getRoundedItem( headerFavoritos, contentFavoritos, clsUtiles.enuRoundBoxColor.Azul );
				}
			}
		}

		protected void btnLogIn_Click( object sender, EventArgs e )
		{
			try
			{
				TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
				System.Data.DataSet dsPerfil = AzuPass._LogOnPlus( this.txtEmail.Text, this.txtPasswd.Text,
					clsSettings.ApplicationFullName + " " + clsSettings.wsAzuPassShortName,
					clsSettings.ApplicationBaseURL,
					clsSettings.ApplicationFaseState );
				AzuPass = null;

				clsSettings.struSessionData SessionData = new clsSettings.struSessionData();
				SessionData.dtPerfil = dsPerfil.Tables["Perfil"].Copy();
				SessionData.dtFavoritos = dsPerfil.Tables["Favoritos"].Copy();
				clsSettings.SessionData = SessionData;

				// Crear y formar el Ticket
				FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
						1, // Version: Ticket version
						this.txtEmail.Text, // Name: Dirección de correo del usuario asociado con el ticket.
						DateTime.Now, // issueDate: Fecha/Hora del ticket.
						DateTime.Now.AddMinutes( HttpContext.Current.Session.Timeout ), // expiration: Fecha/Hora a la que expira.
						false, // isPersistent: "true" para una cookie persistente de usuario.
						this.txtPasswd.Text, // userData: Password del usuario para ser guardado en esta cookie (recuerda encriptarlo).
						FormsAuthentication.FormsCookiePath ); // cookiePath: Camino para el que es válida la cookie.

				// Cifrar la cookie para un transporte seguro.
				string encTicket = FormsAuthentication.Encrypt( ticket );
				// Crear la cookie
				System.Web.HttpCookie cookie = new HttpCookie( FormsAuthentication.FormsCookieName, encTicket ); // ticket con el Hash aplicado.
				// Establecer el tiempo de expiración de la cookie al tiempo de expiración del ticket .
				cookie.Expires = ticket.Expiration;
				FormsAuthentication.SetAuthCookie( this.txtEmail.Text, false, FormsAuthentication.FormsCookiePath );
				// Create the cookie.
				Response.Cookies.Add( cookie );
				Response.Cookies.Add( new HttpCookie( FormsAuthentication.FormsCookieName, encTicket ) );

				// Redireccionar a la URL solicitada, o la URL donde se encontraba 
				// cuando solicitó identificación
				string returnUrl = Request.QueryString["ReturnUrl"];
				if( ( returnUrl == null ) || ( returnUrl.ToLower().IndexOf( "index.aspx" ) > -1 ) )
				{
					// Url de retorno a la dirección donde se encuentra el usuario actualmente.
					returnUrl = Request.Url.ToString();
				}

				// No utilizar FormsAuthentication.RedirectFromLoginPage ya que 
				// reemplazaría el ticket de authentication (la cookie) que acabamos de agregar.
				Response.Redirect( returnUrl, false );
			}
			catch( System.Exception Ex )
			{
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.spLogOnNotification, Ex);
				ProcessMessage = null;
			}

		}

} // Fin de la clase.

} // Fin del namespace.