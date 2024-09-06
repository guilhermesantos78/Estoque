using Estoque._02_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque._01_Services
{
    public class ProdutoService
    {
        public ProdutoRepository repository { get; set; }

        public ProdutoService(string Connection)
        {
            repository = new ProdutoRepository(Connection);
        }

        public void Adicionar(Produto produto)
        {
            repository.Adicionar(produto);
        }

        public void Editar(Produto ProdutoEdit)
        {
            repository.Editar(ProdutoEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Produto> Listar()
        {
            return repository.Listar();
        }

        public Produto BuscarProdutoPorId(int id)
        {
            return repository.BuscarProdutoPorId(id);
        }
    }
}
