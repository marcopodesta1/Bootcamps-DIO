# ⚽ Projeto Champions

Este projeto é uma API Node.js para gerenciamento de jogadores e clubes de futebol, utilizando arquitetura em camadas (N-Layers). Ele permite listar, criar, atualizar e remover jogadores, além de listar clubes.

## Funcionalidades

- Listar todos os jogadores (`GET /api/players`)
- Buscar jogador por ID (`GET /api/players/:id`)
- Adicionar novo jogador (`POST /api/players`)
- Atualizar estatísticas de um jogador (`PATCH /api/players/:id`)
- Remover jogador (`DELETE /api/players/:id`)
- Listar todos os clubes (`GET /api/clubs`)

## Estrutura do Projeto
```
projeto-champions/
│
├── src/
│   ├── app.ts
│   ├── server.ts
│   ├── routes.ts
│   ├── controllers
│   ├── services/
│   ├── repositories/
│   ├── models/
│   ├── data/
│   └── utils/
├── .env
├── package.json
├── tsconfig.json
└── readme.md
```


## Como rodar o projeto

1. Instale as dependências:
   ```sh
   npm install
   ```

2. Configure a porta no arquivo `.env` (padrão: 3333):
   ```
   PORT=3333
   ```

3. Inicie o servidor em modo desenvolvimento:
   ```sh
   npm run start:dev
   ```

4. Acesse a API em: [http://localhost:3333/api](http://localhost:3333/api)

## Exemplos de Endpoints

- Listar jogadores:  
  `GET /api/players`

- Buscar jogador por ID:  
  `GET /api/players/1`

- Adicionar jogador:  
  `POST /api/players`  
  Corpo (JSON):
  ```json
  {
    "id": 20,
    "name": "Novo Jogador",
    "club": "Real Madrid",
    "nationality": "Espanha",
    "position": "Meio-campo",
    "statistics": {
      "Overall": 85,
      "Pace": 80,
      "Shooting": 75,
      "Passing": 88,
      "Dribbling": 82,
      "Defending": 70,
      "Physical": 78
    }
  }
  ```

- Atualizar estatísticas:  
  `PATCH /api/players/1`  
  Corpo (JSON):
  ```json
  {
    "Overall": 90,
    "Pace": 85,
    "Shooting": 80,
    "Passing": 90,
    "Dribbling": 88,
    "Defending": 75,
    "Physical": 80
  }
  ```

- Remover jogador:  
  `DELETE /api/players/1`

- Listar clubes:  
  `GET /api/clubs`

## Tecnologias Utilizadas

- Node.js
- Express
- TypeScript
- Arquitetura N-Layers

## Observações

- Os dados são armazenados em arquivos JSON na pasta `src/data`.
- O projeto utiliza apenas dependências open source.
