using Application.Users.Commands;
using Domain.Models.Circles;
using Domain.Models.Users;
using Domain.Services;
using InMemoryInfrastructure;
using InMemoryInfrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(UserGetCommand));

            services.AddSingleton<IUserFactory, UserFactory>();
            services.AddSingleton<IUserRepository, InMemoryUserRepository>();
            services.AddSingleton<UserService>();
            services.AddSingleton<ICircleFactory, CircleFactory>();
            services.AddSingleton<ICircleRepository, InMemoryCircleRepository>();
            services.AddSingleton<CircleService>();

            services.AddSingleton<InMemoryDataStore>();
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}