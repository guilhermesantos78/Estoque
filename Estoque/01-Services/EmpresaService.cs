using Estoque.Entidades;
using Estoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository repository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            repository = empresaRepository;
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

        public ActionResult<IEnumerable<Empresa>> GetEmpresaByEmpresaId(int EmpresaId)
        {
            return repository.GetEmpresaByEmpresaId(EmpresaId);
        }

    }
}
