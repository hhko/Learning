using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaeger;
using LessonLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using OpenTracing.Util;

namespace ServerWebapi
{
    public class Startup
    {
        private readonly ILoggerFactory LoggerFactor;
        private readonly Tracer Tracer;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // 생성
            LoggerFactor = LoggerFactory.Create(builder => builder.AddConsole());
            Tracer = Tracing.Init("Webservice", LoggerFactor);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // OpenTracing 패키지
            // OpenTracing.Util 네임스페이스
            // GlobalTracer 클래스: static void Register(ITracer tracer)
            GlobalTracer.Register(Tracer);

            // OpenTracing.Contrib.NetCore 패키지
            // Microsoft.Extensions.DependencyInjection 네임스페이스
            // IServiceCollection 확장메서드: IServiceCollection AddOpenTracing(this IServiceCollection services, Action<IOpenTracingBuilder> builder = null);
            services.AddOpenTracing();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
