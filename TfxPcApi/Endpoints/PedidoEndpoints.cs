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
                try
                {
                    var novoPedido = service.RealizarPedido(pedido);
                    return Results.Created($"/pedidos/{novoPedido.Id}", novoPedido);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            app.MapGet("/pedidos/{usuarioId}", (int usuarioId, PedidoService service) =>
            {
                var pedidos = service.ListarPorUsuario(usuarioId);
                return Results.Ok(pedidos);
            });
        }
    }
}
