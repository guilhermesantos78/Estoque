using Estoque._02_Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._01_Services
{
    public class FornecedorService
    {
        public FornecedorRepository repository { get; set; }

        public FornecedorService(IConfiguration configuration)
        {
            repository = new FornecedorRepository(configuration);
        }

        public void Adicionar(Fornecedor fornecedor)
        {
            repository.Adicionar(fornecedor);
        }

        public void Editar(int id, Fornecedor fornecedorEdit)
        {
            repository.Editar(id, fornecedorEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Fornecedor> Listar()
        {
            return repository.Listar();
        }

        public Fornecedor BuscarFornecedorPorId(int id)
        {
            return repository.BuscarFornecedorPorId(id);
        }
    }
}
