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
    public class RepositorioDeUsuario : RepositoryBase<Usuario>, IRepositorioDeUsuarios
    {
        public Usuario LogaUsuario(string Email, string Senha)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == Email).FirstOrDefault();
            if(usuario == null)
            {
                return null;
            }

            //Totalmente possível mudar a forma de criptografia
            /**
             *  Fica bastante seguro fazer desta maneira. Ele buscará o usuário pelo e-mail, e só então.. 
             *  que ele irá pegar do banco de dados a chave de criptografia e vai fazer a devida verificação.
             *  Tem que fazer desta maneira, DESCRIPTOGRAFAR para testar, não ao contrário, pois...
             *  se eu criptografar a senha para testar, cada vez que criptografa gerá uma criptografia diferente, um hash diferente
             */
            string passDecrypt = Crypto.DecryptStringAES(usuario.Senha, usuario.SenhaKey);

            if(passDecrypt == Senha)
            {
                return usuario;
            }
            else
            {
                return null;
            }

        }

        public Usuario RecuperarUsuarioPorEmail(string Email)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == Email).FirstOrDefault();
            return usuario;
        }
    }
}
