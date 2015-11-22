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
	public partial class clswfProfile : System.Web.UI.Page
	{
		// Para credenciales del usuario actual.
		private static string UserEmail = string.Empty;
		private static string UserPasswd = string.Empty;

    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      //this.lnkSave.Click += new System.EventHandler(this.lnkSave_Click);
    }

    protected void Page_Load( object sender, EventArgs e )
		{

			try
			{
				// Limpiar la muestra del error.
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ClearPageErrorNotification( (System.Web.UI.HtmlControls.HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ) );
				ProcessMessage = null;

				// Establecer los datos de las credenciales del usuario.
				FormsIdentity UserId = (FormsIdentity)User.Identity;
				FormsAuthenticationTicket UserTicket = UserId.Ticket;
				UserEmail = HttpContext.Current.User.Identity.Name;
				UserPasswd = UserTicket.UserData;

				if( !Page.IsPostBack )
				{
					TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
					AzuPass.AuthHeaderValue = clsSettings.getSoapHeader;
					System.Data.DataSet dsPerfil = AzuPass.EditProfile( UserEmail, UserPasswd );
					// Nombre
					this.txtNombre.Text = dsPerfil.Tables["tbl_Perfil"].Rows[0]["Nombre"].ToString();
					// Apellidos
					this.txtApellidos.Text = dsPerfil.Tables["tbl_Perfil"].Rows[0]["Apellidos"].ToString();
					// Fecha de nacimiento.
					this.txtFechaNac.Text = System.Convert.ToDateTime( dsPerfil.Tables["tbl_Perfil"].Rows[0]["FechaNac"] ).ToShortDateString();
          this.calendarFechaNac.SelectedDate = System.Convert.ToDateTime(this.txtFechaNac.Text);
					// Sexo
					this.radioSexo.SelectedIndex = dsPerfil.Tables["tbl_Perfil"].Rows[0]["Sexo"].ToString() == "F" ? 0 : 1;
					// Llenar la lista de Cat ocupacionales
					foreach( DataRow dr in dsPerfil.Tables["lst_CatOcupacional"].Rows )
					{
						ListItem li = new ListItem( dr["Descripcion"].ToString(), dr["Id"].ToString() );
						li.Selected = dr["Id"].ToString() == dsPerfil.Tables["tbl_Perfil"].Rows[0]["IdCatOcupacional"].ToString();
						this.cboCatOcupacional.Items.Add( li );
					}
					// Descripción de los intereses.
					this.txtDescripcionIntereses.Text = dsPerfil.Tables["tbl_Perfil"].Rows[0]["DescripIntereses"].ToString();
				}
			}
			catch( System.Exception Ex )
			{
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Ex );
				ProcessMessage = null;
			}
		
		} // Fin de Page_Load

		protected void lnkSave_Click( object sender, EventArgs e )
		{
			try
			{
				// Establecer los datos de las credenciales del usuario.
				FormsIdentity UserId = (FormsIdentity)User.Identity;
				FormsAuthenticationTicket UserTicket = UserId.Ticket;
				UserEmail = HttpContext.Current.User.Identity.Name;
				UserPasswd = UserTicket.UserData;

				TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
				AzuPass.AuthHeaderValue = clsSettings.getSoapHeader;
				System.DateTime FechaNac = System.Convert.ToDateTime( this.txtFechaNac.Text, System.Globalization.DateTimeFormatInfo.CurrentInfo );
				if( AzuPass.UpdateProfile( UserEmail, UserPasswd, this.txtNombre.Text, this.txtApellidos.Text, FechaNac, this.radioSexo.SelectedValue == "M" ? TEICOCF.WebServices.enuSexo.M : TEICOCF.WebServices.enuSexo.F, System.Convert.ToInt32( this.cboCatOcupacional.SelectedValue ), this.txtDescripcionIntereses.Text.Trim().Length == 0 ? string.Empty : this.txtDescripcionIntereses.Text.Trim() ) )
				{
					try
					{
						clsSettings.struSessionData SessionData = new clsSettings.struSessionData();
						SessionData.dtPerfil = clsSettings.SessionData.dtPerfil.Copy();
						SessionData.dtFavoritos = clsSettings.SessionData.dtFavoritos.Copy();
						SessionData.dtPerfil.Rows[0]["Nombre"] = this.txtNombre.Text.Trim();
						SessionData.dtPerfil.Rows[0]["Apellidos"] = this.txtApellidos.Text.Trim();
						SessionData.dtPerfil.Rows[0]["FechaNac"] = System.Convert.ToDateTime( this.txtFechaNac.Text );
						SessionData.dtPerfil.Rows[0]["Sexo"] = this.radioSexo.SelectedValue;
						clsSettings.SessionData = SessionData;
            
            // Establecer el nuevo valor para los controles (Ajax) sujetos a ejecución en el lado del cliente.
            this.calendarFechaNac.SelectedDate = System.Convert.ToDateTime(this.txtFechaNac.Text);

					}
					catch( System.Exception )
					{
						;
					}
					clsProcessMessage ProcessMessage = new clsProcessMessage();
					string Message = "Los datos de su perfil han sido guardados como lo solicitó.";
					ProcessMessage.ShowSpanInfoNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Message );
					ProcessMessage = null;
				}
				else
				{
					clsProcessMessage ProcessMessage = new clsProcessMessage();
					string Message = "No se cambiaron los datos de su perfil, se desconoce la razón de este comportamiento. Por favor, le sugerimos que lo intente " +
						"nuevamente. Si el problema persiste sírvase contactar con los administradores del servicio " + clsSettings.wsAzuPassShortName + ".";
					ProcessMessage.ShowSpanWarningNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), "Cambio de datos del perfil no efectuado.", Message );
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

		} // Fin de lnkSave_Click

	} // Fin de la clase.

} // Fin del namespace.