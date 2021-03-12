# Case Desenvolvimento .NET Grupo Technos 
Uma API proposta como parte do processo seletivo
## Como usar

A API de Produtos é protegida por Token JWT. Então, antes de usá-la, é preciso cadastrar um usuário.
Um token é retornado após o usuário ser autenticado. 

A tabela abaixo contém as funcionalidades e rotas da API de Usuários:


|Funcionalidade                     |Rota                                           |Método HTTP |
|-----------------------------------|-----------------------------------------------|------------|
|Cadastra um novo usuário           |https://localhost:5001/api/usuarios            |POST        |
|Autentica o usuário                |https://localhost:5001/api/usuarios/login      |POST        |

As requisições feitas para API de Produtos precisam conter o cabeçalho **Authorization** 
e seu valor com o token do usuário.

A tabela abaixo contém as funcionalidades e rotas da API de Produtos:

|Funcionalidade                     |Rota                                           |Método HTTP |
|-----------------------------------|-----------------------------------------------|------------|
|Cadastra um novo produto           |https://localhost:5001/api/produtos            |POST        |
|Lista todos os produtos            |https://localhost:5001/api/produtos            |GET         |
|Busca um produto pelo id           |https://localhost:5001/api/produtos/{id}       |GET         |
|Atualiza um produto pelo id        |https://localhost:5001/api/produtos/{id}       |PUT         |
|Deleta um produto pelo seu id      |https://localhost:5001/api/produtos/{id}       |DELETE      |
