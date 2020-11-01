using System;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.ProductCategories
{
    public class RemoveProductCategoryCommand : Request
    {
        public Guid ProductCategoryGuid { get; }

        public RemoveProductCategoryCommand(Guid productCategoryGuid) => ProductCategoryGuid = productCategoryGuid;
    }
}