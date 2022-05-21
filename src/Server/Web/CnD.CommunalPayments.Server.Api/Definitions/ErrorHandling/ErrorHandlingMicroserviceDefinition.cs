﻿using CnD.CommunalPayments.Server.Api.Definitions.Base;
using Microsoft.AspNetCore.Diagnostics;
using NLog.Fluent;
using System.Text.Json;

namespace CnD.CommunalPayments.Server.Api.Definitions.ErrorHandling;

/// <summary>
/// Custom Error handling 
/// </summary>
public class ErrorHandlingMicroserviceDefinition : AppDefinitions
{
    /// <summary> 
    /// Configure application for current microservice
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public override void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env) =>
        app.UseExceptionHandler(error => error.Run(async context =>
        {
            context.Response.ContentType = "application/json";
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature is not null)
            {
                // handling validation errors
                //if (contextFeature.Error is ValidationException failures)
                //{
                //    await context.Response.WriteAsync(JsonSerializer.Serialize(failures.Errors));
                //    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                //    return;
                //}

                // handling all another errors 
                Log.Error($"Something went wrong in the {contextFeature.Error}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                if (env.IsDevelopment())
                {
                    await context.Response.WriteAsync($"INTERNAL SERVER ERROR: {contextFeature.Error}");
                }
                else
                {
                    await context.Response.WriteAsync("INTERNAL SERVER ERROR. PLEASE TRY AGAIN LATER");
                }
            }
        }));
}
