﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Step_01_Helloworld
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(Program));
            var provider = services.BuildServiceProvider();

            var mediator = provider.GetService<IMediator>();
            var pong = await mediator.Send(new Ping { Message = "Ping" });

            Console.WriteLine($"{pong.Message}");
        }
    }
}
