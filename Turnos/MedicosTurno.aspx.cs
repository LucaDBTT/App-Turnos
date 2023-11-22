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
    public partial class MedicosTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idEspecialidad"] != null)
                {
                    // Convierte el valor de la URL a un long (puedes cambiarlo según el tipo real)
                    long idEspecialidad;
                    if (long.TryParse(Request.QueryString["idEspecialidad"], out idEspecialidad))
                    {
                        // Carga los médicos por la especialidad específica
                        CargarMedicosPorEspecialidad(idEspecialidad);
                    }
                }
            }
        }

        private void CargarMedicos()
        {
            MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            List<MedicoPorEspecialidad> listaMedicos = negocio.ListarMedicosPorEspecialidad();
            dgvMedicoPorEspecialidad.DataSource = listaMedicos;
            dgvMedicoPorEspecialidad.DataBind();
        }

        protected void dgvMedicoPorEspecialidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMedicoPorEspecialidad.PageIndex = e.NewPageIndex;
            // Recarga los médicos por la especialidad específica
            CargarMedicosPorEspecialidad(Convert.ToInt64(Request.QueryString["idEspecialidad"]));
        }

        private void BindGridViewData()
        {
            MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            List<MedicoPorEspecialidad> listaMedicos = negocio.ListarMedicosPorEspecialidad();

            dgvMedicoPorEspecialidad.DataSource = listaMedicos;
            dgvMedicoPorEspecialidad.DataBind();
        }

        private void CargarMedicosPorEspecialidad(long idEspecialidad)
        {
            MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            List<MedicoPorEspecialidad> listaMedicos = negocio.Turnos(idEspecialidad);
            dgvMedicoPorEspecialidad.DataSource = listaMedicos;
            dgvMedicoPorEspecialidad.DataBind();
        }


    }

}