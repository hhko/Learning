# Testing with EF Core

## 자료
- [Testing with EF Core](https://app.pluralsight.com/library/courses/ef-core-testing/table-of-contents)
- Entity Framework Core: Getting Started(Testing with the InMemory Provider Instead of a Real Database)
- Blogs
  - [Using in-memory databases for unit testing EF Core applications](https://www.thereformedprogrammer.net/using-in-memory-databases-for-unit-testing-ef-core-applications/)
  - [EF Core 테스트 샘플](https://docs.microsoft.com/ko-kr/ef/core/miscellaneous/testing/testing-sample)
- Youtube
  - [Simplified Unit Testing with the Entity Framework Core InMemory Provider](https://www.youtube.com/watch?v=ddrR440JtiA)
  - [Making unit tests simple again with .Net Core and EF Core](https://www.youtube.com/watch?v=6nYefHkKby8)

## 목표
- 데이터베이스 제공자 : InMemory and SQLite database providers 이해하기
- 격리 : Test isolation of InMemory and SQLite database providers
- 로그 : Logging EF Core unit test logs

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
1. Improving the Reliability of EF Core Testing with SQLite
   - 3.1 Coming Up
   - 3.2 Introducing SQLite
   - 3.3 Demo - Unit Testing with SQLite
   - 3.4 Demo - Using Multiple DbContext Instances
   - 3.5 Demo - Testing with Referential Integrity
   - 3.6 Adding EF Core Logging
   - 3.7 Demo - Adding EF Core Logging
   - 3.8 Demo - Logging to Test Explorer
   - 3.9 Limitations of SQLite
   - 3.10 Summary

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
- Phases
  - Arrange : Set up the test
    - 예. Set up the context, instantiate the repository, create an author to add
  - Act : Invoke the method we want to test
    - 예. Call the AddAuthor method on the repository
  - Assert : Verify that the action of the tested method behaved as expected
    - 예. Check if the author was added
 - AAA Pattern
   - Separates what is being tested from the rest
   - The chance of mixing assertions inside of the act-set dininishes
 - Both work towards better readability
   - Makes it easy to understand how the code works
   - Makes it easier to find out why a test fails
- 목표
  - 구조화 : 3개 영역으로 구분 -> 명확한 목표 -> 읽기 쉬운 코드, 실패 이유
- 단위 테스트 이름
  - ```AddAuthor_Author_AuthorIsAdded```
    - ```AddAuthor_``` : Name of the method being tested
    - ```_Author_``` : Scenario (state) under which the method is being tested
    - ```_AuthorIsAdded``` : Expected behavior when the scenario is invoked

### 2.5 Demo - Writing Your First Unit Test Using the Inmemory Database Provider
- xUnit 프로젝트 생성 : ASP.NET, EF Core을 위한 추가 패키지 설치는 필요 없다.
- 메모리 데이터베이스로 DbContet 객체 생성하기
  ```cs
  var options = new DbContextOptionsBuilder<CourseContext>()
        .UseInMemoryDatabase("CourseDatabaseForTesting")
        .Options;

  using (var context = new CourseContext(options))
  {
    // ...
  }
  ```

### 2.6 Demo - Writing Additional Unit Tests
- 단위 테스트가 InMemory 데이터베이스를 공유하고 있다. 단위 테스트는 격리되지 않는다.
  ```cs
  CourseManager.API.Tests.AuthorRepositoryTests.AddAuthor_AuthorWithoutCountryId_AuthorHasBEAsCountryId
     Source: AuthorRepositoryTests.cs line 80
     Duration: 11 ms
  Message: 
     System.ArgumentException : An item with the same key has already been added. Key: BE
  ```
- 이유
  - ```.UseInMemoryDatabase("CourseDatabaseForTesting")``` : 같은 이름을 사용하기 때문이다.
  ```cs
  [Fact]
  public void 1...()
  {
    var options = new DbContextOptionsBuilder<CourseContext>()
        .UseInMemoryDatabase("CourseDatabaseForTesting")
        .Options;

    using (var context = new CourseContext(options))
    { ... }
  }

  public void 2...()
  {
    var options = new DbContextOptionsBuilder<CourseContext>()
        .UseInMemoryDatabase("CourseDatabaseForTesting")
        .Options;

    using (var context = new CourseContext(options))
    { ... }    
  }
  ```

### 2.7 Isolating Tests
- 격리(Isolation) : 단위 테스트는 개별로 수행한다(데이터를 공유하지 않는다. : 개별 인스턴스)
- Each test shoud start with a clean, seperate database to avoid interference
  - 이득 : Tests running in parallel make this even more clear

### 2.8 Demo - Isolating Tests
- InMemory 데이터베이스를 격리 시키기 위해서는 개별 이름을 가져야 한다.
  ```cs
  var options = new DbContextOptionsBuilder<CourseContext>()
        .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
        .Options;
  ```

### 2.9 Improving Tests by Using Multiple DbContext Instances
- Isherent disconnected nature in ASP.NET Core
  - **Each request uses its own context instance**

### 2.10 Demo - Using Multiple DbContext Instances
- statement 단위로 context을 분리한다.
- 변경 전
  ```cs
  using (var context = new CourseContext(options))
  {
    context.Authors.Add( ... );
    ...
    context.SaveChanges();

    var repo = new AuthorRepository(context);
    repo. ...;
  }
  ```
- 변경 후
  ```cs
  using (var context = new CourseContext(options))
  {
    context.Authors.Add( ... );
    ...
    context.SaveChanges();
  }

  using (var context = new CourseContext(options))
  {
    var repo = new AuthorRepository(context);
    repo. ...;
  }
  ```

### 2.11 Mocking Limitations of the InMemory Database Provider
- It's not a perfect replacement for DbContext mocking or for a real database
- InMemory 데이터베이스는 Relationship 데이터베이스가 아니다.

### 2.12 Demo - Testing with Referential Integrity
- Foreign Key가 등록되지 않아도 단위 테스트가 성공한다.
  ```cs
  using (var context = new CourseContext(options))
  {
      // Foreign Key가 등록되어 있지 않아도 테스트가 성공한다.
      // why?
      //   InMemory 데이터베이스는 Relationship 데이터베이스가 아니기 때문이다.
      //context.Countries.Add(new Country()
      //{
      //    Id = "BE",
      //    Description = "Belgium"
      //});

      //context.Countries.Add(new Country()
      //{
      //    Id = "US",
      //    Description = "United States of America"
      //});

      context.Authors.Add(new Author()
        { 
          FirstName = "Kevin", 
          LastName = "Dockx", 
          CountryId = "BE" 
        });

      context.SaveChanges();
  }
  ```

### 2.13 Advantages and Disadvantages of the InMemory Database Provider
- Advantages
  - Mostly doesn't use database specific features
  - Doesn't depend on relational features
  - Fast
- Disadvantages
  - The InMemory database provider isn't a relation database
    - No referential integrity checks : Foreign Key 유요성 검사
    - No DefaultValueSql(string)
    - No TimeStamp or IsRowVersion
    - ...
- InMemory 데이터베이스 제공자는 여러가지 이유로 Production 환경을 대처하지 못한다.

### 2.14 Summary
- The InMemory database provider is designed to be a general purpose database for testing, fully running in memory
  - Allows unit testing parts of our code that would normally be tested through integration tests

<br/>

## 3. Improving the Reliability of EF Core Testing with SQLite

### 3.1 Coming Up
- SQLite
- Logging

### 3.2 Introducing SQLite
- SQLite is a self-contained, serverless, zero-configuration, transactional SQL database engine
  - self-contained : Requires minial OS support
  - serverless : Doesn't require a separate server process
  - zero-configuration : No installation or link to server process
  - transactional SQL database engine : Changes happen completely or not at all

### 3.3 Demo - Unit Testing with SQLite
- 패키지 추가 : ```<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.1.7" />```
- 데이터베이스 접속을 변경한다.
  ```cs
  using Microsoft.Data.Sqlite;
  using Microsoft.EntityFrameworkCore;

  var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
  var connection = new SqliteConnection(connectionStringBuilder.ToString());

  var options = new DbContextOptionsBuilder<CourseContext>()
      .UseSqlite(connection)
      .Options;
  ```
- 데이터베이스 접속을 명시적으로 호출해야 한다.
  - 호출 전 : 접속을 호출하지 않으면 다음과 같은 예외가 발생한다.
    ```cs
    Assert.Throws() Failure
    Expected: typeof(System.ArgumentException)
    Actual:   typeof(Microsoft.Data.Sqlite.SqliteException): SQLite Error 1: 'no such table: Author'.
    ---- Microsoft.Data.Sqlite.SqliteException : SQLite Error 1: 'no such table: Author'.
    ```
  - 호출
    ```cs
    using (var context = new CourseContext(options))
    {
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        ...
    }
    ```

### 3.4 Demo - Using Multiple DbContext Instances
- 한번만 호출하면 된다.
  ```cs
  context.Database.OpenConnection();
  context.Database.EnsureCreated();
  ```
- 여러번 호출되어도 예외 또는 결과 값이 변하지 않는다.

### 3.5 Demo - Testing with Referential Integrity
- Foreign key 관련 예외를 확인한다.
- SQLite는 Foreign Key 관계를 검증한다(InMemory에서는 제공하지 않는다).
  ```cs
  Microsoft.EntityFrameworkCore.DbUpdateException : An error occurred while updating the entries. See the inner exception for details.
  ----Microsoft.Data.Sqlite.SqliteException : SQLite Error 19: 'FOREIGN KEY constraint failed'.
  ```

### 3.6 Adding EF Core Logging
- [EfCore.TestSupport](https://github.com/JonPSmith/EfCore.TestSupport)
- When a unit test fails
  - You know the expected behavior hasn't been met
- Microsoft.Extensions.Logging
- LoggerFactory, ILoggerProvider, ILogger

### 3.7 Demo - Adding EF Core Logging
- .UseLoggerFactory(new LoggerFactory(new [] { ... }))
  ```cs
  internal class SqliteLogger : ILogger
  {
      private readonly Action<string> _action;
      private readonly LogLevel _logLevel;

      public SqliteLogger(Action<string> aAction, LogLevel logLevel)
      {
          _action = aAction;
          _logLevel = logLevel;
      }

      public IDisposable BeginScope<TState>(TState state)
      {
          return null;
      }

      public bool IsEnabled(LogLevel logLevel)
      {
          return logLevel >= _logLevel;
      }

      public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
      {
          _action($"LogLevel: {logLevel}, {state}");
      }
  }

  internal class SqliteLoggerProvider : ILoggerProvider
  {
      private readonly Action<string> _action;
      private readonly LogLevel _logLevel;

      public SqliteLoggerProvider(
          Action<string> action,
          LogLevel logLevel = LogLevel.Information)
      {
          _action = action;
          _logLevel = logLevel;
      }

      public ILogger CreateLogger(string categoryName)
      {
          return new SqliteLogger(_action, _logLevel);
      }

      public void Dispose()
      {
          
      }
  }

  public class AuthorRepositoryTests_SQLite
  {
      private readonly ITestOutputHelper _output;

      public AuthorRepositoryTests_SQLite(ITestOutputHelper output)
      {
          _output = output;
      }
      
  .UseLoggerFactory(new LoggerFactory(new[] {
      new SqliteLoggerProvider(message =>
      {
        _output.WriteLine(message);
      }) }))
  ```

### 3.8 Demo - Logging to Test Explorer
- ITestOutputHelper
  ```cs
  LogLevel: Information, Entity Framework Core 3.1.7 initialized 'CourseContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite' with options: None
  LogLevel: Information, Executed DbCommand (32ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
  SELECT COUNT(*) FROM "sqlite_master" WHERE "type" = 'table' AND "rootpage" IS NOT NULL;
  LogLevel: Information, Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
  CREATE TABLE "Country" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Country" PRIMARY KEY,
    "Description" TEXT NULL
  );
  ```

### 3.9 Limitations of SQLite
- Lacks support for
  - Schemas
  - SQL sequences
- Different implementation of
  - Computed columns
  - User-defined functions
  - Fragment default values
  - Column types

### 3.10 Summary

## 4. 정리
### 4.1 DbContext
- DbContext 등록 : services.AddDbContext<CourseContext>(options => ... )
- DbContext 옵션 주입 : public CourseContext(DbContextOptions<CourseContext> options) : base(options)
- DbContext 옵션 생성 : protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

### 4.2 InMemory database provider 단위 테스트
- DbContext 옵션 생성
  ```cs
  var options = new DbContextOptionsBuilder<CourseContext>()
        .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
        .Options;
	```
- DbContext 개별 생성 : statement 단위로 개별 생성
  ```cs	
  using (var context = new CourseContext(options)) 
  { 
    ... 
  }
  ```
- InMemory database provider는 Foreign Key을 검증하지 못한다.

### 4.3 SQLite database provider 단위 테스트
- 패키지
  ```cs
  using Microsoft.Data.Sqlite;
  using Microsoft.EntityFrameworkCore;
  ```
- DbContext 옵션 생성
  ```cs
  var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
  var connection = new SqliteConnection(connectionStringBuilder.ToString());

  var options = new DbContextOptionsBuilder<CourseContext>()
      .UseSqlite(connection)
      .Options;
	```
- DbContext 명시적 접속과 테이블 생성
  ```cs 
  using (var context = new CourseContext(options))
  {
      context.Database.OpenConnection();
      context.Database.EnsureCreated();
- Logger 객체 생성
  ```cs
  class SqliteLogger : ILogger
  class SqliteLoggerProvider : ILoggerProvider
  
  .UseLoggerFactory(new LoggerFactory(new[] {
      new SqliteLoggerProvider(message =>
      {
        _output.WriteLine(message);
      }) }))
  ```