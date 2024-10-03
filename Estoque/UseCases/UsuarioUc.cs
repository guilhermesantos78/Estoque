using Entidades;
using Repository;
using Services;

namespace Estoque.UseCases
{
    public class UsuarioUc
    {
        UsuarioService _UsuarioService;
        public UsuarioUc(string _config)
        {
            _UsuarioService = new UsuarioService(_config);
        }

        public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
        {
            List<Usuario> listUsuario = _UsuarioService.Listar();
            foreach (Usuario usuario in listUsuario)
            {
                if (usuario.Username == usuarioLogin.Username
                    && usuario.Senha == usuarioLogin.Senha)
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}
