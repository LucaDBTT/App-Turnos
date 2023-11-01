using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Usuario : Persona
    {
        public Coberturas Cobertura { get; set; }
        public int NroAfiliado { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

    }
}
