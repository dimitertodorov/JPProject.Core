using JPProject.Admin.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JPProject.Admin.Application.Configuration.DependencyInjection
{
    public class JpProjectAdminBuilder : IJpProjectAdminBuilder
    {
        public JpProjectAdminBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
