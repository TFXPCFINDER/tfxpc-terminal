function Home() {
  return (
    <div style={{ textAlign: 'center' }}>
      <h2>Bem-vindo à Loja Virtual TFX_PC!</h2>
      <p style={{ marginTop: '10px', fontSize: '1.1rem' }}>
        Aqui você encontra os melhores computadores e acessórios para gamers, profissionais e entusiastas da tecnologia.
      </p>
      <img
        src="/logo-b.png"
        alt="Logo TFXPC"
        style={{ marginTop: '20px', width: '200px', borderRadius: '8px' }}
      />
      <div style={{ marginTop: '30px' }}>
        <a href="/produtos">
          <button style={{ fontSize: '1rem', padding: '10px 20px' }}>Ver Produtos</button>
        </a>
      </div>
    </div>
  );
}

export default Home;
