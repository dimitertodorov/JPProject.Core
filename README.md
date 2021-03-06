![image](https://github.com/brunohbrito/JPProject.Core/blob/master/build/logo.png?raw=true)

![Nuget](https://img.shields.io/nuget/v/JPProject.Sso.Domain)
[![Build Status](https://dev.azure.com/brunohbrito/Jp%20Project/_apis/build/status/JPProject%20-%20Core?branchName=master)](https://dev.azure.com/brunohbrito/Jp%20Project/_build/latest?definitionId=12&branchName=master)
[![License](https://img.shields.io/github/license/brunohbrito/JPProject.IdentityServer4.SSO)](LICENSE)

Jp Project is a Open Source SSO and AdminUI Tools for OAuth2 and Authentication. Built within IdentityServer4 and ASP.NET Identity. 

## Table of Contents ##

- [Presentation](#presentation)
- [How to start?](#how-to-start)
- [This Repository](#this-repository)
  - [Technologies](#technologies)
  - [Architecture](#architecture)
  - [Give a Star! ⭐](#give-a-star-%e2%ad%90)
  - [Docs](#docs)
  - [Contributing](#contributing)
  - [Free](#free)
  - [v3.0.0](#v300)
- [License](#license)

# Presentation

JP Project is an OAuth2 and Identity tools. Built with IdentityServer4. An OpenID Connect and OAuth 2.0 framework for ASP.NET Core.

SSO has some flows:
* Register users
* Recover password flow
* MFA
* Federation Gateway (Login by Google, Facebook.. etc)

Admin UI is an administrative panel where it's possible to manage both OAuth2 Server and Identities. 
From OAuth2 panel it's possible to manage Clients, Identity Resources, Api Resources. 
From Identity panel it's possible to manage Users and Roles

It's open source and free. From community to community.

# How to start?

First you need to choose.

* You need everything? Best choice, JP Project provide a complete SSO with an Administration panel. Check it at [SSO - Full Version](https://github.com/brunohbrito/JPProject.IdentityServer4.SSO)

* You already have a IdentityServer4 Up and running? Go to [Admin Panel - Light version](https://github.com/brunohbrito/JPProject.IdentityServer4.AdminUI)

# This Repository

This repository is the base classes that support both SSO and AdminUI repositories

## Technologies #

Check below how it was developed.

Written in ASP.NET Core and Angular 8.
The main goal of project is to be a Management Ecosystem for IdentityServer4. Helping Startup's and Organization to Speed Up the Setup of User Management. Helping teams and entrepreneurs to achieve the company's primary purpose: Maximize shareholder value.

- IdentityServer4
- ASP.NET Identity Core
- Argon2 Password Hashing
- MySql Ready
- Sql Ready
- Postgree Ready
- SQLite Ready
- Entity Framework Core
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR

## Architecture

- Architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository and Generic Repository

## Give a Star! ⭐

Do you love it? give us a Star!

## Docs

Wanna start? please [Read the docs](https://jp-project.readthedocs.io/en/latest/index.html)

## Contributing

We'll love it! Please [Read the docs](https://jp-project.readthedocs.io/en/latest/index.html)

## Free

If you need help building or running your Jp Project platform
There are several ways we can help you out.

## v3.0.0

Version will be attached to .NET Core version. The project was separated in 3 differents git repo.

# License

Jp Project is Open Source software and is released under the MIT license. This license allow the use of Jp Project in free and commercial applications and libraries without restrictions.
