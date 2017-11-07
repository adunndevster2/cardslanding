using System;
using System.Web;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
//using System.Net.Http.Headers;


namespace cardslanding.Infrustructure
{
    public class ApiAllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        
        public const string OriginHeader = "Origin";
        #if DEBUG
            // localhost allowed in debug (local) builds.
            private readonly string[] allowedOrigins = { "azurewebsites.net", "localhost" };
        #else
            private readonly string[] allowedOrigins = { "azurewebsites.net" };
        #endif
        //private readonly ILogger _logger;


        public ApiAllowCrossSiteJsonAttribute()
        {
            //_logger = loggerFactory.CreateLogger("ClassConsoleLogActionOneFilter");
        }
 
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
            var request = context.HttpContext.Request;

            // Get the origin of this request. We look for an explicit Origin header value first
            // It's required on all CORS requests according to spec.
            var origin = GetOriginFromHeaderValue(request.Headers[OriginHeader]);

            // If that's missing, we'll pickup the Referrer header value.
            if (string.IsNullOrEmpty(origin))
                origin = "";
                //origin = request.Headers["UrlReferrer"].ToString() != null ? request.Headers["UrlReferrer"].ToString().GetLeftPart(UriPartial.Authority) : "";

            if (context.HttpContext.Response != null)
            {
                if (allowedOrigins.Any(oo => origin.Contains(oo)))
                {
                    AddCorsHeaders(context.HttpContext.Response.Headers, origin);
                }
            }
            

            // _logger.LogWarning("ClassFilter OnActionExecuted");
            // base.OnActionExecuted(context);
        }


        /// <summary>
        /// Retrieve the host portion of the Origin
        /// </summary>
        /// <param name="originHeader">Origin value from header</param>
        /// <returns></returns>
        internal static string GetOriginFromHeaderValue(string originHeader)
        {
            if (originHeader != null)
            {
                try
                {
                    return new Uri(originHeader).GetLeftPart(UriPartial.Authority);
                }
                catch
                {
                    // Bad or empty origin?
                }
            }

            return null;
        }

        /// <summary>
        /// Add the CORS responses to the headers.
        /// </summary>
        /// <param name="headerCollection">Header collection</param>
        /// <param name="origin">Origin value</param>
        internal static void AddCorsHeaders(IHeaderDictionary headerCollection, string origin)
        {
            if (string.IsNullOrEmpty(origin))
                origin = "*";

            headerCollection.Add("Access-Control-Allow-Origin", origin);
            headerCollection.Add("Access-Control-Allow-Credentials", "true");
            headerCollection.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            headerCollection.Add("Access-Control-Allow-Headers", "X-Requested-With, Content-Type, API-Version");
        }
 
    }
}