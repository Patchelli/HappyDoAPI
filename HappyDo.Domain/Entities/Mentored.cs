using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities
{
    public class Mentored : User
    {
        public decimal AccumulatedValue { get; set; }
    }
}
