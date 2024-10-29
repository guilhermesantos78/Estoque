using Estoque.Entidades;
using Estoque.Repository;

namespace Estoque.Services
{
    public class EmpresaService : IEmpresaService
    {
        public IEmpresaRepository repository { get; set; }

        public EmpresaService(string ConnectionString)
        {
            repository = new EmpresaRepository(ConnectionString);
        }

        public void Adicionar(Empresa empresa)
        {
            repository.Adicionar(empresa);
        }

        public void Editar(Empresa empresaEdit)
        {
            repository.Editar(empresaEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Empresa> Listar()
        {
            return repository.Listar();
        }

        public Empresa BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
    }
}
