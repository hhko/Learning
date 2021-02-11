using Ch02.WebApp.Controllers;
using Ch02.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using Ch02.WebApp.Services;
using Microsoft.Extensions.Options;
using Ch02.WebApp.Configuration;

namespace Ch02.WebApp.UnitTests
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

            // Case 1. Options.Create 메서드 이용
            var options1 = Options.Create(new FeaturesConfiguration { EnableWeatherForecast = true });
            var sut = new HomeController(null, weatherForecaster.Object, options1);

            //// Case 2. Mock 이용
            //var options2 = new Mock<IOptions<FeaturesConfiguration>>();
            //options2
            //    .Setup(x => x.Value)
            //    .Returns(new FeaturesConfiguration { EnableWeatherForecast = true });
            //var sut2 = new HomeController(null, weatherForecaster.Object, options2.Object);

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

            var options1 = Options.Create(new FeaturesConfiguration { EnableWeatherForecast = true });
            var sut = new HomeController(null, weatherForecaster.Object, options1);

            var result = sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Contains("We're sorry but it's raining here.", model.WeatherDescription);
        }

        [Fact]
        public void ReturnsExpectedViewModel_WhenWeatherIsDisabled()
        {
            // Arrange
            var options1 = Options.Create(new FeaturesConfiguration { EnableWeatherForecast = false });
            var sut = new HomeController(null, null, options1);

            var result = sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Null(model.WeatherDescription);
        }
    }
}
