﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Turnos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            usuarios usuario;// creo una instancia de usuario
            UsuariosNegocio negocio = new UsuariosNegocio(); // y de negiocio
           
            try
            {
                usuario = new usuarios(txtUser.Text, txtPass.Text,false,false, false );//guardo los datos en la instancia de usuario
                if (negocio.loguear(usuario))// con el metodo vemos si es correcto lo ingresado y si es correcto en este caso lo mando a default
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Logeado.aspx", false);
                }
                else
                {
                    Session.Add("error", "user o pass incorrectas"); // y si no a una pantalla de error
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error ", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx", false);
        }
    }
}