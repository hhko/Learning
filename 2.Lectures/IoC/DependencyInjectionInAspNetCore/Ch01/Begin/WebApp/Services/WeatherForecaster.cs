﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch01.WebApp.Services
{
    public class WeatherForecaster
    {
        public WeatherResult GetCurrentWeather()
        {
            // Pretend we call out to a remote 3rd party API here to get the real forecast!
            // For demo purposes, the result is hard-coded.

            return new WeatherResult
            {
                WeatherCondition = WeatherCondition.Sun
            };
        }
    }
}