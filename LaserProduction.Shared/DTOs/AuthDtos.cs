using System;
using System.Collections.Generic;
using System.Text;

namespace LaserProduction.Shared.DTOs
{
    
        public class LoginDto
        {
            public string Login { get; set; }
            public string Senha { get; set; }
        }

        public class NovoUsuarioDto
        {
            public string Nome { get; set; }
            public string Login { get; set; }
            public string Senha { get; set; }
            public string Perfil { get; set; }
        }
    }

