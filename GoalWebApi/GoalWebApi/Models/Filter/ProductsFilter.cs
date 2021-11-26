using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Models.Filter
{
    public class ProductsFilter
    {
        public Guid CategoryId { get; set; }

        //public bool HasFilter() => CategoryId  ;
    }
}
