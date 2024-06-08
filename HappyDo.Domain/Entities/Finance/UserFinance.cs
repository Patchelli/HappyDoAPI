using HappyDo.Domain.Entities.Finance.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities.Finance
{
    public class UserFinance
    {
        public List<OneTimeTransaction> Expenses { get; set; }
        public List<OneTimeTransaction> Incomes { get; set; }

        public decimal TotalIncome
        {
            get
            {
                return Incomes.Sum(x => x.Amount);
            }
        }

        public decimal TotalExpense
        {
            get
            {
                return Expenses.Sum(x => x.Amount);
            }
        }

        public decimal Balance
        {
            get
            {
                return TotalIncome - TotalExpense;
            }
        }



        public UserFinance()
        {
            Expenses = new List<OneTimeTransaction>();
            Incomes = new List<OneTimeTransaction>();

        }
    }
}
