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
using AjaxControlToolkit;

namespace AzuPassProfileMgr
{
  public partial class clswfResendPasswd : System.Web.UI.Page
  {
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      this.Load += new System.EventHandler(this.Page_Load);
      //this.btnResendPasswd.Click += new System.EventHandler(this.btnResendPasswd_Click);
      ScriptManager.GetCurrent(this).EnableScriptGlobalization = true;
      ScriptManager.GetCurrent(this).EnableScriptLocalization = true;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

      try
      {
        // Limpiar la muestra del error.
        clsProcessMessage ProcessMessage = new clsProcessMessage();
        ProcessMessage.ClearPageErrorNotification((System.Web.UI.HtmlControls.HtmlGenericControl)this.wucHeader.FindControl(clsProcessMessage.spNotifyInformationName));
      }
      
      catch (System.Exception Ex)
      {
        clsProcessMessage ProcessMessage = new clsProcessMessage();
        ProcessMessage.ShowSpanErrorNotification((HtmlGenericControl)this.wucHeader.FindControl(clsProcessMessage.spNotifyInformationName), Ex);
        ProcessMessage = null;
      }
    }

    protected void btnResendPasswd_Click(object sender, EventArgs e)
    {
      try
      {
        // Revisar que la solicitud no sea un registro automatizado.
        if (IsPostBack)
        {
          NoBotState state;
          if (!NoBotResendPasswd.IsValid(out state))
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
                  stateExplication = "Su navegador no respondi&oacute; correctamente a la ejecuci&oacute;n de una subrutina necesaria para llevar a cabo esta operaci&oacute;n. Por favor, reint&eacute;ntelo y si el problema persiste verifique con el personal t&eacute;cnico que su navegador cumple con las condiciones necesarias para esto.";
                  break;
                }
              case "InvalidResponseTooSoon":
                {
                  stateExplication = "Usted ha realizado m&aacute;s de un intento de reenv&iacute;o de contrase&ntilde;a con un margen de tiempo muy breve entre cada uno de ellos. Por favor, solicite el reenv&iacute;o de su contrase&ntilde;a de manera adecuada y si tiene alguna dificultad para ello contacte con el personal t&eacute;nico pertienente.";
                  break;
                }
              case "InvalidAddressTooActive":
                {
                  stateExplication = "El origen (direcci&oacute;n IP) de donde proviene este intento de reenv&iacute;o de contrase&ntilde;a ha realizado demasiadas solicitudes al sistema. Por favor, reint&eacute;ntelo y si el problema persiste verifique con el personal t&eacute;cnico pertienente.";
                  break;
                }
              case "InvalidBadSession":
                {
                  stateExplication = "EL tiempo de sesión activo para esta solicitud ha vencido. Por favor, reinténtelo y si el problema persiste verifique con el personal t&eacute;cnico pertienente.";
                  break;
                }
              default: //"InvalidUnknown" y otros
                {
                  stateExplication = "Ha ocurrido un error desconocido que ha impedido su registro. Por favor, reinténtelo y si el problema persiste verifique con el personal t&eacute;cnico pertienente.";
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
        if (AzuPass.resendWelcomeEmail(this.txtEmail.Text))
        {
          clsProcessMessage ProcessMessage = new clsProcessMessage();
          string Message = "Su contrase&ntilde;a ha sido enviada satisfactoriamente a la direcci&oacute;n: \"" + this.txtEmail.Text + "\". Cuando recepcione el correo " +
            "utilice la <a target=\"_self\" tabIndex=\"-1\" href=\"" + clsSettings.ApplicationBaseURL + "\">p&aacute;gina de inicio</a> de esta aplicaci&oacute;n " +
            "para verificar que tiene acceso al servicio \"" + clsSettings.wsAzuPassShortName + "\".";
          ProcessMessage.ShowSpanInfoNotification((HtmlGenericControl)this.wucHeader.FindControl(clsProcessMessage.spNotifyInformationName), Message);
          ProcessMessage = null;

        }
        else
        {
          clsProcessMessage ProcessMessage = new clsProcessMessage();
          string Message = "No se ha enviado su contrase&ntilde;a a la direcci&oacute;n electr&oacute;nica: \"" + this.txtEmail.Text + "\", se desconoce la raz&oacute;n de este comportamiento, " + 
            "probablemente el servicio de correo configurado para esta opci&oacute;n no est&aacute; disponible en estos momentos. Por favor, le sugerimos que lo intente " +
            "nuevamente. Si el problema persiste sírvase contactar con los administradores del servicio \"" + clsSettings.wsAzuPassShortName + "\".";
          ProcessMessage.ShowSpanWarningNotification((HtmlGenericControl)this.wucHeader.FindControl(clsProcessMessage.spNotifyInformationName), "Envío de contraseña no efectuado.", Message);
          ProcessMessage = null;
        }
        AzuPass = null;
      }

      catch (System.Exception Ex)
      {
        clsProcessMessage ProcessMessage = new clsProcessMessage();
        ProcessMessage.ShowSpanErrorNotification((HtmlGenericControl)this.wucHeader.FindControl(clsProcessMessage.spNotifyInformationName), Ex);
        ProcessMessage = null;
      }
    }

    protected void NoBotResnedPasswd_CustomChallengeResponse(object sender, NoBotEventArgs e)
    {
      // This is a sample challenge/response implementation that involves
      // the DOM so as to make the calculation more difficult to thwart.
      // It adds a randomly sized Panel; the client must calculate the area.
      Panel p = new Panel();
      p.ID = "NoBotResendPasswd";
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
