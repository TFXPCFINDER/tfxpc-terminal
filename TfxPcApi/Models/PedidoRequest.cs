using TfxPcApi.Models;

namespace TfxPcApi.Models;

public class PedidoRequest
{
    public int UsuarioId { get; set; }
    public List<ItemPedido> Itens { get; set; } = new();
}
