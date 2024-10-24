﻿using AutoMapper;
using Estoque.Services;
using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using Dapper;

namespace EstoqueAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class ProdutoController : ControllerBase
    {
        private ProdutoService _service;
        private readonly IMapper _mapper;
        private readonly string _connectionString = "Data Source=ESTOQUE.db";  // String de conexão para o banco SQLite
        public ProdutoController(IMapper mapper, IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _service = new ProdutoService(mapper, ConnectionString);
            _mapper = mapper;
        }

        [HttpPost("adicionar-produto")] // Rota (EndPoint)
        public void AdicionarProduto(CreateProdutoDTO p)
        {
            Produto produto = _mapper.Map<Produto>(p);

            _service.Adicionar(produto);
        }

        [HttpGet("visualizar-produto")] // Rota (EndPoint)
        public List<ReadProdutoDTO> VisualizarProduto()
        {
            return _service.Listar();
        }

        [HttpGet("VisualizarProdutoInfoFornecedor")] // Rota (EndPoint)
        public List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor(int FornecedorId)
        {
            return _service.VisualizarProdutoInfoFornecedor();
        }
        [HttpGet("BuscarProdutoPorId")] // Rota (EndPoint)
        public Produto BuscarProdutoPorId(int id)
        {
            return _service.BuscarProdutoPorId(id);
        }

        [HttpPut("editar-produto")] // Rota (EndPoint)
        public void Editarproduto(Produto produto)
        {
            _service.Editar(produto);
        }

        [HttpDelete("remover-produto")] // Rota (EndPoint)
        public void Removerproduto(int id)
        {
            _service.Remover(id);
        }

        [HttpGet("cliente/{UsuarioId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Produto>> GetProdutosByUsuarioId(int UsuarioId)
        {
            return _service.GetProdutosByUsuarioId(UsuarioId);
        }

    }
}
