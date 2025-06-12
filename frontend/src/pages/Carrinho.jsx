import { useCart } from '../contexts/CartContext';
import axios from 'axios';

function Carrinho() {
  const { cart, remover, total, limpar } = useCart();

  const finalizarPedido = async () => {
    const usuario = JSON.parse(localStorage.getItem('usuario'));
    if (!usuario) {
      alert('Você precisa estar logado para finalizar o pedido.');
      return;
    }

    const pedido = {
      usuarioId: usuario.id,
      itens: cart.map(item => ({
        produtoId: item.id,
        quantidade: item.quantidade
      }))
    };

    try {
      await axios.post('http://localhost:5229/pedidos', pedido);
      alert('Pedido finalizado com sucesso!');
      limpar();
    } catch (error) {
      console.error(error);
      alert('Erro ao finalizar pedido.');
    }
  };

  return (
    <div>
      <h2>Carrinho de Compras</h2>
      {cart.length === 0 ? (
        <p>Seu carrinho está vazio.</p>
      ) : (
        <>
          <ul>
            {cart.map(item => (
              <li key={item.id}>
                {item.nome} - {item.quantidade} x R$ {item.preco.toFixed(2)} = R$ {(item.preco * item.quantidade).toFixed(2)}
                <button onClick={() => remover(item.id)} style={{ marginLeft: '10px' }}>Remover</button>
              </li>
            ))}
          </ul>
          <h3>Total: R$ {total.toFixed(2)}</h3>
          <button onClick={limpar}>Limpar Carrinho</button>
          <button onClick={finalizarPedido} style={{ marginLeft: '10px' }}>Finalizar Pedido</button>
        </>
      )}
    </div>
  );
}

export default Carrinho;