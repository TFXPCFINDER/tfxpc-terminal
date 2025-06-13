using Microsoft.AspNetCore.Mvc;
using TfxPcApi.Models;
using TfxPcApi.Services;

namespace TfxPcApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public IActionResult RealizarPedido([FromBody] Pedido pedido)
        {
            try
            {
                var novoPedido = _pedidoService.RealizarPedido(pedido);
                return Created($"/pedidos/{novoPedido.Id}", novoPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioId}")]
        public IActionResult ListarPorUsuario(int usuarioId)
        {
            var pedidos = _pedidoService.ListarPorUsuario(usuarioId);
            return Ok(pedidos);
        }
    }
}
