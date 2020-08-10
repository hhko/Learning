# .NET Unit Testing with AutoFixture

## 목표
- Simplify the arrange phase
- Generate anonymous test data
- Customize anonymous object creation
- Increase productivity
 
## 1. Getting Started with AutoFixture

### 1.1 Introduction
#### The Benefits of AutoFixture
- Increase productivity
- Reduce test maintenance
- Improve test readability
- Less test code

* 변경 전
  ```cs
  [Fact]
  public void SubtractWhenZeroTest()
  {
    // Arrange
    var sut = new Calculator();
    
    // Act
    sut.Subtract(1);
    
    // Assert
    Assert.True(sut.Value < 0);
  }
  ```
* 변경 후
  ```cs
  [Theory, AutoData]
  public void SubtractWhenZeroTest(int aPositiveNumber, Calculator sut)
  {
    // Act
    sut.Subtract(aPositiveNumber);
    
    // Assert
    Assert.True(sut.Value < 0);
  }
  ```

### 1.2 Simplifying the Arrange Phase of Tests with AutoFixture
#### Simplify and reduce arrange phase code
- 변경 전 : Arrange -> Act -> Assert
- 변경 후 
  - Arrange(Anonymous test data : AutoFixture) -> Act -> Assert
  - AutoFixture -> Act -> Assert

#### Anonmous Test Data
- Data that is required to be present for the test to be able to execute, but where the value itself is unimportant.
- 변경 전
  ```cs
  [Fact]
  public void SubtractWhenZeroTest()
  {
    // Arrange
    var sut = new Calculator();
    
    // Act
    sut.Subtract(1);  // 1 : Known test data
                      //     specify the test data manually
                      //     as long as it's a positive value
    
    // Assert
    Assert.True(sut.Value < 0);
  }
  ```
- 변경 후
  ```cs
  [Theory, AutoData]
  public void SubtractWhenZeroTest(int aPositiveNumber, Calculator sut)
  {
    // Act
    sut.Subtract(aPositiveNumber);   // aPositiveNumber : Anonymous test data
    
    // Assert
    Assert.True(sut.Value < 0);
  }
  ```
- AutoFixture
  - AutoFixture is an open source library for .NET designed to **minimize the 'Arrange' phase** of your unit tests in order to **maximize maintainability**. Its primary goal is to allow developers to focus on **what is being tested** rather than **how to setup the test scenario**, by making it easier to **create object graphs containing test data**.
  
### 1.3 Supported Frameworks
- AutoFixture is indenpendent of the testing framework or test runner.
- 지원 패키지
  - NUnit
  - xUnit.net
  - MSTest
  - Fixie
- .NET Framework : 4.5.2
- .NET Standard : 1.5, 2.0

### 1.4 Introducing the Fixture Class
- Test method - Fixture class - string, ...

