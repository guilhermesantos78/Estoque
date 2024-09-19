using Estoque.Entidades;
using Estoque.Repository;

namespace Estoque.Services
{
    public class UsuarioService
    {
        public UsuarioRepository repository { get; set; }
        public UsuarioService(string ConnectionString)
        {
            repository = new UsuarioRepository(ConnectionString);
        }
        public void Adicionar(Usuario usuario)
        {
            repository.Adicionar(usuario);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Usuario> Listar()
        {
            return repository.Listar();
        }
        public Usuario BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Usuario editPessoa)
        {
            repository.Editar(editPessoa);
        }
    }
}
