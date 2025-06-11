using TfxPcApi.Models;

namespace TfxPcApi.Services;

public class ProdutoService
{
    private readonly List<Produto> _produtos = new();
    private int _proximoId = 1;

    public List<Produto> ListarTodos()
    {
        return _produtos;
    }

    public Produto? BuscarPorId(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public Produto Adicionar(Produto produto)
    {
        produto.Id = _proximoId++;
        _produtos.Add(produto);
        return produto;
    }

    public bool Remover(int id)
    {
        var produto = BuscarPorId(id);
        if (produto == null) return false;
        _produtos.Remove(produto);
        return true;
    }

    public bool AtualizarEstoque(int id, int quantidade)
    {
        var produto = BuscarPorId(id);
        if (produto == null || produto.Estoque < quantidade) return false;

        produto.Estoque -= quantidade;
        return true;
    }
}
