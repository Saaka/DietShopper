using System.Linq;
using System.Threading.Tasks;
using DietShopper.Application.Queries.Recipes.Models;
using DietShopper.Application.Repositories;
using DietShopper.Application.Repositories.Models;
using DietShopper.Common.Models;
using DietShopper.Domain.Entities;
using DietShopper.Persistence.Utils;

namespace DietShopper.Persistence.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly AppDbContext _context;
        private readonly IPageableRequestHelper _pageableRequestHelper;

        public RecipesRepository(AppDbContext context, IPageableRequestHelper pageableRequestHelper)
        {
            _context = context;
            _pageableRequestHelper = pageableRequestHelper;
        }
        
        public Task Save(Recipe recipe)
        {
            _context.Attach(recipe);
            return _context.SaveChangesAsync();
        }

        public Task<PagedList<SimpleRecipeQueryResultDto>> GetUserRecipes(GetUserRecipesQueryDto request)
        {
            var query = from recipe in _context.Recipes
                where recipe.OwnerId == request.UserId
                select new SimpleRecipeQueryResultDto
                {
                    RecipeGuid = recipe.RecipeGuid,
                    Name = recipe.Name
                };

            query = query.OrderBy(x => x.Name);

            return _pageableRequestHelper.GetPagedListAsync(query, request);
        }
    }
}