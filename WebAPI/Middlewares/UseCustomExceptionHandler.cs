using Business.Exceptions;
using Core.Dtos;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                //Run sonlandırıcı middleware
                //request burdan sonra controller lara gitmez response döner
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    //uygulamada fıratılan hatalar alınır
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => StatusCodes.Status400BadRequest,
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    context.Response.StatusCode = statusCode;

                    var response = RestResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
