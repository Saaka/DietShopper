using System;
using System.Collections.Generic;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; private set; }
        public Guid ProductCategoryGuid { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<Product> _products = new List<Product>();
        public virtual IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        private ProductCategory() { }

        public ProductCategory(Guid productCategoryGuid, string name)
        {
            ProductCategoryGuid = productCategoryGuid;
            Name = name;
            IsActive = true;

            ValidateCreation();
        }

        public ProductCategory Deactivate()
        {
            IsActive = false;
            return this;
        }

        public ProductCategory SetName(string name)
        {
            ValidateName(name);
            Name = name;
            
            return this;
        }

        public ProductCategory AddProduct(Product product)
        {
            if (product == null)
                throw new InternalException(ErrorCode.ProductInCategoryRequired);
            
            _products.Add(product);

            return this;
        }

        private void ValidateCreation()
        {
            if(ProductCategoryGuid.Equals(Guid.Empty))
                throw new InternalException(ErrorCode.ProductCategoryGuidRequired);
            
            ValidateName(Name);
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ErrorCode.ProductCategoryNameRequired);
            if (name.Length > ProductCategoryValidationConstants.ProductCategoryNameMaxLength)
                throw new DomainException(ErrorCode.ProductCategoryNameTooLong);
        }
    }
}