```markdown
# 📌 tds_2025_01

Repositório utilizado para a disciplina **Tecnologia em Desenvolvimento de Sistemas**,
abordando conceitos e práticas sobre **arquitetura monolítica e micro-serviços**,
utilizando **.NET e Docker**.

---

## 📂 Estrutura do Repositório

- **aplicacoes/MonolitoBackend/** → Implementação inicial de um backend monolítico.  
- **aulas/preparação/OrderManagementAPI/** → Código e materiais para a API de gerenciamento
de pedidos.  
- **slides/** → Apresentações utilizadas nas aulas.  
- **checklist-para-avaliar-seminários.xlsx** → Documento para avaliação de seminários.  

---

## 🚀 Tecnologias Utilizadas

- **C# (.NET 7+)**
- **ASP.NET Core**
- **Docker**
- **Entity Framework Core**
- **SQL Server**
- **Swagger (OpenAPI)**

---

## 📌 Objetivos do Projeto

1️⃣ **Explorar Arquiteturas de Software** → Iniciar com sistemas monolíticos e evoluir para
micro-serviços.  
2️⃣ **Implementação Prática** → Criar APIs utilizando boas práticas de desenvolvimento.  
3️⃣ **Gerenciamento e Deploy** → Utilização de Docker para empacotamento e execução.  

---

## 🔧 Como Configurar o Projeto

### 1️⃣ **Clone este repositório**
```bash
git clone https://github.com/evertonfoz/tds_2025_01.git
cd tds_2025_01
```

### 2️⃣ **Execute a aplicação monolítica**
```bash
cd aplicacoes/MonolitoBackend
dotnet run
```

### 3️⃣ **Executando via Docker**
```bash
docker build -t monolito-backend .
docker run -p 8080:80 monolito-backend
```

### 4️⃣ **Acessando a API**
Após iniciar o projeto, a API estará disponível em:
```
http://localhost:8080/swagger
```

---

## 📢 Contribuições

👥 Este repositório está aberto para contribuições. Para sugerir melhorias:
1. **Fork** este repositório.  
2. **Crie uma branch** para a sua alteração (`git checkout -b feature-nova`).  
3. **Commit** as mudanças (`git commit -m "Descrição da mudança"`).  
4. **Envie um Pull Request**.  

---

## 📄 Licença

Este projeto segue a licença **MIT**, permitindo uso, modificação e distribuição livremente.

---

🚀 **Bons estudos e bom desenvolvimento!**
```
