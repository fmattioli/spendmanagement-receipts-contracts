﻿namespace Web.Contracts.Category
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
