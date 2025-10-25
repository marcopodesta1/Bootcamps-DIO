# 🛒 Shopee Cart – Aula 06

Repositório da aula 06 do curso **Node + DIO**, onde criamos um carrinho de compras simples inspirado na lógica da Shopee.

## 📌 Visão Geral

Este projeto implementa um carrinho de compras em Node.js:

- Adição de itens com nome, preço e quantidade.
- Cálculo automático do subtotal e total.
- Visualização e remoção de itens do carrinho.

## 🗂️ Estrutura do Projeto

```
06-shopee-cart/
│
├─ src/
│   ├─ cart.js    # Lógica principal do carrinho (add/remove/list)
│   └─ item.js    # Definição e estrutura de Item
│
├─ package.json   # Metadados e dependências do projeto
└─ README.md      # Este arquivo
```

## 🚀 Como rodar o projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/marcopodesta1/node-dio/tree/main/Aulas/06-shopee-cart
   ```

2. Instale as dependências:
   ```bash
   npm install
   ```

3. Execute o programa:
   ```bash
   node src/cart.js
   ```

   > Se houver um script customizado no `package.json` (por ex. `npm start`), use este comando também.

## ⚙️ Uso e funcionalidades

No `cart.js`, as operações disponíveis incluem:

- `addItem(item)`: adiciona um novo item ou atualiza o que já existe.
- `removeItem(itemName)`: remove um item pelo nome.
- `getTotal()`: retorna o valor total dos itens no carrinho.
- `listItems()`: lista todos os itens e seus subtotais.

### Exemplo básico de uso:

```js
const Cart = require('./cart');
const Item = require('./item');

const cart = new Cart();
cart.addItem(new Item('Camisa', 50.00, 2));
cart.addItem(new Item('Caneca', 25.00, 1));
console.log(cart.listItems());
// [
//   { name: 'Camisa', price: 50, quantity: 2, subtotal: 100 },
//   { name: 'Caneca', price: 25, quantity: 1, subtotal: 25 }
// ]
console.log('Total: R$' + cart.getTotal()); // Total: R$125
```

## 🛠️ Tecnologias

- **Node.js** – Ambiente de execução JavaScript.
- JavaScript (ES6+) com módulos (`require`/`exports`).

