namespace LojaVirtual.Models
{

    public class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal => Produto.Preco * Quantidade;

        public ItemPedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return $"{Produto.Nome} - Qtd: {Quantidade} - Subtotal: R${Subtotal}";
        }
    }
}
