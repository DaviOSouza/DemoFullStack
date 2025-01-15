# DemoFullStack

Este projeto é um site completo com camadas de front-end e back-end, desenvolvido em C#. Ele utiliza tecnologias modernas para fornecer uma solução robusta e escalável.

# Front-End
Tecnologias Utilizadas
ASP.NET MVC: Utilizado para criar a interface do usuário com Razor Pages, oferecendo uma experiência web interativa e responsiva.

Bootstrap: Framework CSS que facilita o desenvolvimento de uma interface de usuário responsiva e moderna.

# Funcionalidades
Interface do Usuário Intuitiva: Páginas web bem estruturadas e fáceis de navegar.

Formulários de Entrada: Formulários para entrada de dados com validação do lado do cliente.

Design Responsivo: Layout que se ajusta a diferentes tamanhos de tela para uma experiência consistente em dispositivos móveis e desktop.

# Back-End
Tecnologias Utilizadas
ASP.NET Core: Framework para construção de aplicações web e APIs robustas e de alta performance.

Entity Framework Core: ORM (Object-Relational Mapper) utilizado para interagir com o banco de dados de forma eficiente e segura.

AutoMapper: Biblioteca para mapeamento de objetos, facilitando a transferência de dados entre camadas.

Dependency Injection: Utilizado para promover um design de código modular e testável.

Funcionalidades
API RESTful: Endpoints para manipulação de dados, seguindo os padrões REST.

Autenticação e Autorização: Implementação de segurança para proteger recursos e dados do usuário.

Serviços de Negócio: Lógica de negócios encapsulada em serviços que podem ser facilmente testados e mantidos.

Banco de Dados
Tecnologia Utilizada
SQL Server: Banco de dados relacional utilizado para armazenamento e gerenciamento de dados.

Migrations do Entity Framework: Ferramenta para controle de versão do esquema do banco de dados, facilitando a evolução e manutenção do modelo de dados.

Estrutura de Dados
Tabela de Usuários: Armazena informações dos usuários cadastrados.

Tabela de Produtos: Armazena informações sobre os produtos disponíveis.

Tabela de Pedidos: Registra as transações realizadas pelos usuários.

Implementação
Passos para Executar o Projeto
Clone o repositório:

bash
git clone https://github.com/seu-usuario/seu-repositorio.git
Instale as dependências:

bash
cd seu-repositorio
dotnet restore
Configure a conexão com o banco de dados no arquivo appsettings.json.

Aplique as migrations:

bash
dotnet ef database update
Execute o projeto:

bash
dotnet 
