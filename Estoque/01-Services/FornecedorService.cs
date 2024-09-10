using Estoque._02_Repository;
using Estoque._03_Entidades;
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

        public Fornecedor BuscarFornecedorPorId(int id)
        {
            return repository.BuscarFornecedorPorId(id);
        }
    }
}
