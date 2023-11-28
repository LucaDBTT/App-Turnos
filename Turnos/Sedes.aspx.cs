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
    public partial class Sedes : System.Web.UI.Page
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
            SedeNegocio negocio = new SedeNegocio();
            List<Sede> listaSede = negocio.ListarSedes();

            dataGridViewMedicos.DataSource = listaSede;
            dataGridViewMedicos.DataBind();
        }

        protected void dataGridViewMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dataGridViewMedicos.SelectedRow;
            string IdSede = dataGridViewMedicos.DataKeys[selectedRow.RowIndex].Value.ToString();
            Response.Redirect("AgregarSede.aspx?IdSede=" + IdSede);
        }

        protected void dataGridViewMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sede = dataGridViewMedicos.DataKeys[e.RowIndex].Value.ToString();
            SedeNegocio negocio = new SedeNegocio();
            negocio.bajaLogica(int.Parse(sede));
            BindGridViewData();
        }
    }
}
