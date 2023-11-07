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
    public partial class Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
                CargarEspecialidades();
            }
        }

        private void CargarSedes()
        {
            SedeNegocio sedeNegocio = new SedeNegocio();
            ddlSedes.DataSource = sedeNegocio.ListarSedes();
            ddlSedes.DataTextField = "nombreSede";  // Nombre de la propiedad a mostrar en el DropDownList
            ddlSedes.DataValueField = "ídSede";      // Nombre de la propiedad para el valor de las opciones
            ddlSedes.DataBind();
        }

        private void CargarEspecialidades()
        {
            EspecialidadesNegocio especialidadNegocio = new EspecialidadesNegocio();
            ddlEspecialidades.DataSource = especialidadNegocio.ListarEspecialidades();
            ddlEspecialidades.DataTextField = "Nombre";  // Nombre de la propiedad a mostrar en el DropDownList
            ddlEspecialidades.DataValueField = "Id";      // Nombre de la propiedad para el valor de las opciones
            ddlEspecialidades.DataBind();
        }
    }
}