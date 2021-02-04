using System.Threading.Tasks;
using DietShopper.Application.Queries.Recipes.Models;
using DietShopper.Application.Repositories.Models;
using DietShopper.Common.Models;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IRecipesRepository
    {
        Task Save(Recipe recipe);
        Task<PagedList<SimpleRecipeQueryResultDto>> GetUserRecipes(GetUserRecipesQueryDto request);
    }
}