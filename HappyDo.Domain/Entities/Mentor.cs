using HappyDo.Domain.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities
{
    public class Mentor : User
    {
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual Bonus Bonus { get; set; } 
        public virtual Leisure Leisure { get; set; } 
        public virtual Savings Savings { get; set; }
    }

}
