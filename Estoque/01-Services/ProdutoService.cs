using AutoMapper;
using Estoque.Entidades;
using Estoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository repository;
        public readonly IMapper _Mapper;

        public ProdutoService(IMapper _mapper, IProdutoRepository produtoRepository)
        {
            repository = produtoRepository;
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
        public ActionResult<IEnumerable<Produto>> GetProdutosByEmpresaId(int EmpresaId)
        {
            return repository.GetProdutosByEmpresaId(EmpresaId);
        }

    }
}
