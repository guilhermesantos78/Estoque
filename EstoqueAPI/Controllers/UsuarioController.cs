using AutoMapper;
using Core.Entidades;
using Estoque.Entidades;
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
    public UsuarioController(IMapper mapper, IUsuarioService service)
    {
        _mapper = mapper;
        _service = service;
    }
    /// <summary>
    /// EndPoint para Adicionar uma usuario
    /// </summary>
    /// <param name="usuarioDTO"></param>
    [HttpPost("adicionar-usuario")]
    public IActionResult AdicionarUsuario(Usuario usuarioDTO)
    {
        try
        {
            _service.Adicionar(usuarioDTO);
            return Ok();
        }
        catch (Exception erro)
        {
            return BadRequest($"Erro ao Adicionar Usuario, O Erro foi {erro.Message}");
        }
    }
    /// <summary>
    /// EndPoint para fazer login com um usuario
    /// </summary>
    /// <param name="usuarioLogin"></param>
    /// <returns></returns>
    [HttpPost("fazer-login")]
    public Usuario FazerLogin(UsuarioLoginDTO usuarioLogin)
    {
        try
        {
            Usuario usuario = _service.FazerLogin(usuarioLogin);
            return usuario;
        }
        catch (Exception erro)
        {
            throw new Exception($"Erro ao Fazer Login, O Erro foi {erro.Message}");
        }
    }
    /// <summary>
    /// EndPoint para Listar uma usuario
    /// </summary>
    /// <returns></returns>
    [HttpGet("listar-usuario")]
    public List<Usuario> ListarUsuario()
    {
        try
        {
            return _service.Listar();
        }
        catch (Exception erro)
        {
            throw new Exception($"Erro ao Listar Aluno, O Erro foi {erro.Message}");
        }
    }
    /// <summary>
    /// EndPoint para Editar uma usuario
    /// </summary>
    /// <param name="p"></param>
    [HttpPut("editar-usuario")]
    public IActionResult EditarUsuario(Usuario usuario, [FromQuery] int EmpresaId)
    {
        try
        {
            int userId = usuario.Id;
            Usuario user = ListarUsuarioPorId(userId);
            if (user.EmpresaId == EmpresaId)
            {
                _service.Editar(usuario);
                return Ok();
            }
            else
            {
                throw new Exception($"Erro ao Editar Usuario, Não ha um usuario cadastrado com esse id");
            }
        }
        catch (Exception erro)
        {
            return BadRequest($"Erro ao Editar Usuario, O Erro foi {erro.Message}");
        }
    }
    /// <summary>
    /// EndPoint para deletar uma usuario
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("deletar-usuario")]
    public IActionResult DeletarUsuario(int id, [FromQuery] int EmpresaId)
    {
        try
        {
            Usuario user = ListarUsuarioPorId(id);
            if (user.EmpresaId == EmpresaId)
            {
                _service.Remover(id);
                return Ok();
            }
            else
            {
                return BadRequest($"Erro ao Fornecedor Usuario. voce nao tem um Usuario com esse id Cadastrado");
            }
        }
        catch (Exception erro)
        {
            return BadRequest($"Erro ao Deletar Usuario, O Erro foi {erro.Message}");
        }
    }

    /// <summary>
    /// EndPoint para Listar uma usuario
    /// </summary>
    /// <returns></returns>
    [HttpGet("listar-usuario")]
    public Usuario ListarUsuarioPorId(int Id)
    {
        try
        {
            return _service.BuscarPorId(Id);
        }
        catch (Exception erro)
        {
            throw new Exception($"Erro ao Listar Aluno, O Erro foi {erro.Message}");
        }
    }



    /// <summary>
    /// Endpoint para Buscar um produto pelo id da empresa
    /// </summary>
    /// <param name="UsuarioId"></param>
    /// <returns></returns>
    [HttpGet("usuario/{UsuarioId}")]
    public ActionResult<IEnumerable<Usuario>> GetUsuarioByEmpresaId(int UsuarioId)
    {
        try
        {
            return _service.GetUsuarioByEmpresaId(UsuarioId);
        }
        catch (Exception erro)
        {
            throw new Exception($"Erro ao Visualizar Usuario By Usuario Id, O Erro foi {erro.Message}");
        }
    }
}