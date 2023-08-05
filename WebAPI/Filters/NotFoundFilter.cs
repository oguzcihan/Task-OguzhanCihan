using Core.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Business.Abstracts;

namespace WebAPI.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : AbsBaseEntity
    {
        //Eğer bir actionfilter a constructor üzerinden parametre geçiliyorsa bunu kullanırken [ServiceFilter] üzerinden kullanılmalı
        //aynı zamanda bu filter program.cs DI container a eklenmeli.
        private readonly IBaseService<T> _baseService;

        public NotFoundFilter(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //filter a takılmasını istemiyorsak next deyip yoluna devam eder.

            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
            }
            var id = (int)idValue;
            var anyEntity = await _baseService.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result =
                new NotFoundObjectResult(RestResponseDto<NoContentDto>.Fail(StatusCodes.Status404NotFound,
                    $"{typeof(T).Name}({id}) not found!"));
        }
    }
}
