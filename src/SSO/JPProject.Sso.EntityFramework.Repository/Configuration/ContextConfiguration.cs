using JPProject.Domain.Core.Interfaces;
using JPProject.EntityFrameworkCore.Interfaces;
using JPProject.Sso.Domain.Interfaces;
using JPProject.Sso.EntityFramework.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JPProject.Sso.EntityFramework.Repository.Configuration
{
    public static class ContextConfiguration
    {
        public static IJpProjectConfigurationBuilder AddSsoContext<TContext, TEventStore>(this IJpProjectConfigurationBuilder services)
            where TContext : class, ISsoContext
            where TEventStore : class, IEventStoreContext

        {
            services.Services.AddScoped<IEventStoreContext, TEventStore>();
            services.Services.AddScoped<ISsoContext, TContext>();
            services.Services.AddScoped<IJpEntityFrameworkStore>(x => x.GetRequiredService<TContext>());
            services.Services.AddStores();
            return services;
        }
        public static IJpProjectConfigurationBuilder AddSsoContext<TContext>(this IJpProjectConfigurationBuilder services)
            where TContext : class, ISsoContext, IEventStoreContext

        {
            services.Services.AddScoped<ISsoContext, TContext>();
            services.Services.AddScoped<IEventStoreContext>(s => s.GetService<TContext>());
            services.Services.AddScoped<IJpEntityFrameworkStore>(x => x.GetRequiredService<TContext>());
            services.Services.AddStores();
            return services;
        }
    }
}
