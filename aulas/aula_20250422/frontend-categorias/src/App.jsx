import { useEffect, useState } from 'react';

function App() {
  const [token, setToken] = useState(null);
  const [categorias, setCategorias] = useState([]);
  const [erro, setErro] = useState(null);

  // ✅ Recebe o token via postMessage
  useEffect(() => {
    function receberToken(event) {
      if (event.origin !== "http://localhost:5002") return; // segurança: só aceita do login

      const { token } = event.data;
      if (token) {
        localStorage.setItem("token", token); // opcional
        setToken(token);
      }
    }

    window.addEventListener("message", receberToken);
    return () => window.removeEventListener("message", receberToken);
  }, []);

  // 🔄 Busca as categorias após receber o token
  useEffect(() => {
    if (!token) return;

    fetch("http://localhost:5001/api/categories", {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
      .then((res) => {
        if (!res.ok) throw new Error("Erro ao buscar categorias (401 ou outro)");
        return res.json();
      })
      .then(setCategorias)
      .catch(setErro);
  }, [token]);

  return (
    <div style={{ fontFamily: "Arial", padding: "20px" }}>
      <h2>📦 Categorias Registradas</h2>

      {!token && <p>Aguardando autenticação...</p>}
      {erro && <p style={{ color: "red" }}>{erro.message}</p>}

      <ul>
        {categorias.map((cat) => (
          <li key={cat.id}>{cat.name}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;
