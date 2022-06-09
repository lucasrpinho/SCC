# SCC - Sistema de Calculo de Comissão
## Web API in ASP.NET Core as a test.

### Lógica do POST
- SCC/Controllers/ComissaoController.cs

### Projeto criado no Visual Studio 2022 utlizando o formato Web Api do ASP.Net Core.
#### .Net 6.0

#### Kestrel

Testado localmente rodando diretamente na IDE, uma página é aberta no localhost<porta> e você pode testar a requisição POST passando o parâmetro desejado (o json precisa estar no formato certo e com os mesmos atributos da entidade especificada no parâmetro da requisição), caso o BODY seja vazio, usará dados criados localmente (MOQ não foi utilizado).

# Usado [FromBody]

## Exemplo de JSON válido para teste de POST:
- [
{ "vendedor": 1, "data": "2022-03-01", "valor": 500.34 },
{ "vendedor": 1, "data": "2022-03-01", "valor": 1000.22 },
{ "vendedor": 1, "data": "2022-03-01", "valor": 100.35 },
{ "vendedor": 1, "data": "2022-03-01", "valor": 22.34 },
{ "vendedor": 1, "data": "2022-04-01", "valor": 5000.34 },
{ "vendedor": 2, "data": "2022-03-01", "valor": 2000.34 },
{ "vendedor": 2, "data": "2022-04-01", "valor": 3000.34 }
] 

## Caso queira testar com os dados criados localmente, apenas remova os valores do JSON: 
- [
]



O código foi feito visando utilizar a menor quantidade de constantes possíveis (exceto a lista de metas), não foi testado com grandes quantidades de dados, mas uma lista com diversos objetos de pedidos (e.g. json do .README) retornam o resultado de forma automatizada sem a necessidade de alteração no código.

### Foi necessário mudar a configuração do serviço, a versão utilizada do .NET não aceitava alguns métodos síncronos dentro da requisição.
- Primeiramente seria feito lendo o body usando um StreamReader, alguns métodos (e.g. ReadToEnd) síncronos geravam exceções devido a uma variável estar setada para false (AllowSynchronousIO).
- 
### Modularizado 
- Projeto de entidades
- Projeto para Helpers 
- Newtonsoft.Json
