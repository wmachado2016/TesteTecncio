using System;

namespace BackEnd.Models
{
    public class Usuarios : Entidade
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnumEscolaridade Escolaridade { get; set; }
        public bool Ativo { get; set; }
    }
}
