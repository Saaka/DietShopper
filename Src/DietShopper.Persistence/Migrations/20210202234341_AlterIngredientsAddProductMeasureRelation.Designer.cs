﻿// <auto-generated />
using System;
using DietShopper.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DietShopper.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210202234341_AlterIngredientsAddProductMeasureRelation")]
    partial class AlterIngredientsAddProductMeasureRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dietshopper")
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DietShopper.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountInGrams")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("IngredientGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductMeasureId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("IngredientGuid")
                        .IsUnique()
                        .HasName("IX_Ingredients_IngredientGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "IngredientId" });

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductMeasureId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.Measure", b =>
                {
                    b.Property<int>("MeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBaseline")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWeight")
                        .HasColumnType("bit");

                    b.Property<Guid>("MeasureGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<decimal?>("ValueInGrams")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MeasureId");

                    b.HasIndex("MeasureGuid")
                        .IsUnique()
                        .HasName("IX_Measures_MeasureGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "MeasureId" });

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DefaultMeasureId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.HasKey("ProductId");

                    b.HasIndex("DefaultMeasureId");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductGuid")
                        .IsUnique()
                        .HasName("IX_Products_ProductGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "ProductId" });

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<Guid>("ProductCategoryGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductCategoryId");

                    b.HasIndex("ProductCategoryGuid")
                        .IsUnique()
                        .HasName("IX_ProductCategories_ProductCategoryGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "ProductCategoryId" });

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.ProductMeasure", b =>
                {
                    b.Property<int>("ProductMeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MeasureId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductMeasureGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValueInGrams")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductMeasureId");

                    b.HasIndex("MeasureId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductMeasureGuid")
                        .IsUnique()
                        .HasName("IX_ProductMeasures_ProductMeasureGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "ProductMeasureId" });

                    b.ToTable("ProductMeasures");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.ProductNutrients", b =>
                {
                    b.Property<int>("ProductNutrientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductNutrientsGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Proteins")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaturatedFat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductNutrientsId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("ProductNutrientsGuid")
                        .IsUnique()
                        .HasName("IX_ProductNutrients_ProductNutrientsGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "ProductNutrientsId" });

                    b.ToTable("ProductNutrients");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<Guid>("RecipeGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RecipeGuid")
                        .IsUnique()
                        .HasName("IX_Recipes_RecipeGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "RecipeId" });

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256)
                        .HasDefaultValue("");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("UserGuid")
                        .IsUnique()
                        .HasName("IX_Users_UserGuid")
                        .HasAnnotation("SqlServer:Include", new[] { "UserId" });

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("DietShopper.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DietShopper.Domain.Entities.ProductMeasure", "ProductMeasure")
                        .WithMany()
                        .HasForeignKey("ProductMeasureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DietShopper.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.Product", b =>
                {
                    b.HasOne("DietShopper.Domain.Entities.Measure", "DefaultMeasure")
                        .WithMany()
                        .HasForeignKey("DefaultMeasureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DietShopper.Domain.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.ProductMeasure", b =>
                {
                    b.HasOne("DietShopper.Domain.Entities.Measure", "Measure")
                        .WithMany()
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DietShopper.Domain.Entities.Product", null)
                        .WithMany("ProductMeasures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.ProductNutrients", b =>
                {
                    b.HasOne("DietShopper.Domain.Entities.Product", null)
                        .WithOne("ProductNutrients")
                        .HasForeignKey("DietShopper.Domain.Entities.ProductNutrients", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DietShopper.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("DietShopper.Domain.Entities.User", "Owner")
                        .WithMany("Recipes")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
