﻿using Entidades;
using Repository;
using Services;
using System.Collections.Generic;

namespace Estoque.UseCases
{
    public class UsuarioUc
    {
        private UsuarioService _usuarioService;

        public UsuarioUc(string config)
        {
            _usuarioService = new UsuarioService(config);
        }

        public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
        {
            List<Usuario> listUsuario = _usuarioService.Listar();

            foreach (Usuario usuario in listUsuario)
            {
                if (usuario.Username == usuarioLogin.Username && usuario.Senha == usuarioLogin.Senha)
                {
                    return usuario;
                }
            }

            return null;
        }
    }
}