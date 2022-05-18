# FIT-RS2-2022
Vježbe iz predmeta RS 2


https://www.earthdatascience.org/workshops/intro-version-control-git/basic-git-commands/

https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/

https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures

Visual Studio 2022
SQL Server 2017+

.NET 6



-- Install Docker Desktop

* DOCKER SQL IMAGE https://hub.docker.com/_/microsoft-mssql-server

    docker pull mcr.microsoft.com/mssql/server:2017-latest
    docker run -e 'ACCEPT_EULA=Y' -e 'QWEasd123!' -p 1434:1433 -d mcr.microsoft.com/mssql/server:2017-latest
	

EF Scaffolding	
https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=vs


* Additional DI
https://autofac.org/

* Automapper

https://automapper.org/

https://code-maze.com/automapper-net-core/


	

Usefull docker commands:

docker build -t eprodaja-api .

docker run -p 5192:5192 --name eprodaja-api-container eprodaja-api


docker image rm eprodaja-api --force


docker-compose up --build