using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnos
{
    public partial class Patologias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] is Dominio.usuarios usuario && usuario.TipoUsuario == Dominio.TipoUsuarios.admin))
            {
                Session.Add("Error", "no eres administrador");
                Response.Redirect("Login.aspx", false);
            }
            if (!IsPostBack)
            {
                BindGridViewData();
            }
        }
        protected void dataGridViewMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataGridViewMedicos.PageIndex = e.NewPageIndex;
            BindGridViewData();
        }

        private void BindGridViewData()
        {
            EspecialidadesNegocio negocio = new EspecialidadesNegocio();
            List<Especialidad> listaEspecialidad = negocio.ListarEspecialidades();

            dataGridViewMedicos.DataSource = listaEspecialidad;
            dataGridViewMedicos.DataBind();
        }

        protected void dataGridViewMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dataGridViewMedicos.SelectedRow;
            string Id = dataGridViewMedicos.DataKeys[selectedRow.RowIndex].Value.ToString();
            Response.Redirect("AgregarEspecialidad.aspx?id=" + Id);
        }

        protected void dataGridViewMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string legajo = dataGridViewMedicos.DataKeys[e.RowIndex].Value.ToString();
            EspecialidadesNegocio negocio = new EspecialidadesNegocio();
            negocio.bajaLogica(int.Parse(legajo));
            BindGridViewData();
        }
    }
}
