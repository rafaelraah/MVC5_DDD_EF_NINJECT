using MVC5_DDD_EF_NINJECT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_DDD_EF_NINJECT.Domain.Interfaces.Domain
{
    public interface IServicoDeUsuarioDomain
    {
        Usuario LogaUsuario(string email, string senha);
        Usuario RecuperaUsuarioPorEmail(string email);
        List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilDoUsuario);
    }
}
