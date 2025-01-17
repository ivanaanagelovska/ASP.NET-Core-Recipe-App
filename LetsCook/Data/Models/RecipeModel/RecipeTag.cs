﻿namespace LetsCook.Data.Models.RecipeModel
{
    using Data.Common;

    public class RecipeTag : BaseModel<int>
    {
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
