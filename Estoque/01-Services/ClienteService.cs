using Estoque.Entidades;
using Estoque.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Services
{
    public class ClienteService
    {
        public ClienteRepository repository { get; set; }

        public ClienteService(string ConnectionString)
        {
            repository = new ClienteRepository(ConnectionString);
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

        public Empresa BuscarEmpresaPorId(int id)
        {
            return repository.BuscarEmpresaPorId(id);
        }
    }
}
