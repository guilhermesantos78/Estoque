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

        public void Adicionar(Cliente cliente)
        {
            repository.Adicionar(cliente);
        }

        public void Editar(Cliente ClienteEdit)
        {
            repository.Editar(ClienteEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Cliente> Listar()
        {
            return repository.Listar();
        }

        public Cliente BuscarClientePorId(int id)
        {
            return repository.BuscarClientePorId(id);
        }
    }
}
