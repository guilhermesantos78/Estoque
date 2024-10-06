using Core.Entidades;
using Estoque.UseCases;
using TrabalhoFinal.Repository;

namespace TrabalhoFinal.Services;

public class UsuarioService
{
    public UsuarioRepository repository { get; set; }
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
    public Usuario BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Usuario editPessoa)
    {
        repository.Editar(editPessoa);
    }
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        Usuario usuario = Uc.FazerLogin(usuarioLogin);
        return usuario;
    }
}