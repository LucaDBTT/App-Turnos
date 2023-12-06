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
    public partial class Usuarios : System.Web.UI.Page
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

        protected void dataGridViewUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataGridViewUsuarios.PageIndex = e.NewPageIndex;
            BindGridViewData();
        }

        private void BindGridViewData()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> listaUsuarios = negocio.ListarUsuarios();

            dataGridViewUsuarios.DataSource = listaUsuarios;
            dataGridViewUsuarios.DataBind();
        }


        protected void dataGridViewUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long dni = (long)dataGridViewUsuarios.DataKeys[e.RowIndex].Value;
            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.BajaLogica(dni);
            BindGridViewData();
        }

    }
}