using Estoque.Entidades;

namespace Estoque.Services
{
    public interface IFornecedorService
    {
        void Adicionar(Fornecedor fornecedor);
        void Remover(int id);
        void Editar(Fornecedor editFornecedor);
        List<Fornecedor> Listar();
        Fornecedor BuscarPorId(int id);
    }
}
