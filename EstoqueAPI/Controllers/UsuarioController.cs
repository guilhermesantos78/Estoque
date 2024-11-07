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
    /// <summary>
    /// EndPoint para Adicionar uma usuario
    /// </summary>
    /// <param name="usuarioDTO"></param>
    [HttpPost("adicionar-usuario")]
    public void AdicionarAluno(Usuario usuarioDTO)
    {
        _service.Adicionar(usuarioDTO);
    }
    /// <summary>
    /// EndPoint para fazer login com um usuario
    /// </summary>
    /// <param name="usuarioLogin"></param>
    /// <returns></returns>
    [HttpPost("fazer-login")]
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        Usuario usuario = _service.FazerLogin(usuarioLogin);
        return usuario;
    }
    /// <summary>
    /// EndPoint para Listar uma usuario
    /// </summary>
    /// <returns></returns>
    [HttpGet("listar-usuario")]
    public List<Usuario> ListarAluno()
    {
        return _service.Listar();
    }
    /// <summary>
    /// EndPoint para Editar uma usuario
    /// </summary>
    /// <param name="p"></param>
    [HttpPut("editar-usuario")]
    public void EditarUsuario(Usuario p)
    {
        _service.Editar(p);
    }
    /// <summary>
    /// EndPoint para deletar uma usuario
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("deletar-usuario")]
    public void DeletarUsuario(int id)
    {
        _service.Remover(id);
    }
}