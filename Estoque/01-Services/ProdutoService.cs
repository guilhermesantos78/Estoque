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

        public ProdutoService()
        {
            repository = new ProdutoRepository();
        }

        public void Adicionar(Produto produto)
        {
            repository.Adicionar(produto);
        }

        public void Editar(int id, Produto ProdutoEdit)
        {
            repository.Editar(id, ProdutoEdit);
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
