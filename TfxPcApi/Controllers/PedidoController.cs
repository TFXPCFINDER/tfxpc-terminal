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
        public IActionResult RealizarPedido(Pedido pedido)
        {
            var sucesso = _pedidoService.RealizarPedido(pedido);
            if (!sucesso)
            {
                return BadRequest("Não foi possível realizar o pedido. Verifique os dados.");
            }

            return Ok("Pedido realizado com sucesso.");
        }

        [HttpGet("{usuarioId}")]
        public IActionResult ListarPorUsuario(int usuarioId)
        {
            var pedidos = _pedidoService.ListarPorUsuario(usuarioId);
            return Ok(pedidos);
        }
    }
}
