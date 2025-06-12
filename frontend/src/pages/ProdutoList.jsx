import { useEffect, useState } from 'react';
import axios from 'axios';
import { useCart } from '../contexts/CartContext';

function ProdutoList() {
  const [produtos, setProdutos] = useState([]);
  const { adicionar } = useCart();

  useEffect(() => {
    axios.get('http://localhost:5229/produtos')
      .then(response => setProdutos(response.data))
      .catch(err => console.error('Erro ao buscar produtos:', err));
  }, []);

  return (
    <div>
      <h2>Lista de Produtos</h2>
      {produtos.length === 0 ? (
        <p>Nenhum produto encontrado.</p>
      ) : (
        <ul>
          {produtos.map(produto => (
            <li key={produto.id} style={{ marginBottom: '20px' }}>
              <strong>{produto.nome}</strong><br />
              <em>{produto.descricao}</em><br />
              Preço: R$ {produto.preco.toFixed(2)}<br />
              <button onClick={() => adicionar(produto)}>Adicionar ao Carrinho</button>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default ProdutoList;
