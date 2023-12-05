using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace Turnos
{
    public partial class AgregarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDiasSemana();
            CargarSedes();
            CargarEspecialidades();
            CargarHorarios(ddlHorarioInicio);
            CargarHorarios(ddlHorarioFin);
            // Configuración Modificar
            string legajo = Request.QueryString["Legajo"] != null ? Request.QueryString["Legajo"].ToString() : "";
            if (legajo != "" && !IsPostBack)
            {
                MedicoNegocio negocio = new MedicoNegocio();
                List<Medico> lista = negocio.ListarMedicos(legajo);

                // Verificar si la lista tiene elementos antes de acceder al primero
                if (lista.Count > 0)
                {
                    Medico seleccionado = lista[0];

                    // Precargamos los datos
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtContraseña.Attributes["value"] = seleccionado.Contraseña;
                }
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int minutosInicio = int.Parse(ddlHorarioInicio.SelectedValue);
                int minutosFin = int.Parse(ddlHorarioFin.SelectedValue);

                // Crear objetos TimeSpan a partir de los minutos
                TimeSpan horarioInicio = TimeSpan.FromMinutes(minutosInicio);
                TimeSpan horarioFin = TimeSpan.FromMinutes(minutosFin);
               

        
                // Realizar la validación
                if (EsHorarioFinMenorOIgual(horarioInicio, horarioFin))
                {
                    // Mostrar un mensaje de error o realizar otras acciones necesarias
                    lblMensajeError.Text = "El horario de fin debe ser mayor al horario de inicio.";
                    return;
                }

                Medico medico = new Medico();
                MedicoNegocio nuevo = new MedicoNegocio();

                MedicoPorEspecialidadNegocio medicoEsp = new MedicoPorEspecialidadNegocio();
                MedicoPorEspecialidad medicoPorEspecialidad = new MedicoPorEspecialidad();

                HorarioLaboralNegocio horarioLaboralNegocio = new HorarioLaboralNegocio();
                HorarioLaboral horarioLaboral = new HorarioLaboral();

                UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
                usuarios Usuarios = new usuarios(txtMail.Text, txtContraseña.Text, long.Parse(txtDni.Text), false, true, false);

                Sede sede = new Sede();
                SedeNegocio sedeNegocio = new SedeNegocio();
                List<Sede> sedes= sedeNegocio.ListarSedes();

                sede.NombreSede = ddlSedes.SelectedValue;
                sedeNegocio.AgregarSede(sede);    
               
                Especialidad especialidad = new Especialidad();
                EspecialidadesNegocio especialidadesNegocio = new EspecialidadesNegocio();

                especialidad.Nombre = ddlEspecialidad2.SelectedValue;
                especialidadesNegocio.AgregarEspecialidad(especialidad);


                medico.Nombre = txtNombre.Text;
                medico.Apellido = txtApellido.Text;
                medico.Mail = txtMail.Text;
                medico.Contraseña=txtContraseña.Text;
                medico.dni=long.Parse(txtDni.Text);
                medico.Estado = true;
                nuevo.AgregarMedico(medico);
                

                horarioLaboral.IdProfesional = long.Parse(medico.Legajo.ToString());
                horarioLaboral.HoraInicio = horarioInicio;
                horarioLaboral.HoraFin = horarioFin;
                horarioLaboral.DiaSemana = ddlDiasLaborales.SelectedValue;
                horarioLaboralNegocio.AgregarHorarioLaboral(horarioLaboral);

                Usuarios.Apellido = txtApellido.Text;
                Usuarios.Nombre = txtNombre.Text;
                Usuarios.dni = long.Parse(txtDni.Text);
                Usuarios.User = txtMail.Text;
                Usuarios.Pass = txtContraseña.Text;
                Usuarios.IdEntidad = long.Parse(medico.Legajo.ToString());
                usuariosNegocio.RegistrarUsuarios(Usuarios);

                medicoPorEspecialidad.Apellido=txtApellido.Text;
                medicoPorEspecialidad.Mail=txtMail.Text;
                medicoPorEspecialidad.NombreEspecialidad = ddlEspecialidad2.SelectedValue;
                medicoPorEspecialidad.DiaSemana = ddlDiasLaborales.SelectedValue;
                medicoPorEspecialidad.IdEspecialidad = long.Parse(especialidad.id.ToString());
                medicoPorEspecialidad.IdHorario = long.Parse(horarioLaboral.IdHorario.ToString());
                medicoPorEspecialidad.IdSede = long.Parse(sede.IdSede.ToString());
                medicoPorEspecialidad.Legajo = long.Parse(medico.Legajo.ToString());
                medicoPorEspecialidad.HoraInicio = horarioInicio;
                medicoPorEspecialidad.HoraFin = horarioFin;
                medicoEsp.AgregarMedico(medicoPorEspecialidad);

                // Instanciar un objeto Especialidad y asignar su Id
                // medico.Especialidad = new Especialidad();
                //medico.Especialidad.id = long.Parse(ddlEspecialidades.SelectedValue);

                // Instanciar un objeto Sede y asignar su Id
                // medico.Sede = new Sede();
                // medico.Sede.IdSede = long.Parse(ddlSedes.SelectedValue);




                /*        if (Request.QueryString["Legajo"] != null)
                    {
                        string legajo = Request.QueryString["Legajo"];
                        medico.Legajo = long.TryParse(legajo, out long legajoComoLong) ? legajoComoLong : 0; 
                        nuevo.Modificar(medico);
                    }

                    else

                    {*/




               
                    

                

                Response.Redirect("Especialidades.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
        private bool EsHorarioFinMenorOIgual(TimeSpan horarioInicio, TimeSpan horarioFin)
        {
            
            // Realizar la comparación
            return horarioFin <= horarioInicio;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx");
        }

        private void CargarDiasSemana()
        {
            // Obtener los nombres de los días de la semana
            string[] diasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

            // Asignar la lista al DropDownList
            ddlDiasLaborales.DataSource = diasSemana;
            ddlDiasLaborales.DataBind();
        }

        private void CargarSedes()
        {
            SedeNegocio sedes = new SedeNegocio();
            ddlSedes.DataSource = sedes.ListarSedes();
            ddlSedes.DataTextField = "NombreSede";
            ddlSedes.DataBind();
        }

        private void CargarEspecialidades()
        {
            EspecialidadesNegocio especialidadesNegocio = new EspecialidadesNegocio();
            ddlEspecialidad2.DataSource = especialidadesNegocio.ListarEspecialidades();
            ddlEspecialidad2.DataTextField = "Nombre";
            ddlEspecialidad2.DataBind();
        }

        private void CargarHorarios(DropDownList ddl)
        {
            // Llenar el DropDownList con horarios de 8:00 a 21:00 en intervalos de 30 minutos
            for (int hora = 8; hora <= 21; hora++)
            {
                for (int minuto = 0; minuto < 60; minuto += 30)
                {
                    int minutosDesdeMedianoche = (hora * 60) + minuto;
                    TimeSpan tiempo = TimeSpan.FromMinutes(minutosDesdeMedianoche);

                    string horaFormato24 = $"{tiempo.Hours:D2}:{tiempo.Minutes:D2}";
                    ddl.Items.Add(new ListItem(horaFormato24, minutosDesdeMedianoche.ToString()));
                }
            }
        }

        protected void btnAgregarNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarSede.aspx", false);
        }


        protected void btnAgregarEspecialidad2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEspecialidad.aspx", false);
        }
    }
}