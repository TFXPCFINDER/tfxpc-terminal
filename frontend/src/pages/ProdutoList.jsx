import { useEffect, useState } from 'react';
import axios from 'axios';

function ProdutoList() {
  const [produtos, setProdutos] = useState([]);

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
            <li key={produto.id}>
              <strong>{produto.nome}</strong> - R$ {produto.preco.toFixed(2)}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default ProdutoList;