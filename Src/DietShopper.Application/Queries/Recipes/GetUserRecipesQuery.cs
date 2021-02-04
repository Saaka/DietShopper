using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Queries.Recipes.Models;
using DietShopper.Application.Repositories;
using DietShopper.Application.Repositories.Models;
using DietShopper.Common.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Queries.Recipes
{
    public class GetUserRecipesQuery : Request<PagedList<SimpleRecipeQueryResultDto>>, IRequestWithBasicAuthorization
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class GetUserRecipesQueryHandler : RequestHandler<GetUserRecipesQuery, PagedList<SimpleRecipeQueryResultDto>>
    {
        private readonly IRecipesRepository _recipesRepository;

        public GetUserRecipesQueryHandler(IRecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        public override async Task<RequestResult<PagedList<SimpleRecipeQueryResultDto>>> Handle(GetUserRecipesQuery request, CancellationToken cancellationToken)
        {
            var result = await _recipesRepository.GetUserRecipes(new GetUserRecipesQueryDto
            {
                UserId = request.Context.User.UserId,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            });

            return request.Success(result);
        }
    }
}