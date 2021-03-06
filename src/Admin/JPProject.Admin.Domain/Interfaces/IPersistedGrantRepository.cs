using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using JPProject.Domain.Core.Interfaces;
using JPProject.Domain.Core.ViewModels;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IPersistedGrantRepository : IRepository<PersistedGrant>
    {
        Task<List<PersistedGrant>> GetGrants(PagingViewModel paging);
        Task<int> Count();
    }
}