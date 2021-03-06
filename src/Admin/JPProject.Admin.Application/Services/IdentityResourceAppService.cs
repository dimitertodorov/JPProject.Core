using AutoMapper;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using JPProject.Admin.Application.Interfaces;
using JPProject.Admin.Application.ViewModels.IdentityResourceViewModels;
using JPProject.Admin.Domain.Commands.IdentityResource;
using JPProject.Domain.Core.Bus;
using JPProject.Admin.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Application.Services
{
    public class IdentityResourceAppService : IIdentityResourceAppService
    {
        private IMapper _mapper;
        private IEventStoreRepository _eventStoreRepository;
        private readonly IIdentityResourceRepository _identityResourceRepository;
        public IMediatorHandler Bus { get; set; }

        public IdentityResourceAppService(IMapper mapper,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository,
            IIdentityResourceRepository identityResourceRepository)
        {
            _mapper = mapper;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
            _identityResourceRepository = identityResourceRepository;
        }


        public Task<IEnumerable<IdentityResourceListView>> GetIdentityResources()
        {
            var resultado = _identityResourceRepository.GetAll().Select(s => _mapper.Map<IdentityResourceListView>(s)).ToList();
            return Task.FromResult<IEnumerable<IdentityResourceListView>>(resultado);
        }

        public async Task<IdentityResource> GetDetails(string name)
        {
            var irs = await _identityResourceRepository.GetDetails(name);
            return irs.ToModel();
        }

        public Task Save(IdentityResource model)
        {
            var command = _mapper.Map<RegisterIdentityResourceCommand>(model);
            return Bus.SendCommand(command);
        }

        public Task Update(string resource, IdentityResource model)
        {
            var command = new UpdateIdentityResourceCommand(model, resource);
            return Bus.SendCommand(command);
        }

        public Task Remove(RemoveIdentityResourceViewModel model)
        {
            var command = _mapper.Map<RemoveIdentityResourceCommand>(model);
            return Bus.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}