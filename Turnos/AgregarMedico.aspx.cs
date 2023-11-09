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
        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            ///configuarion agregar
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
            if (legajo != null)
            {
                MedicoNegocio negocio = new MedicoNegocio();
               // List<Medico> lista = negocio.ListarMedicos(legajo);
               // Medico seleccionado = lista[0];

                Medico seleccionado = (negocio.ListarMedicos(legajo))[0];

                ///precargamos
                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellido;
                txtContraseña.Text = seleccionado.Contraseña;        
                ddlEspecialidades.SelectedValue = seleccionado.Especialidad.Id.ToString();
                ddlSedes.SelectedValue = seleccionado.Sede.IdSede.ToString();


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
                medico.Especialidad = new Especialidad();
                medico.Especialidad.Id = long.Parse(ddlEspecialidades.SelectedValue);

                // Instanciar un objeto Sede y asignar su Id
                medico.Sede = new Sede();
                medico.Sede.IdSede = long.Parse(ddlSedes.SelectedValue);

                medico.Contraseña = txtContraseña.Text; ;
                medico.Estado = true;

                nuevo.AgregarMedico(medico);

                Response.Redirect("Especialidades.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnElminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            string legajo = Request.QueryString["Legajo"];

            try
            {
                if (chkConfirmaEliminacion.Checked) { 
                MedicoNegocio negocio = new MedicoNegocio();
                negocio.bajaLogica(int.Parse(legajo));
                Response.Redirect("Especialidades.aspx",false);
                
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }



    }
}