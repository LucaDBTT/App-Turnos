﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario : Persona
    {
            public string Contrasena { get; set; }
            public string Rol { get; set; }
    }
}
