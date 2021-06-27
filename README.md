**Yu-Gi-Oh! Pokedex**

Bem vindo ao Yu-Gi-Oh Pokedex, com este sistema você será capás de catalogar os mostro do Yu-Gi-Oh para ajudar você em seus duelos, e quando 
você precisar de informações sobre os montros do jogo poderá consultar tudo através dele.

**Tecnologias Utilizadas**

* ASP.NET CORE
* C#

**Como Funciona?**

* O sistema se trata de um serviço web que recebe as requisições dos usauários via mensagens HTTP e devolve o código de status delas. Através 
dessas mensagens o sistema realiza as operações correspondentes.

* O programa permite cadastrar, consultar, atualizar, deletar monstros de um armazenamento em memória. Caso o sitema pare de rodar todos os dados 
nele inseridos serão perdidos com exceção de alguns monstros que ele tem cadastrados por padrão.

* Para cadastrar um monstro ele deve possuir nome, atributo, tipo do monstro, tipo da carta, descrição, nivel, ataque e defesa.

* O Sistema valida os dados cadastrados verificando se todos os dados forão cadastrados corretamente, se não ele exibe uma mensagem informando qual foi o erro.
