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
  ``cs
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

### 1.9 Summary
