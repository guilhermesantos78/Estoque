using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Services
{
    public interface IFornecedorService
    {
        void Adicionar(Fornecedor fornecedor);
        void Remover(int id);
        void Editar(Fornecedor editFornecedor);
        List<Fornecedor> Listar();
        Fornecedor BuscarPorId(int id);
        ActionResult<IEnumerable<Fornecedor>> GetFornecedorByEmpresaId(int EmpresaId);
    }
}
