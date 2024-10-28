
using Estoque.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public interface IProdutoRepository
    {
        public void Adicionar(Produto produto);
        public void Remover(int id);
        public void Editar(Produto editProduto);
        public List<ReadProdutoDTO> Listar();
        public List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor();
        public Produto BuscarProdutoPorId(int id);
        public ActionResult<IEnumerable<Produto>> GetProdutosByUsuarioId(int EmpresaId);
    }
}
