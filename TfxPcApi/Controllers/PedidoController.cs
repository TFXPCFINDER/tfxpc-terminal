using Microsoft.AspNetCore.Mvc;
using TfxPcApi.Models;
using TfxPcApi.Services;

namespace TfxPcApi.Controllers;

[ApiController]
[Route("pedidos")]
public class PedidoController : ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidoController(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpPost]
    public IActionResult CriarPedido([FromBody] PedidoRequest request)
    {
        var pedido = _pedidoService.CriarPedido(request.UsuarioId, request.Itens);
        if (pedido == null)
        {
            return BadRequest("Erro ao criar pedido. Verifique o estoque e IDs dos produtos.");
        }
        return Ok(pedido);
    }

    [HttpGet("usuario/{usuarioId}")]
    public IActionResult ListarPorUsuario(int usuarioId)
    {
        var pedidos = _pedidoService.ListarPedidosPorUsuario(usuarioId);
        return Ok(pedidos);
    }
}
