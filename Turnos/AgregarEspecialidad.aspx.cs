using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnos
{
    public partial class AgregarEspecialidad : System.Web.UI.Page
    {
      /*  protected void Page_Load(object sender, EventArgs e)
        {
            string legajo = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (legajo != "" && !IsPostBack)
            {
                EspecialidadesNegocio negocio = new EspecialidadesNegocio();
                // List<Medico> lista = negocio.ListarMedicos(legajo);
                // Medico seleccionado = lista[0];

                Especialidad seleccionado = (negocio.ListarEspecialidades(legajo))[0];

                ///precargamos
                txtNombre.Text = seleccionado.Nombre;
                txtURLImagen.Text = seleccionado.URLimagen;
                imgEspecialidad.ImageUrl = seleccionado.URLimagen; // Agregar esta línea
                imgEspecialidad.Visible = !string.IsNullOrEmpty(seleccionado.URLimagen); // Mostrar la imagen solo si la URL no está vacía

            }
           
        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string legajo = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (!string.IsNullOrEmpty(legajo))
                {
                    EspecialidadesNegocio negocio = new EspecialidadesNegocio();
                    Especialidad seleccionado = (negocio.ListarEspecialidades(legajo))[0];

                    // Precargamos para especialidad existente
                    txtNombre.Text = seleccionado.Nombre;
                    txtURLImagen.Text = seleccionado.URLimagen;
                    imgEspecialidad.ImageUrl = seleccionado.URLimagen;
                    imgEspecialidad.Visible = !string.IsNullOrEmpty(seleccionado.URLimagen);
                }
                else
                {
                    // Establecer valores predeterminados para nueva especialidad
                    imgEspecialidad.ImageUrl = txtURLImagen.Text;  // Puedes establecer una URL de imagen predeterminada si es necesario
                    imgEspecialidad.Visible = !string.IsNullOrEmpty(txtURLImagen.Text);
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Especialidad especialidad = new Especialidad();
                EspecialidadesNegocio nuevo = new EspecialidadesNegocio();

                especialidad.Nombre = txtNombre.Text;
                especialidad.URLimagen = txtURLImagen.Text;
                string nombre = especialidad.Nombre;

                if (Request.QueryString["id"] != null)
                {
                    string legajo = Request.QueryString["id"];
                    especialidad.id= long.TryParse(legajo, out long legajoComoLong) ? legajoComoLong : 0;
                    nuevo.Modificar(especialidad);
                }
             
                else

                { nuevo.AgregarEspecialidad(especialidad); }

                Response.Redirect("Patologias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patologias.aspx");
        }

        protected void txtURLImagen_TextChanged(object sender, EventArgs e)
        {
            // Mostrar la imagen al ingresar la URL
            imgEspecialidad.ImageUrl = txtURLImagen.Text;
            imgEspecialidad.Visible = !string.IsNullOrEmpty(txtURLImagen.Text);
        }
    }
}