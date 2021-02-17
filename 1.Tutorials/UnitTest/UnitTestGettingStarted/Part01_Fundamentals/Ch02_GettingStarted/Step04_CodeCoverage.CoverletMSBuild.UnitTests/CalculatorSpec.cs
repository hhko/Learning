using FluentAssertions;
using System;
using Xunit;

namespace Step04_CodeCoverage.CoverletMSBuild.UnitTests
{
    // dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/
    // reportgenerator 
    //      "-reports:./TestResults/coverage.cobertura.xml"     // 코드 커버리지 파일
    //      "-targetdir:./TestResults/CoverageReport"           // 출력 경로
    //      -reporttypes:Html                                   // 출력 형식
    //      -historydir:./TestResults/CoverageHistory

    // reportgenerator "-reports:./TestResults/coverage.cobertura.xml" "-targetdir:./TestResults/CoverageReport" -reporttypes:Html -historydir:./TestResults/CoverageHistory
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
