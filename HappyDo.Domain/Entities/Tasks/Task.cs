using HappyDo.Domain.Entities.Categories;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyDo.Domain.Entities.Tasks
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsRoutine { get; set; } 
        public decimal Percentage { get; set; } 
        public decimal Value { get; set; } 
        public Category Category { get; set; }
        // Relacionamento
        public int UserId { get; set; } 
        public virtual User User { get; set; } 
    }

}
