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
    public partial class TurnoObtenido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idSlot"] != null)
            {
                string idTurnoString = Request.QueryString["idSlot"];

                if (long.TryParse(idTurnoString, out long idTurno))
                {
                    CargarDetallesTurno(idTurno);
                }
            }
        }

        private void CargarDetallesTurno(long idTurno)
        {
            TurnosNegocio turnosNegocio = new TurnosNegocio();
            SlotsTurnos turno = turnosNegocio.ObtenerSlotPorId(idTurno);

            lblMedico.Text = turno.IdMedicoPorEspecialidad.ToString();
            lblDniPaciente.Text = turno.DniPaciente.ToString(); // Asegúrate de que DniPaciente sea un campo en tu clase SlotsTurnos
            lblFecha.Text = turno.Fecha.ToString("yyyy-MM-dd");
            lblHoraInicio.Text = turno.HoraInicio.ToString("hh\\:mm");
            lblHoraFin.Text = turno.HoraFin.ToString("hh\\:mm");
        }

    }
}