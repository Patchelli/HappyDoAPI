using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDo.Domain.Entities.Categories;
using HappyDo.Domain.Entities.Finance.Transaction;

namespace HappyDo.Domain.Entities.Finance
{
    public class Income : TransactionList
    {
        public Category Category { get; set; }

        public Income(Category category)
        {
            Category = category;
        }
    }

}
