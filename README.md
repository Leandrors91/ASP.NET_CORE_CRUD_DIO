### Yu-Gi-Oh! Pokedex

Bem vindo ao Yu-Gi-Oh Pokedex, com este sistema você será capas de catalogar os mostro do Yu-Gi-Oh para ajudar você em seus duelos, e quando você precisar de informações sobre os monstros do jogo poderá consultar tudo através dele.

### Considerações

Este projeto é uma nova implementação que eu criei do sistema original que foi desenvolvido durante aula ministrada por Thiago Campos de Oliveira em parceria da Digital Innovation One.<br>
Neste projeto eu tive a idéia de tranformar o sistema inicial em um CRUD de mostros do Yu-Gi-Oh e fiz todas as modificações necessárias.

### Tecnologias Utilizadas

* ASP.NET CORE
* C#

### Como Funciona?

* O sistema se trata de um serviço web que recebe as requisições dos usuários via mensagens HTTP e devolve o código de status delas. Através dessas mensagens o sistema realiza as operações correspondentes.

* O programa permite cadastrar, consultar, atualizar, deletar monstros de um armazenamento em memória. Caso o sistema pare de rodar todos os dados nele inseridos serão perdidos com exceção de alguns monstros que ele tem cadastrados por padrão.

* Para cadastrar um monstro ele deve possuir nome, atributo, tipo do monstro, tipo da carta, descrição, nível, ataque e defesa.

* O Sistema valida os dados cadastrados verificando se todos os dados forão cadastrados corretamente, se não ele exibe uma mensagem informando qual foi o erro.

