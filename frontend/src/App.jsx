import { Routes, Route, Link } from 'react-router-dom';
import Home from './pages/Home';
import ProdutoList from './pages/ProdutoList';
import Login from './pages/Login';
import Cadastro from './pages/Cadastro';

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <nav>
        <Link to="/">Início</Link> | <Link to="/produtos">Produtos</Link> | <Link to="/login">Login</Link> | <Link to="/cadastro">Cadastro</Link>
      </nav>
      <hr />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/produtos" element={<ProdutoList />} />
        <Route path="/login" element={<Login />} />
        <Route path="/cadastro" element={<Cadastro />} />
      </Routes>
    </div>
  );
}

export default App;