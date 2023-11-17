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
            MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            dgvMedicoPorEspecialidad.DataSource = negocio.ListarMedicosPorEspecialidad();
            dgvMedicoPorEspecialidad.DataBind(); 
        }
    }
}