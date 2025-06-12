using System.Collections.Generic;
using TfxPcApi.Models;

namespace TfxPcApi.Services
{
    public class PedidoService
    {
        private static List<Pedido> pedidos = new();
        private static int proximoId = 1;
        private readonly ProdutoService _produtoService;
        private readonly UsuarioService _usuarioService;

        public PedidoService(ProdutoService produtoService, UsuarioService usuarioService)
        {
            _produtoService = produtoService;
            _usuarioService = usuarioService;
        }

        public bool RealizarPedido(Pedido pedido)
        {
            var usuario = _usuarioService.ObterPorId(pedido.UsuarioId);
            if (usuario == null)
                return false;

            foreach (var item in pedido.Itens)
            {
                var produto = _produtoService.ObterPorId(item.ProdutoId);
                if (produto == null || produto.Estoque < item.Quantidade)
                    return false;
            }

            foreach (var item in pedido.Itens)
            {
                _produtoService.AtualizarEstoque(item.ProdutoId, item.Quantidade);
            }

            pedido.Id = proximoId++;
            pedidos.Add(pedido);
            return true;
        }

        public List<Pedido> ListarPorUsuario(int usuarioId)
        {
            return pedidos.Where(p => p.UsuarioId == usuarioId).ToList();
        }
    }
}
