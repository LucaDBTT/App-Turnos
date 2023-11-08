using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Persona
    {
        public long Legajo { get; set; }
        public Especialidad Especialidad { get; set; }
        public Sede Sede { get; set; }
        public string Contraseña { get; set; }
        public bool  Estado { get; set; }
    }
}
