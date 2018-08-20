using System;
using System.Collections.Generic;

namespace MVC5_DDD_EF_NINJECT.Domain.Entities
{
    public partial class PerfilUsuario
    {
        public PerfilUsuario()
        {
            this.Usuarios = new List<Usuario>();
            this.ModulosAcessos = new List<ModulosAcesso>(); 
        }

        public int IdPerfilUsuario { get; set; }
        public string NomePerfil { get; set; } 
        public DateTime DataCadastro { get; set; }
        public bool FlAtivo { get; set; }
        public bool FlAdminMaster { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<ModulosAcesso> ModulosAcessos { get; set; }
    }
}
