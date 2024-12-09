
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Repository
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Remover(int id);
        void Editar(Usuario usuario);
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        ActionResult<IEnumerable<Usuario>> GetUsuarioByEmpresaId(int EmpresaId);
    }
}
