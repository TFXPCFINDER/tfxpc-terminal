# TFX_PC - Projeto POO Loja Virtual em C# + ASP.NET Core Web API + React JS

Este projeto tem como objetivo simular uma loja virtual de computadores, permitindo o cadastro de produtos, gerenciamento de usuários, carrinho de compras, finalização de pedidos e histórico de compras.

## 💻 Tecnologias Utilizadas

### Backend (API)

* C#
* .NET 7
* ASP.NET Core Web API
* Swagger (para testes de rota)

### Frontend (Site)

* ReactJS (Vite)
* Axios (para requisições HTTP)
* LocalStorage (para login e carrinho)

---

## 🎯 Funcionalidades

* Cadastro e login de usuários
* Cadastro de produtos (nome, descrição, preço, estoque)
* Listagem de produtos
* Carrinho de compras (adicionar, remover, totalizar)
* Finalização de pedido com escolha de pagamento (Pix ou Cartão)
* Atualização do estoque após a compra
* Histórico de pedidos do cliente
* Validação de estoque antes da compra
* Logout do usuário

---

## ✅ Como Executar o Projeto

### Requisitos:

* .NET 7 SDK instalado
* Node.js (v18+) instalado
* Git instalado (opcional)

---

## 📂 Backend - API (.NET)

1. Navegue até a pasta do backend:

```bash
cd LojaVirtual/TfxPcApi
```

2. Restaure os pacotes:

```bash
dotnet restore
```

3. Compile e execute:

```bash
dotnet run
```

4. Acesse o Swagger em:

```
http://localhost:5229/swagger
```

Esse servidor é responsável por:

* Gerenciar produtos, usuários e pedidos
* Validar estoques
* Receber os pedidos vindos do frontend

---

## 🚀 Frontend - React

1. Navegue até a pasta do frontend:

```bash
cd LojaVirtual/frontend
```

2. Instale as dependências:

```bash
npm install
```

3. Execute o servidor React:

```bash
npm run dev
```

4. Acesse o site:

```
http://localhost:5173
```

---

## Observações

* O backend usa uma lista em memória para simular banco de dados.
* Os produtos iniciais estão cadastrados diretamente no `ProdutoService`.
* A API permite testar todas as funções via Swagger.
* O frontend simula login com `localStorage`.

---

## 📅 Desenvolvido por

* PUC Minas - Sistemas de Informação
* Matheus Amaral Lara
* Ronaldo Soares de Oliveira Junior
* Diogo Lamera dos Santos
* Max Augusto Faria Andrade
* Guilherme Nazareth Carabetti
