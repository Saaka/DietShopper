using AutoMapper;
using DietShopper.Application.Auth.Commands;

namespace DietShopper.WebAPI.Controllers.Auth.Models
{
    public class AuthMapperProfile : Profile
    {
        public AuthMapperProfile()
        {
            CreateMap<AuthorizeUserWithGoogleRequest, AuthorizeUserWithGoogleCommand>();
        }
    }
}