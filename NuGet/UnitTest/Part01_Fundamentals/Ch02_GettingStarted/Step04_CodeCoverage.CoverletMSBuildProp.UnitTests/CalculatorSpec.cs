using FluentAssertions;
using System;
using Xunit;

namespace Step04_CodeCoverage.CoverletMSBuildProp.UnitTests
{
    // 1. 코드 커버리지만 만들기
    //    dotnet test
    //      - dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/
    //      - 프로젝트 설정에서 모든 옵션을 처리한다.
    // 2. 코드 커버리지 & 커버리지 HTML 만들기
    //    dotnet test /t:coverage
    //    dotnet build /t:coverage
    //    dotnet msbuild /t:coverage
    public class CalculatorSpec
    {
        [Fact]
        public void Should_Add()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int actual = calc.Add(1, 6);

            // Assert 
            actual.Should().Be(7);
        }
    }
}
