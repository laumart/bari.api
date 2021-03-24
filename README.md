## VERSÃO FINAL 
## Desafio Banco Bari - Laudinei Martins

Desenvolva um micro-serviço, que envie uma mensagem de Hello World a cada 5 segundos. Essa mensagem deve conter, além da mensagem de Hello World, um Identificador do micro-serviço, o timestamp que foi enviado, e um Id de requisição aleatório. Além disso, esse serviço deve ser capaz de ler mensagens enviadas por outros micro-serviços, mostrando na tela esses dados. É obrigatório o uso de algum sistema de mensagens (AMQP, Kafka, JMS, etc.).
Queremos rodar pelo menos duas instâncias do serviço desenvolvido e ver a comunicação entre eles.

Atendendo aos requisitos do desafio proposto, foi desenvolvido um micro microserviço denominado bariapi.
A API foi desenvolvida dentro do padrão REST, é executada em um container Docker, e também foi utilizado um container para o RabbitMQ para o server de mensageria.

# Tecnologias, Frameworks e Libraries:

- bariapi foi escrita em C# . NET Core 3.1 e utiliza o RabbitMQ.Client, Swagger, Serilog para registro de logs, xUnit para testes unitários.

# Recursos, parâmetros e requisitos:
Cada imagem e suas respectivas portas serão configuradas:

RabbitMQ 15672 para interface de gerenciamento.
         5672 para o server.

bariapi 5000
  

Para executar a API, o docker deverá estar instalado em execução e deverá entrar no diretório raiz da solução ./bari.api.mensageria e executar o comando:
    docker-compose up -d

Esse comando baixará as imagens e criará os containers e subirá as aplicações.

- Para o envio da mensagem helloworld a cada 5 segundos, entrar no diretório da solução, e na pasta .\bari.api.mensageria\Bari.Producer:
  Executar um prompt de comando, e dentro dele o comando dotnet run
  Será criada uma fila com o nome helloWorldBari

- Para o consumo das mensagens helloworld da fila criada anteriormente, entrar no diretório da solução, e na pasta .\bari.api.mensageria\Bari.Consumer:
  Executar um prompt de comando, e dentro dele o comando dotnet run

- Para documentação e testes/utilização da API, acesse o navegador:

bariapi: http://localhost:5000/swagger/index.html.

No método /api/Mensageria/send será possível adicionar uma mensagem na fila helloWorldBari.

No método /api/Mensageria/receive será possível consumir as mensagens da fila retornando uma lista das mensagens.

rabbitmq: http://localhost:15672/#/

Exibe a interface para gerenciamento do RabbitMQ


# Referencias:

https://xunit.net
https://www.youtube.com/watch?v=FcF5iufd2P0
https://www.rabbitmq.com
https://github.com/serilog/serilog

