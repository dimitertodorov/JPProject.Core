using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using JPProject.Admin.Domain.Validations.Client;
using JPProject.Domain.Core.StringUtils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPProject.Admin.Domain.Commands.Clients
{
    public class SaveClientCommand : ClientCommand
    {
        public ClientType ClientType { get; }

        public SaveClientCommand(string clientId, string name, string clientUri, string logoUri, string description,
            ClientType clientType, string postLogoutUri)
        {
            this.Client = new Client()
            {
                ClientId = clientId,
                ClientName = name,
                ClientUri = clientUri,
                LogoUri = logoUri,
                Description = description,
            };

            if (postLogoutUri.IsPresent())
                Client.PostLogoutRedirectUris = new List<string>() { postLogoutUri };
            ClientType = clientType;
        }

        public IdentityServer4.EntityFramework.Entities.Client ToEntity()
        {
            PrepareClientTypeForNewClient();
            return Client.ToEntity();
        }

        private void PrepareClientTypeForNewClient()
        {
            switch (ClientType)
            {
                case ClientType.Empty:
                    break;
                case ClientType.Device:
                    ConfigureDevice();
                    break;
                case ClientType.WebImplicit:
                    ConfigureWebImplicit();
                    break;
                case ClientType.Spa:
                    ConfigureWebImplicit();
                    break;
                case ClientType.WebHybrid:
                    ConfigureWebHybrid();
                    break;
                case ClientType.Native:
                    ConfigureNative();
                    break;
                case ClientType.Machine:
                    ConfigureMachine();

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ClientType));
            }

        }

        private void ConfigureDefaultUrls()
        {
            if (Client.ClientUri.IsPresent())
            {
                Client.AllowedCorsOrigins.Add(Client.ClientUri);
                Client.RedirectUris.Add(Client.ClientUri);

                if (!Client.PostLogoutRedirectUris.Any())
                    Client.PostLogoutRedirectUris.Add(Client.ClientUri);
            }

        }

        public override bool IsValid()
        {
            ValidationResult = new SaveClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        private void ConfigureDevice()
        {
            Client.AllowedGrantTypes.Add(GrantType.DeviceFlow);
            Client.AllowedScopes.Add("openid");

            Client.RequireClientSecret = false;
            Client.AllowOfflineAccess = true;

        }

        private void ConfigureWebImplicit()
        {
            Client.AllowedGrantTypes.Add(GrantType.Implicit);
            Client.AllowAccessTokensViaBrowser = true;
            Client.AlwaysIncludeUserClaimsInIdToken = true;
            Client.AllowedScopes.Add("openid");
            Client.AllowedScopes.Add("profile");
            ConfigureDefaultUrls();

        }

        private void ConfigureWebHybrid()
        {
            Client.AllowedGrantTypes.Add(GrantType.Hybrid);
            Client.AllowedScopes.Add("openid");
            Client.AllowedScopes.Add("profile");
            ConfigureDefaultUrls();

        }

        private void ConfigureNative()
        {
            Client.AllowedGrantTypes.Add(GrantType.Hybrid);
            Client.AllowedScopes.Add("openid");
            Client.AllowedScopes.Add("profile");
        }

        private void ConfigureMachine()
        {
            Client.AllowedGrantTypes.Add(GrantType.ClientCredentials);
            Client.AllowedScopes.Add("openid");
            Client.RequireConsent = false;
            Client.RequireClientSecret = true;
        }
    }
}