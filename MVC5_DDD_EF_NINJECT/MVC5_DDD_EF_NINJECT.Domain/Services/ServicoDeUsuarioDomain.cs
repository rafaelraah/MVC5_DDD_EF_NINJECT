using MVC5_DDD_EF_NINJECT.Domain.Entities;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Domain;
using MVC5_DDD_EF_NINJECT.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace MVC5_DDD_EF_NINJECT.Domain.Services
{
    public class ServicoDeUsuarioDomain : IServicoDeUsuarioDomain
    {
        private readonly IRepositorioDeUsuarios _repositorioUsuario;
        private readonly IRepositorioDePerfilDoUsuario _repositorioPerfil;

        public ServicoDeUsuarioDomain(IRepositorioDeUsuarios repositorioUsuario, IRepositorioDePerfilDoUsuario repositorioPerfil)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioPerfil = repositorioPerfil;
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            //Regras sempre aqui
            var usuarioRetorno = _repositorioUsuario.LogaUsuario(email, senha);
            return usuarioRetorno;
        }

        public Usuario RecuperaUsuarioPorEmail(string email)
        {
            var usuarioRetorno = _repositorioUsuario.RecuperarUsuarioPorEmail(email);
            return usuarioRetorno; 
        }

        public List<Usuario> RecuperaUsuariosDoPerfil(int idPerfilDoUsuario)
        {
            var usuariosDoPerfil = _repositorioPerfil.RetornaUsuariosDoPerfil(idPerfilDoUsuario);
            return usuariosDoPerfil;
        }
    }
}
