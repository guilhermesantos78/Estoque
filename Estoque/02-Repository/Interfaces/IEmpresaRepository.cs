using Estoque.Entidades;

namespace Estoque.Repository
{
    public interface IEmpresaRepository
    {
        public void Adicionar(Empresa empresa);
        public void Remover(int id);
        public void Editar(Empresa editEmpresa);
        public List<Empresa> Listar();
        public Empresa BuscarPorId(int id);
    }
}
