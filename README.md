## VERS�O FINAL 
## Desafio Banco Bari - Laudinei Martins

Desenvolva um micro-servi�o, que envie uma mensagem de Hello World a cada 5 segundos. Essa mensagem deve conter, al�m da mensagem de Hello World, um Identificador do micro-servi�o, o timestamp que foi enviado, e um Id de requisi��o aleat�rio. Al�m disso, esse servi�o deve ser capaz de ler mensagens enviadas por outros micro-servi�os, mostrando na tela esses dados. � obrigat�rio o uso de algum sistema de mensagens (AMQP, Kafka, JMS, etc.).
Queremos rodar pelo menos duas inst�ncias do servi�o desenvolvido e ver a comunica��o entre eles.

Atendendo aos requisitos do desafio proposto, foi desenvolvido um micro microservi�o denominado bariapi.
A API foi desenvolvida dentro do padr�o REST, � executada em um container Docker, e tamb�m foi utilizado um container para o RabbitMQ para o server de mensageria.

# Tecnologias, Frameworks e Libraries:

- bariapi foi escrita em C# . NET Core 3.1 e utiliza o RabbitMQ.Client, Swagger, Serilog para registro de logs, xUnit para testes unit�rios.

# Recursos, par�metros e requisitos:
Cada imagem e suas respectivas portas ser�o configuradas:

RabbitMQ 15672 para interface de gerenciamento.
         5672 para o server.

bariapi 5000
  

Para executar a API, o docker dever� estar instalado em execu��o e dever� entrar no diret�rio raiz da solu��o ./bari.api.mensageria e executar o comando:
    docker-compose up -d

Esse comando baixar� as imagens e criar� os containers e subir� as aplica��es.

- Para o envio da mensagem helloworld a cada 5 segundos, entrar no diret�rio da solu��o, e na pasta .\bari.api.mensageria\Bari.Producer:
  Executar um prompt de comando, e dentro dele o comando dotnet run
  Ser� criada uma fila com o nome helloWorldBari

- Para o consumo das mensagens helloworld da fila criada anteriormente, entrar no diret�rio da solu��o, e na pasta .\bari.api.mensageria\Bari.Consumer:
  Executar um prompt de comando, e dentro dele o comando dotnet run

- Para documenta��o e testes/utiliza��o da API, acesse o navegador:

bariapi: http://localhost:5000/swagger/index.html.

No m�todo /api/Mensageria/send ser� poss�vel adicionar uma mensagem na fila helloWorldBari.

No m�todo /api/Mensageria/receive ser� poss�vel consumir as mensagens da fila retornando uma lista das mensagens.

rabbitmq: http://localhost:15672/#/

Exibe a interface para gerenciamento do RabbitMQ


# Referencias:

https://xunit.net
https://www.youtube.com/watch?v=FcF5iufd2P0
https://www.rabbitmq.com
https://github.com/serilog/serilog

