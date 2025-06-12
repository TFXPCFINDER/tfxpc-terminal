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

        public Pedido RealizarPedido(Pedido pedido)
        {
            var usuario = _usuarioService.ObterPorId(pedido.UsuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            foreach (var item in pedido.Itens)
            {
                var produto = _produtoService.ObterPorId(item.ProdutoId);
                if (produto == null)
                    throw new Exception($"Produto ID {item.ProdutoId} não encontrado.");

                if (produto.Estoque < item.Quantidade)
                    throw new Exception($"Estoque insuficiente para o produto: {produto.Nome}");
            }

            foreach (var item in pedido.Itens)
            {
                _produtoService.AtualizarEstoque(item.ProdutoId, item.Quantidade);
            }

            pedido.Id = proximoId++;
            pedidos.Add(pedido);
            return pedido;
        }

        public List<Pedido> ListarPorUsuario(int usuarioId)
        {
            return pedidos.Where(p => p.UsuarioId == usuarioId).ToList();
        }
    }
}
