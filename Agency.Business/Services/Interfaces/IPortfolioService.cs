﻿using Agency.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Interfaces
{
    public interface IPortfolioService
    {
        Task CreateAsync(Portfolio portfolio);
        Task Delete(int id);
        Task<Portfolio> GetByIdAsync(int id);
        Task<List<Portfolio>> GetAllAsync(Expression<Func<Portfolio, bool>>? expression = null);
        Task UpdateAsync(Portfolio portfolio);
    }
}
