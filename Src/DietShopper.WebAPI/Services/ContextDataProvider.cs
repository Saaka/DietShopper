using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DietShopper.Application.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests.Models;
using DietShopper.Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace DietShopper.WebAPI.Services
{
    public interface IContextDataProvider
    {
        Task<RequestContext> GetRequestContext(HttpContext context);
    }
    public class ContextDataProvider : IContextDataProvider
    {
        private const string UserIdCacheEntryPrefix = "_cdp_uid_";
        private readonly IUsersRepository _usersRepository;
        private readonly ICacheStore _cacheStore;

        public ContextDataProvider(IUsersRepository usersRepository,
            ICacheStore cacheStore)
        {
            _usersRepository = usersRepository;
            _cacheStore = cacheStore;
        }

        public async Task<RequestContext> GetRequestContext(HttpContext context)
        {
            var requestContext = new RequestContext();
            if (HasUserContext(context))
                return requestContext.WithUser(await GetAuthorizedUser(context));

            return requestContext;
        }

        private async Task<AuthorizedUser> GetAuthorizedUser(HttpContext context)
        {
            var userGuid = GetUserGuidFromContext(context);
            var userId = await GetUser(userGuid);
            var isAdmin = IsAdmin(context);

            return new AuthorizedUser
            {
                UserGuid = userGuid,
                UserId = userId,
                IsAdmin = isAdmin
            };
        }

        private Task<int> GetUser(Guid userGuid)
        {
            return _cacheStore.GetOrCreateAsync($"{UserIdCacheEntryPrefix}{userGuid}",
                () => _usersRepository.GetUserIdByGuid(userGuid));
        }

        private Guid GetUserGuidFromContext(HttpContext context)
        {
            var guid = context.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return new Guid(guid);
        }

        private bool IsAdmin(HttpContext context)
        {
            return context.User.IsInRole(UserRoles.Admin);
        }

        private bool HasUserContext(HttpContext context)
            => context.User?.Claims != null && context.User.HasClaim(x => x.Type == ClaimTypes.NameIdentifier);
    }
}