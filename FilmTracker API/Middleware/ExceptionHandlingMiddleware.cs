using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Common.Exceptions;

namespace FilmTrackerAPI.Application.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next)
    {

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                var validationErrors = ex.Message;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(validationErrors));
            }
            catch (NotFoundException ex) 
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;  
                context.Response.ContentType = "application/json";
                var notFoundResponse = new ErrorResponse
                {
                    Message = "The requested resource was not found.",
                    Details = ex.Message  
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(notFoundResponse));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var errorResponse = new ErrorResponse
                {
                    Message = "An error occurred.",
                    Details = ex.Message
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }
    }
}
