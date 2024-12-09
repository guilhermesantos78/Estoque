using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public interface IProdutoService
    {
        void Adicionar(Produto produto);
        void Remover(int id);
        void Editar(Produto editProduto);
        List<ReadProdutoDTO> Listar();
        List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor();
        Produto BuscarProdutoPorId(int id);
        ActionResult<IEnumerable<Produto>> GetProdutosByEmpresaId(int EmpresaId);
    }
}
