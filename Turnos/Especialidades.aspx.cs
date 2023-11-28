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
    public partial class Especialidades : System.Web.UI.Page
    {
        public bool filtroAvanzado {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["Usuario"] is Dominio.usuarios usuario && usuario.TipoUsuario == Dominio.TipoUsuarios.admin))
            {
                Session.Add("Error", "no eres administrador");
                Response.Redirect("Login.aspx", false);
            }
            filtroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                MedicoNegocio negocio = new MedicoNegocio();
                Session.Add("ListaMedicos", negocio.ListarMedicos());
                dataGridViewMedicos.DataSource = Session["ListaMedicos"];
                dataGridViewMedicos.DataBind();
            }
        }

        protected void dataGridViewMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dataGridViewMedicos.PageIndex = e.NewPageIndex;
            BindGridViewData();
        }

        private void BindGridViewData()
        {
            MedicoNegocio negocio = new MedicoNegocio();
            List<Medico> listaMedicos = negocio.ListarMedicos();

            dataGridViewMedicos.DataSource = listaMedicos;
            dataGridViewMedicos.DataBind();
        }

        protected void dataGridViewMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = dataGridViewMedicos.SelectedRow;
            string Legajo = dataGridViewMedicos.DataKeys[selectedRow.RowIndex].Value.ToString();
            Response.Redirect("AgregarMedico.aspx?Legajo=" + Legajo);
        }

        protected void dataGridViewMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string legajo = dataGridViewMedicos.DataKeys[e.RowIndex].Value.ToString();
            MedicoNegocio negocio = new MedicoNegocio();
            negocio.bajaLogica(int.Parse(legajo));
            BindGridViewData();
        }

        protected void Filtro_TextChanged(object sender, EventArgs e)
        {
            List<Medico> lista = (List<Medico>)Session["ListaMedicos"];
            List<Medico> listaFiltrada = lista.FindAll(x => x.Apellido.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dataGridViewMedicos.DataSource = listaFiltrada;
            dataGridViewMedicos.DataBind();  
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !filtroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if(ddlCampo.SelectedValue == "Sede" || ddlCampo.SelectedValue == "Especialidad" )
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio negocio = new MedicoNegocio();
                dataGridViewMedicos.DataSource=negocio.filtrar(ddlCampo.SelectedValue,
                    ddlCriterio.SelectedValue, 
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedValue);
                dataGridViewMedicos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}
