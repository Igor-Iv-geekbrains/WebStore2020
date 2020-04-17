using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore2020.Infrastructure
{
    public class TokenMiddleware
    {
        private const string correctToken = "1235";
        public RequestDelegate Next { get; }

        public TokenMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public async Task IncokeAsync(HttpContext context)
        {
            var token = context.Request.Query["referenceToken"];
            if (string.IsNullOrEmpty(token))
            {
                await Next.Invoke(context);
                return;
            }
            if (token == correctToken)
            {
                //work with token
                await Next.Invoke(context);
            }
            else
            {
                await context.Response.WriteAsync("Token is incorrect");
            }
        }


    }
}
