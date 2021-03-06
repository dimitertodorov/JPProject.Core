﻿using System;
using JPProject.Domain.Core.Commands;

namespace JPProject.Sso.Domain.Commands.UserManagement
{
    public abstract class UserManagementCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Name { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string ConfirmPassword { get; protected set; }
        public string Picture { get; protected set; }
        public string Provider { get; protected set; }
        public string ProviderId { get; protected set; }
        public bool EmailConfirmed { get; protected set; }
        public bool PhoneNumberConfirmed { get; protected set; }
        public bool TwoFactorEnabled { get; protected set; }
        public DateTimeOffset? LockoutEnd { get; protected set; }
        public bool LockoutEnabled { get; protected set; }
        public int AccessFailedCount { get; protected set; }
    }
}
