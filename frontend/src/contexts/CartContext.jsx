import { createContext, useContext, useState } from 'react';

const CartContext = createContext();

export function CartProvider({ children }) {
  const [cart, setCart] = useState([]);

  const adicionar = (produto) => {
    setCart(prev => {
      const existente = prev.find(p => p.id === produto.id);
      if (existente) {
        return prev.map(p => p.id === produto.id ? { ...p, quantidade: p.quantidade + 1 } : p);
      } else {
        return [...prev, { ...produto, quantidade: 1 }];
      }
    });
  };

  const remover = (id) => {
    setCart(prev => prev.filter(p => p.id !== id));
  };

  const limpar = () => setCart([]);

  const total = cart.reduce((soma, p) => soma + p.preco * p.quantidade, 0);

  return (
    <CartContext.Provider value={{ cart, adicionar, remover, limpar, total }}>
      {children}
    </CartContext.Provider>
  );
}

export function useCart() {
  return useContext(CartContext);
}