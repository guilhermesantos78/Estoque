
using Estoque.Entidades;

namespace Estoque.Services
{
    public interface IEmpresaService
    {
        public void Adicionar(Empresa empresa);
        public void Remover(int id);
        public void Editar(Empresa editEmpresa);
        public List<Empresa> Listar();
        public Empresa BuscarPorId(int id);
    }
}
