using System;
using System.Collections.Generic;
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
                Medico medico = new Medico();
                MedicoNegocio nuevo = new MedicoNegocio();

                medico.Nombre = txtNombre.Text;
                medico.Apellido = txtApellido.Text;

                // Instanciar un objeto Especialidad y asignar su Id
               // medico.Especialidad = new Especialidad();
                //medico.Especialidad.id = long.Parse(ddlEspecialidades.SelectedValue);

                // Instanciar un objeto Sede y asignar su Id
               // medico.Sede = new Sede();
               // medico.Sede.IdSede = long.Parse(ddlSedes.SelectedValue);

                medico.Contraseña = txtContraseña.Text;
                medico.Estado = true;

                    if (Request.QueryString["Legajo"] != null)
                {
                    string legajo = Request.QueryString["Legajo"];
                    medico.Legajo = long.TryParse(legajo, out long legajoComoLong) ? legajoComoLong : 0; 
                    nuevo.Modificar(medico);
                }

                else

                { nuevo.AgregarMedico(medico); }

                Response.Redirect("Especialidades.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx");
        }
    }
}