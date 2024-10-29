using Estoque.Entidades;

namespace Estoque.Repository
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa empresa);
        void Remover(int id);
        void Editar(Empresa editEmpresa);
        List<Empresa> Listar();
        Empresa BuscarPorId(int id);
    }
}
