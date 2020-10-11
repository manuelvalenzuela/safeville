# Development decisions

Please remember, this is a Learning Project, so be patient with me, this is my actual knowledge until now. But in the same line, please don't hesitate if you want to write some suggestions, questions or even different ways to approach problems, I will be eager to try and learn...
Also, hopefully you will be helping many other developers to improve his craft.

## UseCase approach
I decided to drive the project using a Use case-Driven approach, for me seems to be more directly related with the Customer problem and language. I can correlate each file in the UseCases folder to each one of the major requirements that are exposed in the [project section](https://github.com/manuelvalenzuela/safeville/projects/1 "SafeVille Github Project").

## Projects and Folders Structure
Projects and Folders are structured in this way:
- **Entities**: This project will contain the objects that represent de data that is transformed by each UseCase to be stored in a Database. This project shouldn't have dependencies at all and it represents a boundary between the Core and Data projects.
- **Dtos**: This project will contain the data transfer objects that will be sent and received (In and Out) by the mobile application. In both cases (In and Out) the objects will be processed by the Core Project, so this project also represents a boundary between the Core and Rest API projects.
- **Core**: Here will be implemented the usecases. They will process the In.Dtos and send responses using Out.Dtos. Internally, usecases will decompose the In.Dtos and process it using Entities and the business rules that each Usecase need to acomplish its goals. Usecases should be close to be just functions, so I will try to stick to use static functions in every place I can.
- **Tests**

## Why static functions?
That is a question that I always ask myself, and I'm still elaborating an answer. Until now what I can say is that static functions are thread safe, they should use memory just to solve the small and particular function they are created and deallocate that memory after finished the last sentence.

## Nov 28th - Dependency Injection vs SharedContext
Along my previous experiences using ASP.Net (.NET Framework and .NET Core), I have implemented the 'traditional' (maybe should be renamed to 'do what all do') approach, that is to Inject every service you will use as a dependency inside Startup.cs --> ConfigureServices method.

After a while, that method turns into a very large list of injected services that not always you know why they are injected instead of being just created when they are needed.

My first decision was to follow the SharedContext approach, which enables to use a static Context with all the Services that are being used by some particular plugin, inverting the dependencies towards the main functionalities (the use cases).

In order to provide to the repositories the -scoped to the request- DbContext of EntityFramework used by each use case, I used the Dependency Injection container provided by ASP.NET Core in each Controller constructor to initialize the needed services of the SharedContext.


esto es un test