using IdentityServer4.EntityFramework.Mappers;
using JPProject.Admin.Domain.Commands.IdentityResource;
using JPProject.Admin.Domain.Events.IdentityResource;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Commands;
using JPProject.Domain.Core.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JPProject.Admin.Domain.CommandHandlers
{
    public class IdentityResourceCommandHandler : CommandHandler,
        IRequestHandler<RegisterIdentityResourceCommand, bool>,
        IRequestHandler<UpdateIdentityResourceCommand, bool>,
        IRequestHandler<RemoveIdentityResourceCommand, bool>
    {
        private readonly IIdentityResourceRepository _identityResourceRepository;

        public IdentityResourceCommandHandler(
            IAdminUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IIdentityResourceRepository identityResourceRepository) : base(uow, bus, notifications)
        {
            _identityResourceRepository = identityResourceRepository;
        }


        public async Task<bool> Handle(RegisterIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _identityResourceRepository.GetByName(request.Resource.Name);
            if (savedClient != null)
            {
                await Bus.RaiseEvent(new DomainNotification("Identity Resource", "Resource already exists"));
                return false;
            }

            var irs = request.Resource.ToEntity();

            _identityResourceRepository.Add(irs);

            if (await Commit())
            {
                await Bus.RaiseEvent(new IdentityResourceRegisteredEvent(irs.Name));
                return true;
            }
            return false;

        }

        public async Task<bool> Handle(UpdateIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _identityResourceRepository.GetByName(request.OldIdentityResourceName);
            if (savedClient == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Identity Resource", "Resource not found"));
                return false;
            }

            var irs = request.Resource.ToEntity();
            irs.Id = savedClient.Id;
            await _identityResourceRepository.UpdateWithChildrens(irs);

            if (await Commit())
            {
                await Bus.RaiseEvent(new IdentityResourceUpdatedEvent(request.Resource));
                return true;
            }
            return false;
        }


        public async Task<bool> Handle(RemoveIdentityResourceCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }

            var savedClient = await _identityResourceRepository.GetByName(request.Resource.Name);
            if (savedClient == null)
            {
                await Bus.RaiseEvent(new DomainNotification("Identity Resource", "Resource not found"));
                return false;
            }

            _identityResourceRepository.Remove(savedClient.Id);

            if (await Commit())
            {
                await Bus.RaiseEvent(new IdentityResourceRemovedEvent(request.Resource.Name));
                return true;
            }
            return false;
        }
    }
}