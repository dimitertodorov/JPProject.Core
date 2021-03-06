using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Admin.Infra.Data.Context;
using JPProject.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;

namespace JPProject.Admin.Infra.Data.Repository
{
    public class ApiScopeRepository : Repository<ApiScope>, IApiScopeRepository
    {
        public ApiScopeRepository(JPProjectAdminUIContext adminUiContext) : base(adminUiContext)
        {
        }

        public Task<List<ApiScope>> SearchScopes(string search) => DbSet.Where(id => id.Name.Contains(search)).ToListAsync();
        public Task<List<ApiScope>> GetScopesByResource(string search) => DbSet.Include(s => s.UserClaims).Where(id => id.ApiResource.Name == search).ToListAsync();

    }
}