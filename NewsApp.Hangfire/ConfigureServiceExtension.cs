using Hangfire;
using NewsApp.Hangfire.Manager;
using NewsApp.Hangfire.Manager.Abstract;

namespace NewsApp.Hangfire
{
    public static class ConfigureServiceExtension
    {
        public static void AddHangfire(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();
            services.AddHangfire(_configuration =>
            {
                _configuration.UseSqlServerStorage(configuration.GetValue<string>("ConnectionStrings:SqlServerConnection"));
            });
            services.AddHangfireServer();
        }
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<ILocalRecuringJobManager, LocalReccuringJobManager>();
            services.AddScoped<ILocalBackgroundJobManager, LocalBackgroundJobManager>();
        }
    }
}
