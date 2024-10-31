using AutoMapper;
using Core.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal.Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly IMapper _mapper;
    public UsuarioController( IMapper mapper, IUsuarioService service)
    {
        _mapper = mapper;
        _service = service;
    }
    [HttpPost("adicionar-usuario")]
    public void AdicionarAluno(Usuario usuarioDTO)
    {
        _service.Adicionar(usuarioDTO);
    }
    [HttpPost("fazer-login")]
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        Usuario usuario = _service.FazerLogin(usuarioLogin);
        return usuario;
    }
    [HttpGet("listar-usuario")]
    public List<Usuario> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpPut("editar-usuario")]
    public void EditarUsuario(Usuario p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-usuario")]
    public void DeletarUsuario(int id)
    {
        _service.Remover(id);
    }
}