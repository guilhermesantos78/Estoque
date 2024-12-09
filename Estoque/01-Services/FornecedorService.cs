using Estoque.Repository;
using Estoque.Entidades;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository repository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            repository = fornecedorRepository;
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


        public ActionResult<IEnumerable<Fornecedor>> GetFornecedorByEmpresaId(int EmpresaId)
        {
            return repository.GetFornecedorByEmpresaId(EmpresaId);
        }

    }
}
