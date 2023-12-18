using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Models
{
    public class Portfolio:BaseIdentity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string  ImgUrl { get; set; }
        public Category categories { get; set; }
        public string? PortfolioId { get; set; }
        public PortfolioImage? portfolioimg { get; set; }
    }

}

