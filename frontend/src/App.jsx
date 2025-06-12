import { Routes, Route, Link } from 'react-router-dom';
import Home from './pages/Home';
import ProdutoList from './pages/ProdutoList';
import Login from './pages/Login';
import Cadastro from './pages/Cadastro';
import Carrinho from './pages/Carrinho';
import Pedidos from './pages/Pedidos';
import Logout from './pages/Logout';

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <nav>
        <Link to="/">Início</Link> | <Link to="/produtos">Produtos</Link> | <Link to="/carrinho">Carrinho</Link> | <Link to="/pedidos">Pedidos</Link> | <Link to="/login">Login</Link> | <Link to="/cadastro">Cadastro</Link> | <Link to="/logout">Logout</Link>
      </nav>
      <hr />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/produtos" element={<ProdutoList />} />
        <Route path="/login" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />
        <Route path="/logout" element={<Logout />} />
        <Route path="/carrinho" element={<Carrinho />} />
        <Route path="/pedidos" element={<Pedidos />} />
      </Routes>
    </div>
  );
}

export default App;
