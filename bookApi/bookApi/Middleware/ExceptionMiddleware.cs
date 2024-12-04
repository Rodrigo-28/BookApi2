using bookApi.Application.Exceptions;
using bookApi.Models;
using System.Net;

namespace bookApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            switch (exception)
            {
                case BadRequestException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case NotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedException e:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ForbiddenException e:
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            ErrorResponse errorResponse;

            try
            {
                errorResponse = new ErrorResponse
                {
                    ErrorCode = (exception is CustomException customEx) ? customEx.ErrorCode : null,
                    HttpStatusCode = context.Response.StatusCode,
                    Error = exception.Message,
                    Exception = exception.GetType().Name
                };
            }
            catch
            {
                errorResponse = new ErrorResponse()
                {
                    HttpStatusCode = context.Response.StatusCode,
                    Error = exception.Message,
                    Exception = exception.GetType().Name
                };
            }

            return context.Response.WriteAsync(errorResponse.ToString());
        }
    }
}
