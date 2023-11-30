using Dominio;
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
    public partial class MisTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si el usuario ha iniciado sesión y determinar su tipo
                if (Session["Usuario"] != null)
                {
                        // Obtener el ID del paciente desde la sesión
                        long dni = ((Dominio.usuarios)Session["Usuario"]).dni;

                        // Crear instancia de DatosNegocio
                        DatosNegocio datosNegocio = new DatosNegocio();

                        // Obtener datos del paciente y sus turnos
                        DataTable datosPaciente = datosNegocio.ObtenerDatosPacienteYTurnos(dni);

                        // Vincular datos al GridView
                        dgvMisTurnos.DataSource = datosPaciente;
                        dgvMisTurnos.DataBind();
                    
                }
            }
        }
    }
}