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
