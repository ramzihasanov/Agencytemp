using Agency.Core.Models;
using Agency.Core.Repositories.Interfaces;
using Agency.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Data.Repositories
{
    public class PortfolioImageRepository : GenericRepository<PortfolioImage>, IPortfolioImageRepository
    {
        public PortfolioImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
