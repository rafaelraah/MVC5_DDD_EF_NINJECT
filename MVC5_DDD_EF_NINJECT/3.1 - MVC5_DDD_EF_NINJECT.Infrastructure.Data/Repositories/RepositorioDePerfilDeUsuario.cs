using MVC5_DDD_EF_NINJECT.Domain.Entities;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Repositories;
using ProjetoDDD.Infrastructure.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Infrastructure.Data.Repositories
{
    public class RepositorioDePerfilDeUsuario : RepositoryBase<PerfilUsuario>, IRepositorioDePerfilDoUsuario
    {
        public List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario)
        {
            var perfil = _contexto.PerfisUsuarios.Where(x => x.IdPerfilUsuario == idPerfilUsuario).FirstOrDefault();
            return perfil.Usuarios.ToList();
        }
    }
}
