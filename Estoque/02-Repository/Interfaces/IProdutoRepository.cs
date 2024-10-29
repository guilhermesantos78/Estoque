
using Estoque.Entidades;
using Estoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Remover(int id);
        void Editar(Produto editProduto);
        List<ReadProdutoDTO> Listar();
        List<ReadProdutoComFornecedorDTO> VisualizarProdutoInfoFornecedor();
        Produto BuscarProdutoPorId(int id);
        ActionResult<IEnumerable<Produto>> GetProdutosByUsuarioId(int EmpresaId);
    }
}
