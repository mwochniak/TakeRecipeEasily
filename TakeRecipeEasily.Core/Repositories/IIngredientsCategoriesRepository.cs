﻿using System;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Abstractions;
using TakeRecipeEasily.Core.Domain;

namespace TakeRecipeEasily.Core.Repositories
{
    public interface IIngredientsCategoriesRepository : IRepositorable
    {
        Task AddAsync(IngredientCategory ingredientCategory);

        Task<bool> IsNameInUse(string name);

        Task<IngredientCategory> GetIngredientCategoryAsync(Guid id);
    }
}