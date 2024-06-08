using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDo.Domain.Entities.Categories;
using HappyDo.Domain.Entities.Finance.Transaction;
using HappyDo.Domain.Entities.UserScope;

namespace HappyDo.Domain.Entities.Finance
{
    public class Income : TransactionList
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Category Category { get; set; }

        public Income(Category category)
        {
            Category = category;
        }
    }

}
