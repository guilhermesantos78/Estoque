using Estoque.Repository;
using Estoque.Entidades;

namespace Estoque.Services
{
    public class FornecedorService : IFornecedorService
    {
        public IFornecedorRepository repository { get; set; }

        public FornecedorService(string ConnectionString)
        {
            repository = new FornecedorRepository(ConnectionString);
        }

        public void Adicionar(Fornecedor fornecedor)
        {
            repository.Adicionar(fornecedor);
        }

        public void Editar(Fornecedor fornecedorEdit)
        {
            repository.Editar(fornecedorEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Fornecedor> Listar()
        {
            return repository.Listar();
        }

        public Fornecedor BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
    }
}
