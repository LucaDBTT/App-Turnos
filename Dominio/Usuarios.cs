using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    //es una especie de clases con esos valores para usar
    namespace Dominio
    {
        // Enum TipoUsuarios
        public enum TipoUsuarios
        {
            paciente = 1,
            admin = 2,
            medico = 3
        }

    // Clase usuarios
    public class usuarios : Persona
    {
        public int Id { get; set; }
        
        public string User { get; set; }
        public string Pass { get; set; }
        public TipoUsuarios TipoUsuario { get; set; }

        // Constructor
        public usuarios(string user, string pass,bool isAdmin, bool isMedico, bool isPaciente)
        {
            User = user;
            Pass = pass;
            
            TipoUsuario = isAdmin ? TipoUsuarios.admin : (isMedico ? TipoUsuarios.medico : TipoUsuarios.paciente);
        }
    }
}
    
    
