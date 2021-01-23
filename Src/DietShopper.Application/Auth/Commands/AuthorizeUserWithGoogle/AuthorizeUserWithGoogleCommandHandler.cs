using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Auth.Models;
using DietShopper.Application.Auth.Services;
using DietShopper.Application.Repositories;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Auth.Commands.AuthorizeUserWithGoogle
{
    public class AuthorizeUserWithGoogleCommandHandler : RequestHandler<AuthorizeUserWithGoogleCommand, AuthorizationData>
    {
        private readonly IGoogleAuthorizationClient _googleAuthorizationClient;
        private readonly IUsersRepository _usersRepository;

        public AuthorizeUserWithGoogleCommandHandler(IGoogleAuthorizationClient googleAuthorizationClient, IUsersRepository usersRepository)
        {
            _googleAuthorizationClient = googleAuthorizationClient;
            _usersRepository = usersRepository;
        }

        public override async Task<RequestResult<AuthorizationData>> Handle(
            AuthorizeUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var authData = await _googleAuthorizationClient.AuthorizeWithGoogleToken(request.GoogleToken);
            var user = await _usersRepository.GetByGuid(authData.User.UserGuid);
            user = user == null ? authData.User.ToEntity() : authData.User.UpdateEntity(user);
            await _usersRepository.Upsert(user);

            return request.Success(authData);
        }
    }
}