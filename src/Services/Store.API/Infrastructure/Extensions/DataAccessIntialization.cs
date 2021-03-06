﻿using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Store.API.Infrastructure.DataAccess;

namespace Store.API.Infrastructure.Extensions
{
    public static class DataAccessIntialization
    {
        public static IServiceCollection DataAccessInitialization(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(
                  connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                        sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30),
                            null);
                    });

                // Changing default behavior when client evaluation occurs to throw. 
                // Default in EF Core would be to log a warning when client evaluation is performed.
                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                //Check Client vs. Server evaluation: https://docs.microsoft.com/en-us/ef/core/querying/client-eval
            });

            return services;
        }
    }
}
