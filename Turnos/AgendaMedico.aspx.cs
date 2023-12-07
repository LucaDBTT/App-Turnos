using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnos
{
    public partial class AgendaMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] is Dominio.usuarios usuario && usuario.TipoUsuario == Dominio.TipoUsuarios.medico))
            {
                Session.Add("Error", "No eres un medico");
                Response.Redirect("Login.aspx", false);
            }

            if (Session["Usuario"] != null)
            {
                long dni = ((Dominio.usuarios)Session["Usuario"]).dni;
                {
                    DatosNegocio datosNegocio = new DatosNegocio();

                    DataTable datosPaciente = datosNegocio.ObtenerAgendaMedicos(dni);

                    dgvAgenda.DataSource = datosPaciente;
                    dgvAgenda.DataBind();
                }
            }
        }
    }
}