﻿using GLTest.Core.Domains.Categories;

namespace GLTest.Core.Domains.Products
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public Guid? CategoryId { get; private set; }
        public Category? Category { get; private set; }

        protected Product() { }

        protected Product Create(string name)
        {
            return new Product
            {
                ProductName = name
            };
        }

        public void SetCategory(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
