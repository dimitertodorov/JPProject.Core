﻿using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Notifications;
using JPProject.Sso.Domain.Interfaces;
using JPProject.Sso.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPProject.Sso.Infra.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private ILogger<UserService> _logger;
        private IMediatorHandler _bus;

        public RoleService(
            RoleManager<IdentityRole> roleManager,
            IMediatorHandler bus,
            ILoggerFactory loggerFactory)
        {
            _roleManager = roleManager;
            _bus = bus;
            _logger = loggerFactory.CreateLogger<UserService>(); ;

        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles.Select(s => new Role(s.Id, s.Name)).ToList();
        }

        public async Task<bool> Remove(string name)
        {
            var roleClaim = await _roleManager.Roles.Where(x => x.Name == name).SingleOrDefaultAsync();
            var result = await _roleManager.DeleteAsync(roleClaim);
            foreach (var error in result.Errors)
            {
                await _bus.RaiseEvent(new DomainNotification(result.ToString(), error.Description));
            }

            return result.Succeeded;
        }

        public async Task<Role> Details(string name)
        {
            var s = await _roleManager.Roles.FirstAsync(f => f.Name == name);
            return new Role(s.Id, s.Name);
        }

        public async Task<bool> Save(string name)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole() { Name = name });
            foreach (var error in result.Errors)
            {
                await _bus.RaiseEvent(new DomainNotification(result.ToString(), error.Description));
            }

            return result.Succeeded;
        }

        public async Task<bool> Update(string name, string oldName)
        {
            var s = await _roleManager.Roles.FirstAsync(f => f.Name == oldName);
            s.Name = name;
            var result = await _roleManager.UpdateAsync(s);
            foreach (var error in result.Errors)
            {
                await _bus.RaiseEvent(new DomainNotification(result.ToString(), error.Description));
            }

            return result.Succeeded;
        }


    }
}
