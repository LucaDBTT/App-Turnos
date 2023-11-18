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


            }
            ///configuracion Modificar
            string legajo = Request.QueryString["Legajo"] != null ? Request.QueryString["Legajo"].ToString() : "";
            if (legajo != "" && !IsPostBack)
            {
                MedicoPorEspecialidadNegocio negocio = new MedicoPorEspecialidadNegocio();
                // List<Medico> lista = negocio.ListarMedicos(legajo);
                // Medico seleccionado = lista[0];

                MedicoPorEspecialidad seleccionado = (negocio.ListarMedicosPorEspecialidad(legajo))[0];

                // Establecemos los campos como no modificables (readonly)
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;

                ///precargamos
                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellido;
                ddlEspecialidades.SelectedValue = seleccionado.IdEspecialidad.ToString();
                ddlSedes.SelectedValue = seleccionado.IdSede.ToString();

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //completar con el modificar
           /* MedicoPorEspecialidad medico = new MedicoPorEspecialidad();
            MedicoPorEspecialidadNegocio nuevo = new MedicoPorEspecialidadNegocio();

            medico.Nombre = txtNombre.Text;
            medico.Apellido = txtApellido.Text;

            if (Request.QueryString["Legajo"] != null)
            {
                string legajo = Request.QueryString["Legajo"];
                medico.Legajo = long.TryParse(legajo, out long legajoComoLong) ? legajoComoLong : 0;
                nuevo.Modificar(medico);
            }
            Response.Redirect("MedicosEspecialidad.aspx", false);*/
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicosEspecialidad.aspx");
        }
    }

  
}