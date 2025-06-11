using TfxPcApi.Models;

namespace TfxPcApi.Services;

public class PedidoService
{
    private readonly List<Pedido> _pedidos = new();
    private int _proximoId = 1;

    private readonly ProdutoService _produtoService;

    public PedidoService(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public Pedido? CriarPedido(int usuarioId, List<ItemPedido> itens)
    {
        // Validar e atualizar estoque
        foreach (var item in itens)
        {
            var produto = _produtoService.BuscarPorId(item.ProdutoId);
            if (produto == null || produto.Estoque < item.Quantidade)
                return null;

            _produtoService.AtualizarEstoque(item.ProdutoId, item.Quantidade);
            item.PrecoUnitario = produto.Preco; // Garante o valor correto
        }

        var pedido = new Pedido
        {
            Id = _proximoId++,
            UsuarioId = usuarioId,
            Itens = itens,
            DataPedido = DateTime.Now
        };

        _pedidos.Add(pedido);
        return pedido;
    }

    public List<Pedido> ListarPedidosPorUsuario(int usuarioId)
    {
        return _pedidos.Where(p => p.UsuarioId == usuarioId).ToList();
    }

    public Pedido? BuscarPorId(int id)
    {
        return _pedidos.FirstOrDefault(p => p.Id == id);
    }
}
