namespace Estoque.Repository.Data.Script
{
    public class HistoricoPedidoScript
    {
        public static string InsertHistoricoPedido()
        {
            string commandINSERTPedido = @"
                INSERT INTO HistoricoPedidos (ProdutoId, Data, QuantidadeAlterada, TipoAlteracao)
                VALUES (@ProdutoId, @Data, @QuantidadeAlterada, @TipoAlteracao)";

            return commandINSERTPedido;
        }
    }
}
