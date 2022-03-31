﻿namespace LetsCook.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using LetsCook.Services.Recipes;
    using LetsCook.Models.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoryService categories;
        private readonly ICuisineService cuisines;
        private readonly IDifficultyService difficulties;

        public RecipesController(ICategoryService categories, ICuisineService cuisines, IDifficultyService difficulties)
        {
            this.categories = categories;
            this.cuisines = cuisines;
            this.difficulties = difficulties;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            var recipe = new CreateRecipeFormModel
            {
                Categories = this.categories.GetAllCategories(),
                Cuisines = this.cuisines.GetAllCuisines(),
                Difficulties = this.difficulties.GetAllDifficulties(),
            };

            return this.View(recipe);
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeFormModel recipe)
        {
            if (!ModelState.IsValid)
            {
                recipe.Categories = this.categories.GetAllCategories();
                recipe.Cuisines = this.cuisines.GetAllCuisines();
                recipe.Difficulties = this.difficulties.GetAllDifficulties();

                return this.View(recipe);
            }


            return Json(recipe);
        }
    }
}
