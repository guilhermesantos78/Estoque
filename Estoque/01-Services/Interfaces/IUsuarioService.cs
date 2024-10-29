using Core.Entidades;

namespace Estoque.Services
{
    public interface IUsuarioService
    {
        void Adicionar(Usuario usuario);
        void Remover(int id);
        void Editar(Usuario usuario);
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        Usuario FazerLogin(UsuarioLoginDTO usuarioLogin);
    }
}
