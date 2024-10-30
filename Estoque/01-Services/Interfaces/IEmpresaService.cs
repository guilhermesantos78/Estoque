using Estoque.Entidades;

namespace Estoque.Services
{
    public interface IEmpresaService
    {
        void Adicionar(Empresa empresa);
        void Remover(int id);
        void Editar(Empresa editEmpresa);
        List<Empresa> Listar();
        Empresa BuscarPorId(int id);
    }
}
