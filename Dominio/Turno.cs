using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public EstadoTurno Estado { get; set; }
        public string Observaciones { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public Especialidad Especialidad { get; set; }
    }
    public enum EstadoTurno
    {
        Nuevo,
        Reprogramado,
        Cancelado,
        NoAsistio,
        Cerrado
    }
}
