using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        protected void btnLimpiarTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.LimpiarTurnos();
                }

                // Recargar o realizar cualquier acción adicional después de limpiar los turnos
                // Puedes recargar la página o realizar alguna otra lógica según tus necesidades
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al limpiar los turnos: " + ex.Message);
            }
        }

       
        private void CargarMedicosPorEspecialidad(long idEspecialidad)
        {
            MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
            List<MedicoPorEspecialidad> listaMedicos = negocio.Turnos(idEspecialidad);
            dgvMedicoPorEspecialidad.DataSource = listaMedicos;
            dgvMedicoPorEspecialidad.DataBind();
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