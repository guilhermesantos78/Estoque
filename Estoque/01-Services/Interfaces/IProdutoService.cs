using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public interface IProdutoService
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
