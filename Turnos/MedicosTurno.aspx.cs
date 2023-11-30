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
                dgvMedicoPorEspecialidad.RowDataBound += dgvMedicoPorEspecialidad_RowDataBound;
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

        protected void dgvMedicoPorEspecialidad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlSlotsTurno = (DropDownList)e.Row.FindControl("ddlSlotsTurno");
                TurnosNegocio turnos = new TurnosNegocio();

                if (ddlSlotsTurno != null)
                {
                    int idMedico = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "idMedicoPorEspecialidad"));
                    DataTable slotsTurnoDataTable = turnos.ObtenerSlotsTurnoPorMedico(idMedico);

                    ddlSlotsTurno.DataSource = slotsTurnoDataTable;
                    ddlSlotsTurno.DataTextField = "fechaHoraInicio";
                    ddlSlotsTurno.DataValueField = "idSlot";
                    ddlSlotsTurno.DataBind();


                    ddlSlotsTurno.Visible = true;
                }
            }
        }

        protected void lnkTurno_Click(object sender, EventArgs e)
        {
            LinkButton lnkTurno = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnkTurno.NamingContainer;

            DropDownList ddlSlotsTurno = (DropDownList)row.FindControl("ddlSlotsTurno");

            long idSlotSeleccionado = Convert.ToInt64(ddlSlotsTurno.SelectedValue);

            if (Session["Usuario"] is Dominio.usuarios usuario)
            {
                long dni = usuario.dni;

                TurnosNegocio turnosNegocio = new TurnosNegocio();
                turnosNegocio.OcuparTurno(idSlotSeleccionado, dni);
                Response.Redirect($"MisTurnos.aspx?idSlot={idSlotSeleccionado}");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

}