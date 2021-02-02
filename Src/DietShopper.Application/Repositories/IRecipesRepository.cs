using System.Threading.Tasks;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Repositories
{
    public interface IRecipesRepository
    {
        Task Save(Recipe recipe);
    }
}