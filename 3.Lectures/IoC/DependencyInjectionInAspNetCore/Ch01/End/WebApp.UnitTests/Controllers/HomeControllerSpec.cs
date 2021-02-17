using Ch01.WebApp.Controllers;
using Ch01.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Ch01.WebApp.Services;

namespace Ch01.WebApp.UnitTests
{
    public class HomeControllerSpec_End
    {
        [Fact]
        public void ReturnsExpectedViewModel_WhenWeatherIsSun()
        {
            // Arrange
            var weatherForecaster = new Mock<IWeatherForecaster>();
            weatherForecaster
                .Setup(x => x.GetCurrentWeather())
                .Returns(new WeatherResult
                {
                    WeatherCondition = WeatherCondition.Sun
                });

            var sut = new HomeController(null, weatherForecaster.Object);

            // Act
            var result = sut.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Contains("It's sunny right now.", model.WeatherDescription);
        }

        [Fact]
        public void ReturnsExpectedViewModel_WhenWeatherIsRain()
        {
            // Arrange
            var weatherForecaster = new Mock<IWeatherForecaster>();
            weatherForecaster
                .Setup(x => x.GetCurrentWeather())
                .Returns(new WeatherResult
                {
                    WeatherCondition = WeatherCondition.Rain
                });

            var sut = new HomeController(null, weatherForecaster.Object);

            var result = sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Contains("We're sorry but it's raining here.", model.WeatherDescription);
        }
    }
}
