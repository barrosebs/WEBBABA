using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BABA.Application.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}