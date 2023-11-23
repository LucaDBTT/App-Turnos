using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class SlotsTurnos
    {
        public long IdSlot { get; set; }
        public long IdMedicoPorEspecialidad { get; set; }
        public long DniPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Estado { get; set; }
    }
}
