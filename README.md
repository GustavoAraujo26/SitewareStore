> # Siteware Store

## Introdução
Projeto para simular um e-commerce, com criação de produtos, promoções, além do carrinho de compras. 

A construção da aplicação foi realizada seguindo a cartilha do SOLID, além de se fazer valer sobre os padrões do DDD. Além disso, para algumas situações, foi utlizado o design pattern "Singleton".

Back-end da aplicação desenvolvido em C# (.NET 7), enquanto o front-end foi desenvolvido em Blazor Server-Side (.NET 7).

Sobre banco de dados, foi utilizado o "localDB", que já vem instalado junto ao Visual Studio.

## Regras de negócio
A aplicação está divida nos seguintes módulos:
* Cadastro de promoções
* Cadastro de produtos
* Lista de produtos "ativos" no sistema
* Carrinho de compras
* Listagem de todas as compras realizadas.

Além disso, o sistema possui algumas travas, devido chaves do banco de dados, sendo elas:
* Não é possível excluir promoções que estejam vinculadas à produtos. Para realizar esta ação, é necessário entrar em cada produto e desvincular a promoção.
* Na tabela do carrinho de compras, bem como também na tabela de itens do carrinho, não existe vinculação (chave estrangeira) com os produtos. Dessa forma, caso algum produto seja apagado, não afetará o histório de compras.
* Foi criado campo de "status" para as promoções. Dessa forma, só é possível vincular promoções que estejam ativas à novos produtos, ou nas alterações dos mesmos.
* Foi criado campo de "status" para os produtos. Dessa forma, somente serão listados para venda os produtos com "status" ativo.

## IDE'S
Segue a lista das ferramentas utilizadas na construção do projeto.
* Microsoft Visual Studio Community 2022, versão 17.8.6
* Microsoft SQL Server Management Studio 18

## Pacotes utilizados
* Dapper versão 2.1.28
* AutoMapper versão 13.0.1
* FluentValidation.AspNetCore versão 11.3.0
* Bogus versão 35.4.0
* Moq versão 4.20.70
* xunit versão 2.4.2

## Tests unitários
Foram realizados testes unitários em todas as classes da camada de serviço, com o intuito de mitigar possíveis erros no fluxo, bem como nas regras de negócio.

Para facilitar os testes a serem realizados, foi utilizado a biblioteca "Moq", para mockar as interfaces dos repositórios de banco de dados. Além disso, para simular com mais fidelidade, foi utilizado a biblioteca "Bogus" para gerar dados "fake".

## Execução da aplicação
Antes de executar a aplicação, é necessário criar o banco de dados que a aplicação utiliza. O banco utilizado foi o SQL Server localDB, já que o mesmo já vem instalado de fábrica junto ao Visual Studio.

Para criar o banco de dados, bem como uma pequena massa de exemplo de promoções, foram disponibilizados os scripts de criação do banco/tabela. 

Os scripts estão localizados no sub-projeto "SitewareStore.Infra.Data", na pasta "Scripts". O nome dos arquivos possui uma numeração, para indicar a ordem de execução dos mesmos.

Para executar de forma fácil os scripts, utilize o SQL Server Management Studio. Na janela de conexão com o servidor, no campo "Nome do servidor" insira "(localdb)\MSSQLLocalDB". Na caixa de seleção, escolha a opção "Autenticação do Windows". Em seguida, basta conectar e começar a executar os scripts.

Após criação do banco de dados, basta executar o sub-projeto "SitewareStore" (Blazor Server-Side);