using BigonApp.Data.Contexts;
using BigonApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigonApp.Infrastructure.Repositories;
using BigonApp.Infrastructure.Commons;
using System.Linq.Expressions;

namespace BigonApp.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            var result = await Table.AddAsync(entity);
            return result.State == EntityState.Added;
        }

        public IEnumerable<T> GetAll()
        {
            var datas = Table.AsEnumerable();
            return datas;
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
           return Table.Where(expression);
        }
    }
}
