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
    public partial class AgregarCobertura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string legajo = Request.QueryString["idCobertura"] != null ? Request.QueryString["idCobertura"].ToString() : "";
            if (legajo != "" && !IsPostBack)
            {
                CoberturasNegocio negocio = new CoberturasNegocio();
                // List<Medico> lista = negocio.ListarMedicos(legajo);
                // Medico seleccionado = lista[0];

                Cobertura seleccionado = (negocio.ListarCoberturas(legajo))[0];

                ///precargamos
                txtNombre.Text = seleccionado.Nombre;

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coberturas.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cobertura cobertura = new Cobertura();
                CoberturasNegocio nuevo = new CoberturasNegocio();

                cobertura.Nombre = txtNombre.Text;


                if (Request.QueryString["idCobertura"] != null)
                {
                    string legajo = Request.QueryString["idCobertura"];
                    cobertura.idCobertura = long.TryParse(legajo, out long legajoComoLong) ? legajoComoLong : 0;
                    nuevo.Modificar(cobertura);
                }

                else

                { nuevo.AgregarCobertura(cobertura); }

                Response.Redirect("Coberturas.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}