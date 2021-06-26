using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YSK.UdemyJwtProje.WebApi.CustomFilters
{
    public class ValidModel: ActionFilterAttribute
    {
        //modelState 'in valid olup olmam işlemini burada gerçekleştiriyoruz.
        public override void OnActionExecuting(ActionExecutingContext context)//çalışmadan önce tetiklenen metod.
        {

            if(!!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);//400
            }
           
        }
    }
}
