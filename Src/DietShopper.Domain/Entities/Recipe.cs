using System;
using System.Collections.Generic;
using System.Linq;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class Recipe
    {
        public int RecipeId { get; private set; }
        public Guid RecipeGuid { get; private set; }
        public int OwnerId { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; set; }

        public virtual User Owner { get; private set; }

        private readonly List<Ingredient> _ingredients = new List<Ingredient>();
        public virtual IReadOnlyCollection<Ingredient> Ingredients => _ingredients.AsReadOnly();

        public Recipe(Guid recipeGuid, int ownerId, string name, string description)
        {
            RecipeGuid = recipeGuid;
            OwnerId = ownerId;
            Name = name;
            Description = description;
            IsActive = true;

            ValidateCreation();
        }

        public Recipe AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
                throw new DomainException(ErrorCode.IngredientRequired);
            if (!ingredient.IngredientId.Equals(default) && _ingredients.Any(x => x.IngredientId == ingredient.IngredientId))
                return this;
            if (_ingredients.Where(x => x.IsActive).Any(x => x.ProductId == ingredient.ProductId))
                throw new DomainException(ErrorCode.IngredientAlreadyAddedToRecipe);

            _ingredients.Add(ingredient);
            return this;
        }

        public Recipe SetName(string name)
        {
            ValidateName(name);
            Name = name;

            return this;
        }

        public Recipe SetDescription(string desc)
        {
            ValidateDescription(desc);
            Description = desc;

            return this;
        }

        public Recipe Deactivate()
        {
            IsActive = false;
            return this;
        }

        private void ValidateCreation()
        {
            if (RecipeGuid.Equals(Guid.Empty))
                throw new DomainException(ErrorCode.RecipeGuidRequired);

            ValidateOwner();
            ValidateName(Name);
            ValidateDescription(Description);
        }

        private void ValidateOwner()
        {
            if (OwnerId <= 0)
                throw new DomainException(ErrorCode.RecipeOwnerRequired);
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ErrorCode.RecipeNameRequired);
            if (name.Length > RecipeValidationConstant.RecipeNameMaxLength)
                throw new DomainException(ErrorCode.RecipeNameTooLong);
        }

        private void ValidateDescription(string description)
        {
            if (description.Length > RecipeValidationConstant.RecipeDescMaxLength)
                throw new DomainException(ErrorCode.RecipeDescriptionTooLong);
        }
    }
}