import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

function Logout() {
  const navigate = useNavigate();

  useEffect(() => {
    localStorage.removeItem('usuario');
    alert('Logout realizado com sucesso!');
    navigate('/');
  }, []);

  return null;
}

export default Logout;