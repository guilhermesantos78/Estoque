
using Estoque.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public interface IFornecedorRepository
    {
        void Adicionar(Fornecedor fornecedor);
        void Remover(int id);
        void Editar(Fornecedor editFornecedor);
        List<Fornecedor> Listar();
        Fornecedor BuscarPorId(int id);
        ReadFornecedorDTO BuscarFornecedorNamePorId(int id);
        ActionResult<IEnumerable<Fornecedor>> GetFornecedorByEmpresaId(int EmpresaId);
    }
}
