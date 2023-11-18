using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace Turnos
{
    public partial class MedicosEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
            /*MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            dgvMedicoPorEspecialidad.DataSource = negocio.ListarMedicosPorEspecialidad();
            dgvMedicoPorEspecialidad.DataBind(); */
            MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            List<MedicoPorEspecialidad> listaMedicos = negocio.ListarMedicosPorEspecialidad();
            dgvMedicoPorEspecialidad.DataSource = listaMedicos;
            dgvMedicoPorEspecialidad.DataBind();
        }

        protected void dgvMedicoPorEspecialidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMedicoPorEspecialidad.PageIndex = e.NewPageIndex;
            CargarMedicos();
        }
        protected void dataGridViewMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = dgvMedicoPorEspecialidad.DataKeys[e.RowIndex].Value.ToString();

            if (long.TryParse(id, out long idComoLong))
            {
                MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
                negocio.bajaLogica(idComoLong);
                BindGridViewData();
            }
        }

        private void BindGridViewData()
        {
            MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            List<MedicoPorEspecialidad> listaMedicos = negocio.ListarMedicosPorEspecialidad();

            dgvMedicoPorEspecialidad.DataSource = listaMedicos;
            dgvMedicoPorEspecialidad.DataBind();
        }

    }
}