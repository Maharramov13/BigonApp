using BigonApp.Infrastructure.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Infrastructure.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<bool> AddAsync(T entity);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetWhere(Expression<Func<T,bool>> expression);
    }
}
