using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public interface IEmpresaService
    {
        void Adicionar(Empresa empresa);
        void Remover(int id);
        void Editar(Empresa editEmpresa);
        List<Empresa> Listar();
        Empresa BuscarPorId(int id);
        public ActionResult<IEnumerable<Empresa>> GetEmpresaByEmpresaId(int EmpresaId);
    }
}
