# Book API

Esta é uma API de gerenciamento de livros, onde você pode adicionar, editar, excluir e obter informações sobre os livros.

## Instalação

1. Certifique-se de ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. Clone este repositório para o seu ambiente local.
3. Abra o terminal e navegue até o diretório raiz do projeto.
4. Execute o comando `dotnet build` para compilar o projeto.
5. Execute o comando `dotnet run` para iniciar a aplicação.

A API estará disponível em `http://localhost:5000`.

## Endpoints

### Listar todos os livros

**GET** `/api/book`

Retorna todos os livros cadastrados.

Exemplo de resposta:

[
{
"id": 1,
"titulo": "O Senhor dos Anéis",
"descricao": "Esta é uma descrição do livro",
"autores": [
"J.R.R. Tolkien"
]
},
{
"id": 2,
"titulo": "Dom Quixote",
"descricao": "Esta é outra descrição do livro",
"autores": [
"Miguel de Cervantes"
]
}
]


### Obter informações de um livro

**GET** `/api/book/{id}`

Retorna as informações de um livro específico com base no ID fornecido.

Exemplo de resposta:

{
"id": 1,
"titulo": "O Senhor dos Anéis",
"descricao": "Esta é uma descrição do livro",
"autores": [
"J.R.R. Tolkien"
]
}


### Adicionar um novo livro

**POST** `/api/book`

Adiciona um novo livro. É necessário fornecer os seguintes dados no corpo da solicitação:

{
"titulo": "Novo Livro",
"descricao": "Descrição do novo livro",
"autores": [
"Autor 1",
"Autor 2"
]
}

### Atualizar um livro existente

**PUT** `/api/book/{id}`

Atualiza as informações de um livro existente com base no ID fornecido. É necessário fornecer os seguintes dados no corpo da solicitação:

{
"titulo": "Novo Título",
"descricao": "Nova descrição do livro",
"autores": [
"Novo Autor"
]
}

### Excluir um livro

**DELETE** `/api/book/{id}`

Exclui um livro específico com base no ID fornecido.

## Contribuição

Se você deseja contribuir para este projeto, fique à vontade para fazer um fork e enviar suas melhorias através de pull requests.


