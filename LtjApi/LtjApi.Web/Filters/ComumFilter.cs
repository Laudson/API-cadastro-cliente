using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LtjApi.Web.Filters
{
    public class ComumFilter : Microsoft.AspNetCore.Mvc.Filters.IActionFilter, Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Dominio.Contexto.Encerrar(context.ExceptionHandled);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Dominio.Contexto.Inicializar(1, 1);
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new { Erro = true, MensagemErro = context.Exception.Message });
        }
    }
}