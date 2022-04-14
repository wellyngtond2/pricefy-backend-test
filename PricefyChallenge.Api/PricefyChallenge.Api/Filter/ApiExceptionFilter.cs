using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PricefyChallenge.Core.Shared.DataContracts;
using System;

namespace PricefyChallenge.Api.Filter
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ApiExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            Exception exception = context.Exception;

            _logger.LogError(exception, exception.Message);

            var response = OperationResult.Failure(exception.Message);

            context.Result = new JsonResult(response) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}