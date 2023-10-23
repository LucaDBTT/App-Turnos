using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Persona
    {
        public List<Especialidad> Especialidades { get; set; }
        public string HorarioTrabajo { get; set; }
    }
}