### 1.5 Creating a Test Project and Installing AutoFixture
- [AutoFixture NuGet 4.13.0](https://www.nuget.org/packages/AutoFixture/)
- 4.11.0 예제 구성

### 1.6 Writing an Initial Test with Non-anonymous Test Data
- public : 테스트 클래스
- [Fact] : 단위 테스트 메서드 애트리뷰트
- Anonymous test data : 테스트를 수행하는 과정에서 실제 값이 무엇인지는 중요하지 않다(알 필요가 없다). 
 
### 1.7 Writing a Test with Manual Anonymous Test Data
- 상수 : ```1```
  ```cs
  [Fact]
  public void Create_AnonymousTestData_Manually()
  {
      // Arrnage
      var sut = new IntCalculator();
  
      // Act
      sut.Subtract(1);    // 1 : Anonymous test data
  
      // Assert
      Assert.True(sut.Value < 0);
  }
  ```
- 변수 : ```int aPositiveNumber = 1;```
  ```cs
  [Fact]
  public void Create_AnonymousTestData_Manually_By_Variable()
  {
      // Arrnage
      var sut = new IntCalculator();
      int aPositiveNumber = 1;   // 1 : Anonymous test data
  
      // Act
      sut.Subtract(aPositiveNumber);
  
      // Assert
      Assert.True(sut.Value < 0);
  }  
  ```
 
### 1.8 Using an AutoFixture Fixture Instance to Create Anonymous Test Data
- Fixture 클래스 : _TODO : fixture.Create<T> 음수 값이 없나???_
  ```cs
  [Fact]
  public void Create_AnonymousTestData_Automatically_By_AutoFixtrue()
  {
      // Arrnage
      var sut = new IntCalculator();
      var fixture = new Fixture();
      int aPositiveNumber = fixture.Create<int>(); // Anonymous test data : 실제 값은 중요하지 않다.
  
      // Act
      sut.Subtract(aPositiveNumber);
  
      // Assert
      Assert.True(sut.Value < 0);
  }
  ```

<br/>

## 2. Creating Anonymous Test Data and Objects with AutoFixture
### 2.1 Introduction
- Create anonymous test data
  - strings
  - numbers : int, float, double, ...
  - dates & times
  - enums & GUIDs
  - email addresses
  - sequences of anonymous values
  - instances of custom types
  - complex anonymous object graphs
  - objects with DataAnnotations
 
### 2.2 Creating Anonymous Strings
- ```fixture.Create<string>();```, ```fixture.Create<char>();```
  - **constrain the range of random values**을 생성한다.
 		 - firstName	: "42ee27f7-b895-4562-855a-c8af8a2080ae",	string
	 	 - lastName	: "67ff5868-6e34-4820-bff0-9966eae1251c",	string
- ```Create<T>(this ISpecimenBuilder builder)``` vs. ```Create<T>(this ISpecimenBuilder builder, T seed)```
  - ```public static T Create<T>(this ISpecimenBuilder builder)``` : Creates an anonymous variable of the requested type.
  - ```public static T Create<T>(this ISpecimenBuilder builder, T seed)``` : Creates an anonymous object, potentially using the supplied seed as additional information when creating the object.
    - [AutoFixture.SeedExtensions NuGet 4.13.0](https://www.nuget.org/packages/AutoFixture.SeedExtensions/) : Extensions for the most common AutoFixture operations to provide overloads with a seed.
    - 예. fixture.Create("First_");
  
### 2.3 Creating Anonymous Numbers
- Use anonymous values only when they **don't have a specific meaning to the SUT**.
- [Constrained Non-Determinism](https://blog.ploeh.dk/2009/03/05/ConstrainedNon-Determinism/)
  - For **input** where **the value** holds **a particular meaning in the context of the SUT**, you will still need to hand-pick values as always. E.g. if the input is expected to be an XML string conforming to a particular schema, a Guid string makes no sense.
- A given test must execute the same production code every time it is executed.
  - Anonymous values **should not affect logical program flow**.
- Numbers
  - ```fixture.Create<byte>();```
  - ```fixture.Create<double>();```
  - ```fixture.Create<short>();```
  - ```fixture.Create<long>();```
  - ```fixture.Create<sbyte>();```
  - ```fixture.Create<float>();```
  - ```fixture.Create<ushort>();```
  - ```fixture.Create<int>();```
  - ```fixture.Create<uint>();```
  - ```fixture.Create<ulong>();```
 
### 2.4 Creating Anonymous Dates and Times
### 2.5 Creating Enums and GUIDs
### 2.6 Generating Email Addresses
### 2.7 Creating Sequences of Anonymous Values
### 2.8 Creating Anonymous Instances of Custom Types
### 2.9 Creating Complex Anonymous Object Graphs
### 2.10 Creating Objects with DataAnnotations
### 2.11 Summary
- Anonymous test data
  - Use anonymous values only when they **don't have a specific meaning to the SUT**.
  - Anonymous values **should not affect logical program flow**.
