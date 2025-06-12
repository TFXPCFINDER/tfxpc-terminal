using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TfxPcApi.Models;
using TfxPcApi.Services;

namespace TfxPcApi.Endpoints
{
    public static class PedidoEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/pedidos", (Pedido pedido, PedidoService service) =>
            {
                var sucesso = service.RealizarPedido(pedido);
                if (!sucesso)
                    return Results.BadRequest("Estoque insuficiente ou usuário inválido");

                return Results.Ok(pedido);
            });

            app.MapGet("/pedidos/{usuarioId}", (int usuarioId, PedidoService service) =>
            {
                var pedidos = service.ListarPorUsuario(usuarioId);
                return Results.Ok(pedidos);
            });
        }
    }
}
