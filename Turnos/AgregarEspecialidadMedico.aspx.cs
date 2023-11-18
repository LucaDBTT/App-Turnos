using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using static System.Collections.Specialized.BitVector32;

namespace Turnos
{
    public partial class ModificarEspecialidadMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MedicoNegocio medicosNegocio = new MedicoNegocio(); // Debes implementar esta función
                ddlLegajos.DataSource = medicosNegocio.ListarMedicos();
                ddlLegajos.DataTextField = "Legajo"; // Ajusta esto según la propiedad de tu objeto Medico que contiene el legajo
                ddlLegajos.DataValueField = "Legajo"; // Ajusta esto según la propiedad de tu objeto Medico que contiene el legajo
                ddlLegajos.DataBind();

                SedeNegocio sedeNegocio = new SedeNegocio();
                ddlSedes.DataSource = sedeNegocio.ListarSedes();
                ddlSedes.DataTextField = "nombreSede";  // Nombre de la propiedad a mostrar en el DropDownList
                ddlSedes.DataValueField = "IdSede";      // Nombre de la propiedad para el valor de las opciones
                ddlSedes.DataBind();

                EspecialidadesNegocio especialidadNegocio = new EspecialidadesNegocio();
                ddlEspecialidades.DataSource = especialidadNegocio.ListarEspecialidades();
                ddlEspecialidades.DataTextField = "Nombre";  // Nombre de la propiedad a mostrar en el DropDownList
                ddlEspecialidades.DataValueField = "Id";      // Nombre de la propiedad para el valor de las opciones
                ddlEspecialidades.DataBind();

                HorarioLaboralNegocio horarioLaboralNegocio = new HorarioLaboralNegocio();
                List<HorarioLaboral> listaHorarios = horarioLaboralNegocio.ListarHorarios();

                // Concatenar la información de los horarios para mostrar en el DropDownList
                foreach (HorarioLaboral horario in listaHorarios)
                {
                    string horarioConcatenado = $"{horario.DiaSemana} - {horario.HoraInicio.ToString(@"hh\:mm")} a {horario.HoraFin.ToString(@"hh\:mm")}";
                    ddlHorarios.Items.Add(new ListItem(horarioConcatenado, horario.IdHorario.ToString()));
                }


            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            MedicoPorEspecialidad medico = new MedicoPorEspecialidad();
            MedicoPorEspecialidadNegocio nuevo = new MedicoPorEspecialidadNegocio();

            // Verifica si se proporcionó un legajo válido en la consulta.

                medico.Legajo = ObtenerValorSeleccionado(ddlLegajos);

                medico.IdEspecialidad = ObtenerValorSeleccionado(ddlEspecialidades);
                medico.IdSede = ObtenerValorSeleccionado(ddlSedes);
                medico.IdHorario = ObtenerValorSeleccionado(ddlHorarios);

                nuevo.AgregarMedico(medico);

                // Redirige a la página de Médicos por Especialidad.
                Response.Redirect("MedicosEspecialidad.aspx");


        }

        // Método auxiliar para obtener el valor seleccionado de un DropDownList.
        private int ObtenerValorSeleccionado(DropDownList ddl)
        {
            if (ddl.SelectedItem != null && int.TryParse(ddl.SelectedItem.Value, out int valor))
            {
                return valor;
            }
            return 0; // Puedes cambiar el valor predeterminado según sea necesario.
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicosEspecialidad.aspx");
        }
    }


}