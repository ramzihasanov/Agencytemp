using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Models
{
    public class PortfolioImage:BaseIdentity
    {
        public int PortfolioId { get; set; }
        public Portfolio? book { get; set; }
        public string ImageUrl { get; set; }
    }
}
