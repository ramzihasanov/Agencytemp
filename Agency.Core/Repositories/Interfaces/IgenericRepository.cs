﻿using Agency.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseIdentity, new()
    {
        public DbSet<TEntity> Table { get; }

        Task CreateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);

        Task<int> CommitAsync();
    }
}
