using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MedicoPorEspecialidad
    {
        public Medico medico { get; set; }
        public Especialidad Especialidades { get; set; }
        public HorarioLaboral HorariosLaborales { get; set; }
        public Sede Sede { get; set; }
    }
}
