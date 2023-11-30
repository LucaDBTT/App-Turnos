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
                if (Session["Usuario"] != null)
                {
                        long dni = ((Dominio.usuarios)Session["Usuario"]).dni;

                        DatosNegocio datosNegocio = new DatosNegocio();

                        DataTable datosPaciente = datosNegocio.ObtenerDatosPacienteYTurnos(dni);

                        dgvMisTurnos.DataSource = datosPaciente;
                        dgvMisTurnos.DataBind();
                    
                }
            }
        }

        protected void dgvMisTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CancelarTurno")
            {
                try
                {
                    long idSlot = Convert.ToInt64(e.CommandArgument);
                    TurnosNegocio eliminar = new TurnosNegocio();
                    eliminar.CancelarTurno(idSlot);

                    dgvMisTurnos.DataBind();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error al cancelar el turno: " + ex.Message);
                }
            }
        }


    }
}