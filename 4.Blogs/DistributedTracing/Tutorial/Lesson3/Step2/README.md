dotnet new console -o .\Lesson3\Step2\ClientConsole
dotnet sln add .\Lesson3\Step2\ClientConsole

dotnet new webapi -o .\Lesson3\Step2\ServerWebapi
dotnet sln add .\Lesson3\Step2\ServerWebapi

C:\DistributedTracing\Tutorial> dotnet add .\Lesson3\Step2\ reference .\LessonLib\

C:\DistributedTracing\Tutorial> dotnet run --project .\Lesson3\Step2\ServerWebapi\

