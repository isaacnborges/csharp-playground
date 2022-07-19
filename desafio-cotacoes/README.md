# Desafio cotações

Projeto apresenta uma solução para o problema apresentado pelo Francisco Zanfranceschi no repositório 
[desafio-01-cotacoes](https://github.com/zanfranceschi/desafio-01-cotacoes). 
O objetivo é construir uma API que consulta três serviços externos em busca de uma cotação. Após obtidas as respostas, a API retorna a melhor das três.

### Dependências
- [Docker](https://docs.docker.com/get-docker/)

### Como executar

Para executar os serviços, basta executar na raiz do projeto o seguinte comando
```
docker-compose up
```

### Aplicação

A aplicação irá executar na porta 4000 e já consta com um swagger para facilitar a chamada da rota.
- Swagger: http://localhost:4000/swagger

A rota em questão é `http://localhost:4000/api/cotacoes/?coin=usd` onde `coin` é o parâmetro da moeada a ser convertida e pode ser utiliza com [Postman](https://www.postman.com/downloads/), [Insonia](https://insomnia.rest/download) ou até mesmo o próprio [Curl](https://curl.se/docs/manual.html)