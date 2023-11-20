using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    //es una especie de clases con esos valores para usar
    public enum TipoUsuarios
    {
        NORMAL=1,
        ADMIN=2


    }
 

    public  class usuarios
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass{ get; set; }
        public TipoUsuarios TipoUsuario { get; set; }


        public usuarios(string user, string pass, bool admin)
        {
            User = user;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuarios.ADMIN : TipoUsuarios.NORMAL;
        }


    }
  

}
