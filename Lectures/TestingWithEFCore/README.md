# Testing with EF Core

## 자료
- [Testing with EF Core](https://app.pluralsight.com/library/courses/ef-core-testing/table-of-contents)
- Blogs
  - ...
- Youtube
  - ... 

## 목표
- InMemory and SQLite database providers
- Test isolation
- Logging EF Core logs

## 목차
1. Getting Started with EF Core Testing
   - 1.1 Coming Up
   - 1.2 Course Prerequisites
   - 1.3 Learning About Different Ways to Test Your Application
   - 1.4 Unit Testing with EF Core
   - 1.5 Demo - Introducing the Demo Application
   - 1.6 Summary
1. Unit Testing Your Code with EF Core InMemory
   - 2.1 Coming Up
   - 2.2 Learning What the EF Core InMemory Database Provider Is
   - 2.3 Demo - Getting Ready for Testing with the InMemory Database Provider
   - 2.4 Unit Testing with the Arrange, Act, Assert Pattern
   - 2.5 Demo - Writing Your First Unit Test Using the Inmemory Database Provider
   - 2.6 Demo - Writing Additional Unit Tests
   - 2.7 Isolating Tests
   - 2.8 Demo - Isolating Tests
   - 2.9 Improving Tests by Using Multiple DbContext Instances
   - 2.10 Demo - Using Multiple DbContext Instances
   - 2.11 Mocking Limitations of the InMemory Database Provider
   - 2.12 Demo - Testing with Referential Integrity
   - 2.13 Advantages and Disadvantages of the InMemory Database Provider
   - 2.14 Summary

## 1. Getting Started with EF Core Testing

### 1.1 Coming Up

### 1.2 Course Prerequisites
- Framekwork and Packages
  - .NET Core 2.2
  - EF Core 2.2
  - xUnit 2.2

### 1.3 Learning About Different Ways to Test Your Application
- Unit testing
  - Unit tests test small, individual software components
    - Simple to write, low complexity
  - Unit tests must be well encapsulated
    - When a test fails, it's the actual code we're testing that fails
    - Infrastructure concerns are mocked away 
  - Unit tests are fast and run often
  - Popular unit testing frameworks : xUnit, ...
  - **In unit test infrastructure-related components are mocked away**
- Integration testing
  - Integration tests evaluate applications on a broader level than unit test
    - They tell you whether 2 or more components correctly work together
    - They can, but don't have to, test the full request/response cycle
  - The same testing framework as for unit testing can be used
  - Integration tests are less encapsulated than unit tests, more complex, take longer to run
    - A failed test doesn't necessarily tell you which component it was that resulted in the failure
  - Use integration tests to find out if changes in your application environment result in failure
  - **When we call into an external component from a "unit test" it becomes an integration test**
  - Integration tests test application infrastructure(external component)
- Functional testing
  - Functional or end to end tests test the full functionality of an application
  - These tests can be manual or automated(Selenium, ...)
  - Functional tests have high complexity, are slow to execute and badly encapsulated

| tests | encapsulated | dependency | complexity | automated | frameworks |
| --- | --- | --- | --- | --- | --- |
| Unit test | 1 | mocked | low | automated | xUnit, ...
| Integration test | 2 or more | non-mocked | medicum | automated | xUnit, ...
| Functional test | end to end | non-mocked | high | automated or manual | Selenium, ...

### 1.4 Unit Testing with EF Core
- We can mock away the underlying database by using an EF Core in-memory database provider
  - InMemory database provider
  - SQLite database provider
- database-specific functionality

### 1.5 Demo - Introducing the Demo Application
- [Testing With EF Core GitHub](https://github.com/KevinDockx/TestingWithEFCore)
- CourseContext.cs
  ```cs
  public class CourseContext : DbContext
  {
      public DbSet<Course> Courses { get; set; }

      public DbSet<Author> Authors { get; set; }

      public DbSet<Country> Countries { get; set; }
  }
  ```

### 1.6 Summary
- Use an in-memory database provider with EF Core to mocked away the actual database

<br/>

## 2. Unit Testing Your Code with EF Core InMemory

### 2.1 Coming Up
- AAA(Arrange, Act, Assert) pattern
- Test isolation
- Limitations and (dis)advantages of the in-memory database provider

### 2.2 Learning What the EF Core InMemory Database Provider Is
- Object-relational mapping
  - ORM is a technique that lets us query and manipulate data from a database using an object-oriented paradigm
- EF Core can be regarded as an ORM
  - Allows us to work on objects instead of working SQL statements
- EF Core
  - Model
    - Entity classes
    - DbContext : a represnetation of a session with the database
  - Provider
    - Contains logic on how to interact with the database

### 2.3 Demo - Getting Ready for Testing with the InMemory Database Provider
- ASP.NET Web 프로젝트, API
- DbContext 생성
  ```cs
  public static void Main(string[] args)
  {
      var host = CreateHostBuilder(args).Build();

      using (var scope = host.Services.CreateScope())
      {
          try
          {
              var context = scope.ServiceProvider.GetService<CourseContext>();
              //context.Database. ...;
          }
          catch (Exception ex)
          {
              var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
              logger.LogError(ex, "An error occured while migrating the database.");
          }
      }

      host.Run();
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          });
  ```
- DbContext 추가
  ```cs
  public void ConfigureServices(IServiceCollection services)
  {
      services.AddControllers();

      services.AddDbContext<CourseContext>(options =>
      {
          // var context = scope.ServiceProvider.GetService<CourseContext>();가 호출되면 호출된다.
          // CourseContext 생성자로 Option을 전달한다.
          //   public CourseContext(DbContextOptions<CourseContext> options)
          options.UseInMemoryDatabase("CourseManagerInMemoryDB");
      });
  }

  public class CourseContext : DbContext
  {
      // Case 1. 외부에서 옵션 전달받기
      public CourseContext(DbContextOptions<CourseContext> options)
       : base(options)
      {
          // _options.Extensions[1] StoreName : "CourseManagerInMemoryDB", string
      }

      // Case 2. 직접 옵션 설정하기
      // TODO : 호출이 안된다. 언제 호출되는 것일까?
      //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //{
      //    //base.OnConfiguring(optionsBuilder);

      //    if (!optionsBuilder.IsConfigured)
      //    {
      //        optionsBuilder
      //            .UseInMemoryDatabase("CourseManagerInMemoryDB");
      //    }
      //}

      ...
  }
  ```

### 2.4 Unit Testing with the Arrange, Act, Assert Pattern
### 2.5 Demo - Writing Your First Unit Test Using the Inmemory Database Provider
### 2.6 Demo - Writing Additional Unit Tests
### 2.7 Isolating Tests
### 2.8 Demo - Isolating Tests
### 2.9 Improving Tests by Using Multiple DbContext Instances
### 2.10 Demo - Using Multiple DbContext Instances
### 2.11 Mocking Limitations of the InMemory Database Provider
### 2.12 Demo - Testing with Referential Integrity
### 2.13 Advantages and Disadvantages of the InMemory Database Provider
### 2.14 Summary