using System;
using System.Linq;
using System.Net;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;
using DietShopper.Shared.Exceptions;
using DietShopper.WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace DietShopper.WebAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _env;

        public CustomExceptionFilterAttribute(IWebHostEnvironment env)
        {
            _env = env;
        }

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.HttpContext.Response.ContentType = "application/json";

            if (exception is DomainException domainException)
                HandleDomainException(context, domainException);
            if (exception is CommandValidationException validationException)
                HandleValidationException(context, validationException);
            if (exception is InternalException internalException)
                HandleInternalException(context, internalException);
            else
                HandleApplicationExceptions(context, exception);
        }

        private void HandleDomainException(ExceptionContext context, DomainException exception)
        {
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Result = new JsonResult(new
            {
                Error = exception.ErrorCode.ToString(),
                ErrorDetails = exception.Message,
                Trace = GetTrace(context)
            });
        }

        private void HandleInternalException(ExceptionContext context, InternalException exception)
        {
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new
            {
                Error = nameof(InternalException),
                Code = (int)exception.ErrorCode,
                ErrorDetails = exception.Message,
                Trace = GetTrace(context)
            });
        }

        private void HandleValidationException(ExceptionContext context, CommandValidationException validationException)
        {
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Result = new JsonResult(new ErrorResponse(
                code: ErrorCode.ValidationError,
                details: validationException.Failures
                    .Select(f => new {field = f.Key, errors = f.Value}))
            );
        }

        private void HandleApplicationExceptions(ExceptionContext context, Exception exception)
        {
            var code = exception switch
            {
                ArgumentException _ => HttpStatusCode.BadRequest,
                InvalidOperationException _ => HttpStatusCode.Forbidden,
                UnauthorizedAccessException _ => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError
            };

            context.HttpContext.Response.StatusCode = (int) code;
            context.Result = new JsonResult(new
            {
                Error = context.Exception.Message,
                Trace = GetTrace(context)
            });
        }

        private string GetTrace(ExceptionContext context)
            => !_env.IsProduction() ? context.Exception.StackTrace : string.Empty;
    }
}