using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa empresa);
        void Remover(int id);
        void Editar(Empresa editEmpresa);
        List<Empresa> Listar();
        Empresa BuscarPorId(int id);
        ActionResult<IEnumerable<Empresa>> GetEmpresaByEmpresaId(int EmpresaId);
    }
}
