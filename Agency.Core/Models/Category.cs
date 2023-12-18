using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Models
{
    public class Category : BaseIdentity
    {
        public string Name { get; set; }
        public List<Portfolio> Portfolio { get; set; }
        [NotMapped]
        public List<int>? portfolioInts { get; set; }

    }
}
