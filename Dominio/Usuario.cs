using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    
    public class Usuario : Persona
    {
        public long IdUsuario { get; set; }
        public Coberturas Cobertura { get; set; }
        public long NroAfiliado { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
       }
}
