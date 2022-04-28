
namespace CreditCards
{
    using CreditCards.Core.Interfaces;
    using CreditCards.Infrastructure;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            CurrentEnvironment = env;
        }

        public IConfigurationRoot Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (CurrentEnvironment.IsDevelopment())
            {
                services.AddDbContext<AppDbContext>(
                    options => options.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                        ServiceLifetime.Scoped,
                        ServiceLifetime.Scoped);
            }
            else
            {
                services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            }


            services.AddScoped<ICreditCardApplicationRepository,
                               EntityFrameworkCreditCardApplicationRepository>();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddControllersWithViews();
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                dbContext.Database.EnsureCreated();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
