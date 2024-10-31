using Core.Entidades;
using Estoque.Repository;
using Estoque.Services;

namespace TrabalhoFinal.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository repository;
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        repository = usuarioRepository;
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
    public Usuario BuscarPorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Usuario editPessoa)
    {
        repository.Editar(editPessoa);
    }
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        List<Usuario> listUsuario = Listar();

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