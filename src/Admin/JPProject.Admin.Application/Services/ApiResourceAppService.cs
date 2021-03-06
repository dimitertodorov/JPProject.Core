using AutoMapper;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using JPProject.Admin.Application.Interfaces;
using JPProject.Admin.Application.ViewModels;
using JPProject.Admin.Application.ViewModels.ApiResouceViewModels;
using JPProject.Admin.Domain.Commands.ApiResource;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPProject.Domain.Core.Interfaces;

namespace JPProject.Admin.Application.Services
{
    public class ApiResourceAppService : IApiResourceAppService
    {
        private IMapper _mapper;
        private IEventStoreRepository _eventStoreRepository;
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IApiSecretRepository _secretRepository;
        private readonly IApiScopeRepository _apiScopeRepository;
        public IMediatorHandler Bus { get; set; }

        public ApiResourceAppService(IMapper mapper,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository,
            IApiResourceRepository apiResourceRepository,
            IApiSecretRepository secretRepository,
            IApiScopeRepository apiScopeRepository)
        {
            _mapper = mapper;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
            _apiResourceRepository = apiResourceRepository;
            _secretRepository = secretRepository;
            _apiScopeRepository = apiScopeRepository;
        }

        public async Task<IEnumerable<ApiResourceListViewModel>> GetApiResources()
        {
            var resultado = await _apiResourceRepository.GetResources();
            return resultado.Select(s => _mapper.Map<ApiResourceListViewModel>(s)).ToList();
        }

        public async Task<ApiResource> GetDetails(string name)
        {
            var resultado = await _apiResourceRepository.GetByName(name);
            return resultado.ToModel();
        }

        public Task<bool> Save(ApiResource model)
        {
            var command = _mapper.Map<RegisterApiResourceCommand>(model);
            return Bus.SendCommand(command);
        }

        public Task<bool> Update(string id, ApiResource model)
        {
            var command = new UpdateApiResourceCommand(model, id);
            return Bus.SendCommand(command);

        }

        public Task<bool> Remove(RemoveApiResourceViewModel model)
        {
            var command = _mapper.Map<RemoveApiResourceCommand>(model);
            return Bus.SendCommand(command);
        }

        public async Task<IEnumerable<SecretViewModel>> GetSecrets(string name)
        {
            return _mapper.Map<IEnumerable<SecretViewModel>>(await _secretRepository.GetByApiName(name));
        }

        public Task<bool> RemoveSecret(RemoveApiSecretViewModel model)
        {
            var registerCommand = _mapper.Map<RemoveApiSecretCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public Task<bool> SaveSecret(SaveApiSecretViewModel model)
        {
            var registerCommand = _mapper.Map<SaveApiSecretCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public async Task<IEnumerable<ScopeViewModel>> GetScopes(string name)
        {
            var scopes = await _apiScopeRepository.GetScopesByResource(name);
            return _mapper.Map<IEnumerable<ScopeViewModel>>(scopes);
        }

        public Task<bool> RemoveScope(RemoveApiScopeViewModel model)
        {
            var registerCommand = _mapper.Map<RemoveApiScopeCommand>(model);
            return Bus.SendCommand(registerCommand);
        }


        public Task<bool> SaveScope(SaveApiScopeViewModel model)
        {
            var registerCommand = _mapper.Map<SaveApiScopeCommand>(model);
            return Bus.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}