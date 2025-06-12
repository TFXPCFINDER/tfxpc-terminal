import { useState } from 'react';
import axios from 'axios';

function Cadastro() {
  const [nome, setNome] = useState('');
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [endereco, setEndereco] = useState('');

  const handleCadastro = async (e) => {
    e.preventDefault();
    try {
      await axios.post('http://localhost:5229/usuarios/cadastrar', {
        nome,
        email,
        senha,
        endereco,
      });
      alert('Usuário cadastrado com sucesso!');
    } catch (err) {
      console.error(err);
      alert('Erro ao cadastrar usuário');
    }
  };

  return (
    <div>
      <h2>Cadastro</h2>
      <form onSubmit={handleCadastro}>
        <input type="text" placeholder="Nome" value={nome} onChange={e => setNome(e.target.value)} required /><br />
        <input type="email" placeholder="Email" value={email} onChange={e => setEmail(e.target.value)} required /><br />
        <input type="password" placeholder="Senha" value={senha} onChange={e => setSenha(e.target.value)} required /><br />
        <input type="text" placeholder="Endereço" value={endereco} onChange={e => setEndereco(e.target.value)} required /><br />
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
}

export default Cadastro;