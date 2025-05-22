using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Models
{
    public class Pedido
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public Usuario Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
        public DateTime Data { get; set; } = DateTime.Now;
        public decimal Total => Itens.Sum(item => item.Subtotal);
        public string Status { get; set; } = "Concluído";

        public Pedido(Usuario cliente)
        {
            Cliente = cliente;
        }

        public void AdicionarItem(ItemPedido item)
        {
            Itens.Add(item);
        }

        public override string ToString()
        {
            return $"Pedido #{Id} - {Data.ToShortDateString()} - Total: R${Total} - Itens: {Itens.Count}";
        }
    }
}