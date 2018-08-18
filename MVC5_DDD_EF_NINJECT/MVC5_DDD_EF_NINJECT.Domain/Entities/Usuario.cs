using System;

namespace MVC5_DDD_EF_NINJECT.Domain.Entities
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPerfilUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual PerfilUsuario PerfilUsuario { get; set; }
    }
}
