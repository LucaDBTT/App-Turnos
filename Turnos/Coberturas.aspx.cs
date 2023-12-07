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
    public partial class Coberturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] is Dominio.usuarios usuario && usuario.TipoUsuario == Dominio.TipoUsuarios.admin))
            {
                Session.Add("Error", "no eres administrador");
                Response.Redirect("Login.aspx", false);
            }
            if (!IsPostBack)
            {
                BindGridViewData();
            }
        }

        protected void dataCoberturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dataCoberturas.SelectedRow;
            string IdSede = dataCoberturas.DataKeys[selectedRow.RowIndex].Value.ToString();
            Response.Redirect("AgregarCobertura.aspx?idCobertura=" + IdSede);
        }

        private void BindGridViewData()
        {
            CoberturasNegocio negocio = new CoberturasNegocio();
            List <Cobertura> listaCoberturas = negocio.ListarCoberturas();

            dataCoberturas.DataSource = listaCoberturas;
            dataCoberturas.DataBind();
        }

        protected void dataCoberturas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cobertura = dataCoberturas.DataKeys[e.RowIndex].Value.ToString();
            CoberturasNegocio negocio = new CoberturasNegocio();
            negocio.bajaLogica(int.Parse(cobertura));
            BindGridViewData();
        }

        protected void dataCoberturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataCoberturas.PageIndex = e.NewPageIndex;
            BindGridViewData();
        }
    }
}