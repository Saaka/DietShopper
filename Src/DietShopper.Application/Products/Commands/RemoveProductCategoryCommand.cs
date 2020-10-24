using System;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands
{
    public class RemoveProductCategoryCommand : Request
    {
        public Guid ProductCategoryGuid { get; set; }
    }
}