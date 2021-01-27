using System;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.ProductCategories
{
    public class RemoveProductCategoryCommand : Request, IRequestWithAdminAuthorization
    {
        public Guid ProductCategoryGuid { get; set; }
    }
}