using JPProject.Admin.Domain.Interfaces;
using JPProject.Admin.Infra.Data.Configuration;
using JPProject.Admin.Infra.Data.Context;
using JPProject.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using JPProject.EntityFrameworkCore.Context;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseConfig
    {
        public static IJpProjectAdminBuilder WithSqlServer(this IJpProjectAdminBuilder services, string connectionString, JpDatabaseOptions options = null)
        {
            var migrationsAssembly = typeof(DatabaseConfig).GetTypeInfo().Assembly.GetName().Name;
            services.Services.AddEntityFrameworkSqlServer().AddAdminContext(opt => opt.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly)), options);

            return services;
        }

        public static IJpProjectAdminBuilder AddEventStoreSqlServer(this IJpProjectAdminBuilder services, string connectionString)
        {
            var migrationsAssembly = typeof(DatabaseConfig).GetTypeInfo().Assembly.GetName().Name;

            services.Services.AddDbContext<EventStoreContext>(opt => opt.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly)));

            return services;
        }
        public static IJpProjectAdminBuilder WithSqlServer(this IJpProjectAdminBuilder services, Action<DbContextOptionsBuilder> optionsAction, JpDatabaseOptions options = null)
        {
            services.Services.AddAdminContext(optionsAction, options);

            return services;
        }
    }
}