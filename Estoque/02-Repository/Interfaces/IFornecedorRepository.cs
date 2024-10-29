
using Estoque.Entidades;

namespace Estoque.Repository
{
    public interface IFornecedorRepository
    {
        public void Adicionar(Fornecedor fornecedor);
        public void Remover(int id);
        public void Editar(Fornecedor editFornecedor);
        public List<Fornecedor> Listar();
        public Fornecedor BuscarPorId(int id);
    }
}
