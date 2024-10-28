using Core.Entidades;
using Estoque.Repository;
using Estoque.Services;
using Estoque.UseCases;
using TrabalhoFinal.Repository;

namespace TrabalhoFinal.Services;

public class UsuarioService : IUsuarioService
{
    public IUsuarioRepository repository { get; set; }
    private UsuarioUc Uc;
    public UsuarioService(string _config)
    {
        repository = new UsuarioRepository(_config);
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