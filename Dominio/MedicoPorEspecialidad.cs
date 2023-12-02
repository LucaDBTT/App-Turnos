using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MedicoPorEspecialidad: Persona
    {
        public long idMedicoPorEspecialidad {  get; set; }
        public long Legajo { get; set; }
        public string Contraseña { get; set; }
        public bool Estado { get; set; }

        // Propiedades de la especialidad
        public long IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }

        // Propiedades de la sede
        public long IdSede { get; set; }
        public string NombreSede { get; set; }

        // Propiedades del horario laboral
        public long IdHorario { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
