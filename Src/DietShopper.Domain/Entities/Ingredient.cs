using System;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; private set; }
        public Guid IngredientGuid { get; private set; }
        public int RecipeId { get; private set; }
        public int ProductId { get; private set; }
        public int MeasureId { get; private set; }
        public decimal Amount { get; private set; }
        public decimal AmountInGrams { get; private set; }
        public string Note { get; private set; }
        public bool IsActive { get; private set; }

        public virtual Recipe Recipe { get; private set; }
        public virtual Product Product { get; private set; }
        public virtual Measure Measure { get; private set; }

        public Ingredient(Guid ingredientGuid, int productId, int measureId, decimal amount, decimal amountInGrams, string note)
        {
            IngredientGuid = ingredientGuid;
            ProductId = productId;
            MeasureId = measureId;
            Amount = amount;
            AmountInGrams = amountInGrams;
            Note = note;
            IsActive = true;

            ValidateCreation();
        }

        public Ingredient SetAmount(decimal amount, decimal amountInGrams)
        {
            ValidateAmount(amount, amountInGrams);
            Amount = amount;
            AmountInGrams = amountInGrams;

            return this;
        }

        public Ingredient SetNote(string note)
        {
            ValidateNote(note);
            Note = note;
            
            return this;
        }

        private void ValidateCreation()
        {
            if (IngredientGuid.Equals(Guid.Empty))
                throw new DomainException(ErrorCode.IngredientGuidRequired);
            if (ProductId.Equals(default))
                throw new DomainException(ErrorCode.ProductRequired);
            if (MeasureId.Equals(default))
                throw new DomainException(ErrorCode.MeasureRequired);

            ValidateAmount(Amount, AmountInGrams);
            ValidateNote(Note);
        }

        private void ValidateNote(string note)
        {
            if (note.Length >= IngredientValidationConstants.NoteMaxLength)
                throw new DomainException(ErrorCode.IngredientNoteTooLong);
        }

        private void ValidateAmount(decimal amount, decimal amountInGrams)
        {
            if (amount <= 0)
                throw new DomainException(ErrorCode.InvalidProductAmount);
            if (amountInGrams <= 0)
                throw new DomainException(ErrorCode.InvalidProductAmountInGrams);
        }

        public Ingredient Deactivate()
        {
            IsActive = false;
            return this;
        }
    }
}