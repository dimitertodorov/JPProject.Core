using AutoMapper;
using System.Collections.Generic;

namespace JPProject.Admin.Application.AutoMapper
{
    public class AdminUiMapperConfiguration
    {
        public static List<Profile> RegisterMappings()
        {
            var cfg = new List<Profile>
            {
                new IdentityServer4.EntityFramework.Mappers.ApiResourceMapperProfile(),
                new IdentityServer4.EntityFramework.Mappers.ClientMapperProfile(),
                new IdentityServer4.EntityFramework.Mappers.IdentityResourceMapperProfile(),
                new IdentityServer4.EntityFramework.Mappers.PersistedGrantMapperProfile(),
                new DomainToViewModelMappingProfile(),
                new ViewModelToDomainMappingProfile()
            };

            return cfg;
        }
    }
}
