using Estoque.Entidades;

namespace Estoque.Services
{
    public interface IFornecedorService
    {
        public void Adicionar(Fornecedor fornecedor);
        public void Remover(int id);
        public void Editar(Fornecedor editFornecedor);
        public List<Fornecedor> Listar();
        public Fornecedor BuscarPorId(int id);
    }
}
