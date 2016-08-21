# LightpointApp
LightpointApp project based on binding of OWIN self-hosted WebApi service to provide server-side functionality and AngularJS front-end framework to implement the client-server interaction. I decided to create an OWIN self-hosted WebApi service for possibility to run it as a simple console application. This allows to run the application on the web server without pre-installed IIS.

###High-level architecture
Project high-level architecture is based on 3-tier model that consists of presentation, business logic and data access layers. It allows to make class structure more clearly and extensible.
###Front-end part
Bootstrap has been used to create the web site interface.
AngularJS has been used as front-end framework for creating client-server interaction for my web-site. It’s a powerful framework that allows to easily create dynamic interfaces. Also it have a lot useful functionality for operating with data that requested from the web-service and displaying it on the web interface.
###Presentation layer 
This tier was used for implementing the WebApi REST service to provide base functionality for its clients.
###Business logic 
The middle-tier was used for implementing the Repository and Unit of Work design patterns that wrapped underlying EntityFramework context.
###Data Access layer & ORM
I used Entity Framework code-first approach for creating the database structure. Also default database initializer was being overriding for filling the database with a test values on application start. It’s makes the debugging process more convenient and clear. For updating database models has been created a migration class that allow up- and downgrade database and easily track changes with the possibility of change.
###IoC container
I used Ninject IoC container for dependency injection mechanism. It makes easier to test the code and develop complex logic structures.
###Database and other tools
As a database server the MS SQL Server 2012 Standard Edition has being used and Visual Studio 2015 Community – as IDE.
