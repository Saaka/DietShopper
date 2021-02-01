using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Models;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Recipes.CreateRecipe
{
    public class CreateRecipeCommandHandler : RequestHandler<CreateRecipeCommand, RecipeDto>
    {
        private readonly IGuid _guid;

        public CreateRecipeCommandHandler(IGuid guid)
        {
            _guid = guid;
        }
        
        public override async Task<RequestResult<RecipeDto>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}