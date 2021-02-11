using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ch02.WebApp.Models;
using Ch02.WebApp.Services;
using Ch02.WebApp.ViewModels;
using Microsoft.Extensions.Options;
using Ch02.WebApp.Configuration;

namespace Ch02.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherForecaster _weatherForecaster;
        private readonly FeaturesConfiguration _featuresConfiguration;

        public HomeController(
            ILogger<HomeController> logger,
            IWeatherForecaster weatherForecaster,
            IOptions<FeaturesConfiguration> options)
        {
            _logger = logger;
            _weatherForecaster = weatherForecaster;
            _featuresConfiguration = options.Value;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            if (_featuresConfiguration.EnableWeatherForecast)
            {
                //var weatherForecaster = new WeatherForecaster();
                //var currentWeather = weatherForecaster.GetCurrentWeather();
                var currentWeather = _weatherForecaster.GetCurrentWeather();

                switch (currentWeather.WeatherCondition)
                {
                    case WeatherCondition.Sun:
                        viewModel.WeatherDescription = "It's sunny right now. " +
                                                       "A great day for tennis.";
                        break;
                    case WeatherCondition.Rain:
                        viewModel.WeatherDescription = "We're sorry but it's raining " +
                                                       "here. No outdoor courts in use.";
                        break;
                    default:
                        viewModel.WeatherDescription = "We don't have the latest weather " +
                                                       "information right now, please check again later.";
                        break;
                }
            }

            return View(viewModel);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
