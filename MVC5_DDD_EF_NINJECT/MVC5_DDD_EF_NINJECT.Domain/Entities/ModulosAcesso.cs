using System;
using System.Collections;
using System.Collections.Generic;

namespace MVC5_DDD_EF_NINJECT.Domain.Entities
{
    public partial class ModulosAcesso
    {
        public ModulosAcesso()
        {
            this.PerfisUsuario = new List<PerfilUsuario>(); 
        }

        public int IdModuloAcesso { get; set; }
        public string NomeModulo { get; set; }
        public string NomeMenuAcesso { get; set; }
        public string UrlMenu { get; set; }
        public bool FlAtivo { get; set; }
        public DateTime DataCadastro;
        public int? IdModuloPai { get; set; }
        public virtual ModulosAcesso ModulosAcessos { get; set; }
        public virtual ICollection<PerfilUsuario> PerfisUsuario { get; set; }
    }
}