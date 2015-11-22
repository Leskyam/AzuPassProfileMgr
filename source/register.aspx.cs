using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

namespace AzuPassProfileMgr
{
	public partial class clswfRegister : System.Web.UI.Page
	{

    override protected void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      //this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
      ScriptManager.GetCurrent(this).EnableScriptGlobalization = true;
      ScriptManager.GetCurrent(this).EnableScriptLocalization = true;
    }

		protected void Page_Load( object sender, EventArgs e )
		{

      /*
      try
      {

        throw new System.Exception("Mi mensaje de error.");

        //throw new System.InvalidCastException();
      }
      catch (System.Exception Ex)
      {
        Response.Write("<p><b>" + Ex.Message + "</b></p>");
      }
      */

      //Page.Response.ContentEncoding = System.Text.ASCIIEncoding.GetEncoding("iso-8859-1");

			try
			{
				// Limpiar la muestra del error.
				clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ClearPageErrorNotification( (System.Web.UI.HtmlControls.HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ) );
				ProcessMessage = null;

				if( !Page.IsPostBack )
				{
					TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
					AzuPass.AuthHeaderValue = clsSettings.getSoapHeader;
					System.Data.DataTable lstCatOcupacionales = AzuPass.PrepareNewProfile().Tables["lstCatOcupacionales"].Copy();

					// Llenar la lista de Cat ocupacionales
					foreach( DataRow dr in lstCatOcupacionales.Rows )
					{
						ListItem li = new ListItem( dr["Descripcion"].ToString(), dr["Id"].ToString() );
						this.cboCatOcupacional.Items.Add( li );
					}
          this.valRegExFechaNac.ValidationExpression = clsUtiles.getDatePatern();
					//this.txtFechaNac.Text = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
          // Que el control para seleccionar la fecha aparezca con un valor de fecha de 25 años atrás.
          this.calendarFechaNac.SelectedDate = System.DateTime.Now.AddYears(-25);
				}

        if (this.txtFechaNac.Text != string.Empty)
        {
          this.calendarFechaNac.SelectedDate = System.Convert.ToDateTime(this.txtFechaNac.Text);
        }

      }
			catch( System.Exception Ex )
			{
        clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Ex );
				ProcessMessage = null;
			}

		} // Fin de Page_Load
		
		protected void btnRegister_Click( object sender, EventArgs e )
		{
			try
			{
        // Revisar que la solicitud no sea un registro automatizado.
        if (IsPostBack)
        {
          NoBotState state;
          if (!NoBotRegister.IsValid(out state))
          {
            /*
            Posibles respuestas del control NoBot
              Valid: All NoBot tests passed; user appears to be human.
              InvalidBadResponse: An invalid response was provided to the challenge suggesting the challenge script was not run.
              InvalidResponseTooSoon: The postback occurred quickly enough that a human was probably not involved.
              InvalidAddressTooActive: The source IP address has submitted so many responses that a human was probably not involved.
              InvalidBadSession: The ASP.NET session state for this session was unusable.
              InvalidUnknown: An unknown problem occurred.
            */
            string stateExplication = string.Empty;
            switch (state.ToString())
            {
              case "Valid":
                {
                  break;
                }
              case "InvalidBadResponse":
                {
                  stateExplication = "Su navegador no respondi&oacute; correctamente a la ejecución de una subrutina necesaria para llevar a cabo esta operaci&oacute;n. Por favor, reint&eacute;ntelo y si el problema persiste verifique con el personal t&eacute;cnico que su navegador cumple con las condiciones necesarias para esto.";
                  break;
                }
              case "InvalidResponseTooSoon":
                {
                  stateExplication = "Usted ha realizado m&aacute;s de un intento de registro con un margen de tiempo muy breve entre cada uno de ellos. Por favor, realice su registro de manera adecuada y si tiene alguna dificultad para registrarse contacte con el personal t&eacute;nico pertienente.";
                  break;
                }
              case "InvalidAddressTooActive":
                {
                  stateExplication = "El origen (dirección IP) de donde proviene este intento de registro ha realizado demasiadas solicitudes al sistema. Por favor, reinténtelo y si el problema persiste verifique con el personal t&eacute;cnico pertienente.";
                  break;
                }
              case "InvalidBadSession":
                {
                  stateExplication = "EL tiempo de sesi&oacute;n activo para esta solicitud ha vencido. Por favor, reint&eacute;ntelo y si el problema persiste verifique con el personal t&eacute;cnico pertienente.";
                  break;
                }
              default: //"InvalidUnknown" y otros
                {
                  stateExplication = "Ha ocurrido un error desconocido que ha impedido su registro. Por favor, reint&eacute;ntelo y si el problema persiste verifique con el personal t&eacute;cnico pertienente.";
                  break;
                }
            }

            string strMessage = string.Format("Intento de registro rechazado. El intento de registro anterior ha parecido ser producto de una acci&oacute;n automatizada. " +
              "A continuaci&oacute;n el sistema le muestra detalles de lo ocurrido.<br />Nombre de la causa: {0} <br /> Explicaci&oacute;n: {1}", state.ToString(), stateExplication);

            System.Exception Ex = new System.Exception(strMessage);
            clsProcessMessage ProcessMessageNoBot = new clsProcessMessage();
            ProcessMessageNoBot.ShowSpanErrorNotification((HtmlGenericControl)this.wucHeader.FindControl(clsProcessMessage.spNotifyInformationName), Ex);
            Ex = null;
            ProcessMessageNoBot = null;
            return;
          }
        }
        
        TEICOCF.WebServices.AzuPass AzuPass = new TEICOCF.WebServices.AzuPass();
				AzuPass.AuthHeaderValue = clsSettings.getSoapHeader;
				System.DateTime FechaNac = System.Convert.ToDateTime( this.txtFechaNac.Text, System.Globalization.DateTimeFormatInfo.CurrentInfo );
				if( AzuPass.Register( this.txtNombre.Text, this.txtApellidos.Text, this.txtEmail.Text, FechaNac, this.radioSexo.SelectedValue == "M" ? TEICOCF.WebServices.enuSexo.M : TEICOCF.WebServices.enuSexo.F, System.Convert.ToInt32( this.cboCatOcupacional.SelectedValue ), this.txtIntereses.Text.Trim().Length == 0 ? string.Empty : this.txtIntereses.Text.Trim() ) )
				{
					clsProcessMessage ProcessMessage = new clsProcessMessage();
					string Message = "Usted ha sido registrado correctamente como usuario del servicio " +
						clsSettings.wsAzuPassShortName + ". Espere recibir un mensaje de correo electrónico " +
						"a la dirección " + this.txtEmail.Text + " con la información necesaria para utilizar " +
						"este servicio.";
					ProcessMessage.ShowSpanInfoNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Message );
					ProcessMessage = null;
				}
			}
			catch( System.Exception Ex)
			{
        clsProcessMessage ProcessMessage = new clsProcessMessage();
				ProcessMessage.ShowSpanErrorNotification( (HtmlGenericControl)this.wucHeader.FindControl( clsProcessMessage.spNotifyInformationName ), Ex );
				ProcessMessage = null;
			}
		}

    protected void NoBotRegister_CustomChallengeResponse(object sender, NoBotEventArgs e)
    {
      // This is a sample challenge/response implementation that involves
      // the DOM so as to make the calculation more difficult to thwart.
      // It adds a randomly sized Panel; the client must calculate the area.
      Panel p = new Panel();
      p.ID = "NoBotSamplePanel";
      Random rand = new Random();
      p.Width = rand.Next(300);
      p.Height = rand.Next(200);
      p.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
      p.Style.Add(HtmlTextWriterStyle.Position, "absolute");
      ((NoBot)sender).Controls.Add(p);
      e.ChallengeScript = string.Format("var e = document.getElementById('{0}'); e.offsetWidth * e.offsetHeight;", p.ClientID);
      e.RequiredResponse = (p.Width.Value * p.Height.Value).ToString();
    }

} // Fin de la clase.

} // Fin del namespace.