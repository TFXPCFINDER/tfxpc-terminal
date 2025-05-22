
namespace LojaVirtual.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public Produto(int id, string nome, string descricao, decimal preco, int estoque)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
        }

        public void AtualizarEstoque(int quantidade)
        {
            Estoque -= quantidade;
        }

        public override string ToString()
        {
            return $"[{Id}] {Nome} - {Descricao} - R${Preco} (Estoque: {Estoque})";
        }
    }
}