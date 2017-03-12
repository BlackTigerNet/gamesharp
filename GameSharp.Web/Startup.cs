using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using GameSharpBackend.Repositories;
using Autofac.Features.Variance;
using MediatR;
using System.Reflection;
using System.Collections.Generic;
using GameSharpApi.Commands;
using GameSharpApi.Queries;
using GameSharpBackend.CommandHandlers;
using GameSharpBackend.QueryHandlers;
using GameSharpBackend.Queries;
using GameSharp.Core.Repositories;

namespace GameSharpWeb
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            

            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            builder.RegisterType<MysqlGameRepository>().As<IGameRepository>().SingleInstance();

            builder.Populate(services);

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterType(typeof(EditGameCmd));
            builder.RegisterType(typeof(DeleteGameCmd));
            builder.RegisterType(typeof(GetAllGamesQuery));
            builder.RegisterType(typeof(GetGameByIdQuery));

            builder.RegisterType(typeof(EditGameHandler)).AsImplementedInterfaces();
            builder.RegisterType(typeof(DeleteGameHandler)).AsImplementedInterfaces();
            builder.RegisterType(typeof(GetAllGamesQueryHandler)).AsImplementedInterfaces();
            builder.RegisterType(typeof(GetGameByIdQueryHandler)).AsImplementedInterfaces();

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t =>
                {
                    return c.TryResolve(t, out object o) ? o : null;
                };
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute("gameDoEdit", "{id}/edit",
                    defaults: new { controller = "Games", action = "DoEdit" });

                routes.MapRoute("gameEdit", "{id}/edit",
                    defaults: new { controller = "Games", action = "Edit" });

                routes.MapRoute("gameDoDelete", "{id}/delete",
                    defaults: new { controller = "Games", action = "DoDelete" });

                routes.MapRoute("gameDelete", "{id}/delete",
                    defaults: new { controller = "Games", action = "Delete" });

                routes.MapRoute("gameDetails", "{id}",
                    defaults: new { controller = "Games", action = "Details" });

                routes.MapRoute("gameIndex", "",
                    defaults: new { controller = "Games", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
