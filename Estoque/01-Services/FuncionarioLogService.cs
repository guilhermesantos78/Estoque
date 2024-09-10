using Estoque.Repository;
using Estoque.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Services
{
    public class FuncionarioLogService
    {
        public FuncionarioLogRepository repository { get; set; }

        public FuncionarioLogService(string ConnectionString)
        {
            repository = new FuncionarioLogRepository(ConnectionString);
        }

        public void Adicionar(FuncionarioLog funcionario)
        {
            repository.Adicionar(funcionario);
        }

        public void Editar(FuncionarioLog funcionarioEdit)
        {
            repository.Editar(funcionarioEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<FuncionarioLog> Listar()
        {
            return repository.Listar();
        }

        public FuncionarioLog BuscarFuncionarioLogPorId(int id)
        {
            return repository.BuscarFuncionarioLogPorId(id);
        }
    }
}
