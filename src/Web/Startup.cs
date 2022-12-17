using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Services;
using NSwag;
using NSwag.Generation.Processors.Security;
using FluentValidation.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class Startup
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddFluentValidationAutoValidation();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        return services;
    }
}
