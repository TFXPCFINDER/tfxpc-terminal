namespace TfxPcApi.Models;

public class Pedido
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public List<ItemPedido> Itens { get; set; } = new();
    public decimal Total => Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
    public DateTime DataPedido { get; set; } = DateTime.Now;
}
