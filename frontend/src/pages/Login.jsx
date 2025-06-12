import { useState } from 'react';
import axios from 'axios';

function Login() {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('http://localhost:5229/usuarios/login', {
        email,
        senha,
      });
      alert('Login realizado! Usuário ID: ' + response.data.id);
      localStorage.setItem('usuarioId', response.data.id);
    } catch (err) {
      console.error(err);
      alert('Falha no login');
    }
  };

  return (
    <div>
      <h2>Login</h2>
      <form onSubmit={handleLogin}>
        <input type="email" placeholder="Email" value={email} onChange={e => setEmail(e.target.value)} required /><br />
        <input type="password" placeholder="Senha" value={senha} onChange={e => setSenha(e.target.value)} required /><br />
        <button type="submit">Entrar</button>
      </form>
    </div>
  );
}

export default Login;
