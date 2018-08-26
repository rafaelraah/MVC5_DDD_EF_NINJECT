using MVC5_DDD_EF_NINJECT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Domain.Interfaces.Repositories
{
    public  interface IRepositorioDePerfilDoUsuario : IRepositorioBase<PerfilUsuario>
    {
       List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario);
    }
}
