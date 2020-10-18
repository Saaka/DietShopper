using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace DietShopper.WebAPI.Services
{
    public class ContextDataProvider
    {

        private Guid GetUserGuidFromContext(HttpContext context)
        {
            var guid = context.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return new Guid(guid);
        }
        
        private bool HasUserContext(HttpContext context)
            => context.User?.Claims != null && context.User.HasClaim(x => x.Type == ClaimTypes.NameIdentifier);
    }
}