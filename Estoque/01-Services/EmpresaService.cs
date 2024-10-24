using Estoque.Entidades;
using Estoque.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Services
{
    public class EmpresaService
    {
        public EmpresaRepository repository { get; set; }

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

        public Empresa BuscarEmpresaPorId(int id)
        {
            return repository.BuscarEmpresaPorId(id);
        }
    }
}
