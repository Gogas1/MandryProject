﻿using AirBnbClone.Models.Inheritance;

namespace AirBnbClone.Models.DB
{
    public class Category : Translatable
    {
        public string NameKey { get; set; } = string.Empty;
        public bool IsCategoryPropertyRequired { get; set; }
        public string CategoryPropertyDescriptionKey { get; set; } = string.Empty;
        public CategoryDescriptionProperty? CategoryPropertyTranslations { get; set; }
    }
}
