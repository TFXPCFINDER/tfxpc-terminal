import { useEffect, useState } from 'react';
import axios from 'axios';

function Pedidos() {
  const [pedidos, setPedidos] = useState([]);
  const [produtos, setProdutos] = useState([]);
  const usuario = JSON.parse(localStorage.getItem('usuario'));

  useEffect(() => {
    if (!usuario) return;

    const fetchPedidos = async () => {
      try {
        const resPedidos = await axios.get(`http://localhost:5229/pedidos/${usuario.id}`);
        const resProdutos = await axios.get('http://localhost:5229/produtos');
        setPedidos(resPedidos.data);
        setProdutos(resProdutos.data);
      } catch (err) {
        console.error('Erro ao buscar pedidos ou produtos:', err);
      }
    };

    fetchPedidos();
  }, []);

  const buscarProduto = (id) => produtos.find(p => p.id === id);

  return (
    <div>
      <h2>Histórico de Pedidos</h2>
      {pedidos.length === 0 ? (
        <p>Você ainda não fez nenhum pedido.</p>
      ) : (
        <ul>
          {pedidos.map(pedido => (
            <li key={pedido.id} style={{ marginBottom: '20px' }}>
              <strong>Pedido #{pedido.id}</strong><br />
              <ul>
                {pedido.itens.map((item, i) => {
                  const produto = buscarProduto(item.produtoId);
                  return (
                    <li key={i}>
                      {produto ? (
                        <>
                          {produto.nome} - {item.quantidade} x R$ {produto.preco.toFixed(2)} = R$ {(produto.preco * item.quantidade).toFixed(2)}
                        </>
                      ) : (
                        <>Produto ID {item.produtoId} não encontrado</>
                      )}
                    </li>
                  );
                })}
              </ul>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default Pedidos;
