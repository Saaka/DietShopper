using System;
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

        public virtual User Owner { get; private set; }

        public Recipe(Guid recipeGuid, int ownerId, string name, string description)
        {
            RecipeGuid = recipeGuid;
            OwnerId = ownerId;
            Name = name;
            Description = description;

            ValidateCreation();
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
                throw new DomainException(ErrorCode.RecipeNameTooLong);
        }
    }
}