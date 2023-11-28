using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Turnos
{
    public partial class UserDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] is Dominio.usuarios usuario && usuario.TipoUsuario == Dominio.TipoUsuarios.paciente))
            {
                Session.Add("Error", "No eres un paciente");
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void ButtonUse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx", false);
        }
    }
}