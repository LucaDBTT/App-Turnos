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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MedicoNegocio negocio = new MedicoNegocio();
                List<Medico> listaMedicos = negocio.ListarMedicos();

                dataGridViewMedicos.DataSource = listaMedicos;
                dataGridViewMedicos.DataBind();
            }
        }
    }
}