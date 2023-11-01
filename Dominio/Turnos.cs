using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Turnos
    {
        public int idTurno { get; set; }
        public Usuario usuario { get; set; }
        public Medico medico { get; set; }
        public DateTime fechaTurno { get; set; }
        public Sede sede { get; set; }
        public Consultas tipoConsulta { get; set; }
        public bool estado { get; set; }
        public string HoraInicio { get; set; }
        /*
         *Preguntar a los profes que es mas adecuado, si entrada y salida solamente, o agregarle el timespan para determinar
         *la duracion de dicho turno
         * public string HoraFin { get; set; }
        public int MyProperty { get; set; }

        public TimeSpan Duracion { get; set; }*/

    }
}
