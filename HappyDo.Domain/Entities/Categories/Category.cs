using System;
using System.ComponentModel.DataAnnotations;

namespace HappyDo.Domain.Entities.Categories
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Category(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
