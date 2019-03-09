﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakeRecipeEasily.Infrastructure.SQL;

namespace TakeRecipeEasily.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("IngredientCategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("IngredientCategoryId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.IngredientCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IngredientsCategories");
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("DifficultyLevel");

                    b.Property<string>("Name");

                    b.Property<int>("PreparationTime");

                    b.Property<string>("Summary");

                    b.Property<int?>("TotalKcal");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.RecipeImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType");

                    b.Property<bool>("IsDefault");

                    b.Property<Guid>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipesImages");
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.RecipeIngredient", b =>
                {
                    b.Property<Guid>("RecipeId");

                    b.Property<Guid>("IngredientId");

                    b.Property<double>("Quantity");

                    b.Property<int>("Unit");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("RecipesIngredients");
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.RecipeRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int>("Rate");

                    b.Property<Guid>("RecipeId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("RecipesRatings");
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HashedPassword");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.Ingredient", b =>
                {
                    b.HasOne("TakeRecipeEasily.Core.Domain.IngredientCategory", "IngredientCategory")
                        .WithMany("Ingredients")
                        .HasForeignKey("IngredientCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.Recipe", b =>
                {
                    b.HasOne("TakeRecipeEasily.Core.Domain.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.RecipeImage", b =>
                {
                    b.HasOne("TakeRecipeEasily.Core.Domain.Recipe", "Recipe")
                        .WithMany("RecipeImages")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.RecipeIngredient", b =>
                {
                    b.HasOne("TakeRecipeEasily.Core.Domain.Ingredient", "Ingredient")
                        .WithMany("RecipesIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TakeRecipeEasily.Core.Domain.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TakeRecipeEasily.Core.Domain.RecipeRating", b =>
                {
                    b.HasOne("TakeRecipeEasily.Core.Domain.Recipe", "Recipe")
                        .WithMany("RecipeRatings")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TakeRecipeEasily.Core.Domain.User", "User")
                        .WithMany("RecipesRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
