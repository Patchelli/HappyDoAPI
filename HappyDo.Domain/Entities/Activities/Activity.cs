using HappyDo.Domain.Entities.Categories;
using HappyDo.Domain.Entities.UserScope;
using System;
using System.ComponentModel.DataAnnotations;

namespace HappyDo.Domain.Entities.Activities
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsRoutine { get; set; }
        public decimal Percentage { get; set; }
        public decimal Value { get; set; }
        public Category Category { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
