using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities.Categories
{
    public class Category
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Category(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

}
