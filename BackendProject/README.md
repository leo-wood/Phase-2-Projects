# My Backend Project for MSA Phase 2
This project utilises the PokeAPI to retrieve a pokemon via their name and then adds them to your team.

Below are the demonstration requirements 

### Difference in Config files

The development configuration file defines the logging level as "Information", the default level. 
Allowed hosts is set to "*" allowing for requests to be made by any port number
The production configuration file allows for a connection to be made to a potential database. This is not currently used.


### Demonstrate how these middleware via DI (dependency injection) simplifies your code.



### Demonstrate why the middleware libraries made your code easier to test.

NUnit allows for quicker and easier testing within the project. Using the NUnit middleware framework, the [Test] attribute lets us mark a class as a test and then using NUnit's built-in Assert class to test whether my function is working as expected. This is demonstrated in my PokemonIsCreated() Test class.

