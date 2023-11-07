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
    public partial class Especialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            MedicoNegocio negocio = new MedicoNegocio();
            List<Medico> listaMedicos = negocio.ListarMedicos();

            dataGridViewMedicos.DataSource = listaMedicos;
            dataGridViewMedicos.DataBind();
        }

        protected void dataGridViewMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dataGridViewMedicos.SelectedRow;
            string Legajo = dataGridViewMedicos.DataKeys[selectedRow.RowIndex].Value.ToString();
            Response.Redirect("Modificar.aspx?Legajo=" + Legajo);
        }
    }
}