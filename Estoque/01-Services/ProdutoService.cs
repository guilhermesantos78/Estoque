using AutoMapper;
using Estoque.Entidades;
using Estoque.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;

namespace Estoque.Services
{
    public class ProdutoService : IProdutoService
    {
        public IProdutoRepository repository { get; set; }
        public readonly IMapper _Mapper;

        public ProdutoService(IMapper _mapper, string Connection)
        {
            repository = new ProdutoRepository(_mapper, Connection);
            _Mapper = _mapper;
        }

        public void Adicionar(Produto produto)
        {
            repository.Adicionar(produto);
        }

        public void Editar(Produto ProdutoEdit)
        {
            repository.Editar(ProdutoEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<ReadProdutoDTO> Listar()
        {
            return repository.Listar();
        }

        public List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor()
        {
            return repository.VisualizarProdutoInfoFornecedor();
        }

        public Produto BuscarProdutoPorId(int id)
        {
            return repository.BuscarProdutoPorId(id);
        }
        public ActionResult<IEnumerable<Produto>> GetProdutosByUsuarioId(int UsuarioId)
        {
            return repository.GetProdutosByUsuarioId(UsuarioId);
        }

    }
}
