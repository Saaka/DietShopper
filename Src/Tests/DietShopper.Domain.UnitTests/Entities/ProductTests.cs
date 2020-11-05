using System;
using DietShopper.Domain.Entities;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace DietShopper.Domain.UnitTests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Should_Have_Values_Set_With_Constructor()
        {
            var productGuid = Guid.NewGuid();
            var product = new Product(productGuid, "Tomato", "T", "This is a tomato", 1, 2);

            product.ProductGuid.Should().Be(productGuid);
            product.Name.Should().Be("Tomato");
            product.ShortName.Should().Be("T");
            product.Description.Should().Be("This is a tomato");
            product.ProductCategoryId.Should().Be(1);
            product.DefaultMeasureId.Should().Be(2);
        }
        
        [Fact]
        public void Should_Throw_For_Missing_Guid()
        {
            var productGuid = Guid.Empty;
            
            var exception = Assert.Throws<InternalException>(() => 
                new Product(productGuid, "Tomato", "T", "This is a tomato", 1, 2));

            exception.ErrorCode.Should().Be(ErrorCode.ProductGuidRequired);
        }
    }
}