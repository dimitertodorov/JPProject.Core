using IdentityServer4.EntityFramework.Entities;
using JPProject.Admin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPProject.Admin.Infra.Data.Context;
using JPProject.EntityFrameworkCore.Context;

namespace JPProject.Admin.Infra.Data.Repository
{
    public class ApiResourceRepository : Repository<ApiResource>, IApiResourceRepository
    {
        public ApiResourceRepository(JPProjectAdminUIContext adminUiContext) : base(adminUiContext)
        {
        }

        public Task<List<ApiResource>> GetResources() => DbSet.Include(s => s.UserClaims).ToListAsync();
        public Task<ApiResource> GetResource(string name) => DbSet.AsNoTracking().Include(s => s.Secrets).Include(s => s.Scopes).FirstOrDefaultAsync(s => s.Name == name);
        public Task<ApiResource> GetByName(string name)
        {
            return DbSet
                .Include(s => s.UserClaims)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task UpdateWithChildrens(ApiResource irs)
        {
            await RemoveClaims(irs);
            Update(irs);
        }

        private async Task RemoveClaims(ApiResource irs)
        {
            var apiResourceClaims = await Db.ApiResourceClaims.Where(x => x.ApiResource.Id == irs.Id).ToListAsync();
            Db.ApiResourceClaims.RemoveRange(apiResourceClaims);
        }
    }
}