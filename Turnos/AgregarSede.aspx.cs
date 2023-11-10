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
    public partial class AgregarSede : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string legajo = Request.QueryString["IdSede"] != null ? Request.QueryString["IdSede"].ToString() : "";
            if (legajo != "" && !IsPostBack)
            {
                SedeNegocio negocio = new SedeNegocio();
                // List<Medico> lista = negocio.ListarMedicos(legajo);
                // Medico seleccionado = lista[0];

                Sede seleccionado = (negocio.ListarSedes(legajo))[0];

                ///precargamos
                txtNombre.Text = seleccionado.NombreSede;

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Sede sede = new Sede();
                SedeNegocio nuevo = new SedeNegocio();

                sede.NombreSede = txtNombre.Text;


                if (Request.QueryString["IdSede"] != null)
                {
                    string legajo = Request.QueryString["IdSede"];
                    sede.IdSede = long.TryParse(legajo, out long legajoComoLong) ? legajoComoLong : 0;
                    nuevo.Modificar(sede);
                }

                else

                { nuevo.AgregarMedico(sede); }

                Response.Redirect("Sedes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sedes.aspx", false);
        }
    }
}