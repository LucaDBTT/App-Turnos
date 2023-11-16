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
    public partial class MedicosEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MedicoNegocio negocio = new MedicoNegocio();
                Session.Add("listaMedicos", negocio.ListarMedicosPorEspecialidad());
                dataGridViewMedicos.DataSource = Session["listaMedicos"];
                dataGridViewMedicos.DataBind();
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
            List<MedicoPorEspecialidad> listaMedicos = negocio.ListarMedicosPorEspecialidad();

            dataGridViewMedicos.DataSource = listaMedicos;
            dataGridViewMedicos.DataBind();
        }

    }
}