using System;
using System.Collections.Generic;
using System.Linq;
using TfxPcApi.Models;

namespace TfxPcApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<ItemPedido> Itens { get; set; } = new();
        public decimal Total => Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public string FormaPagamento { get; set; } = "";
    }
}
