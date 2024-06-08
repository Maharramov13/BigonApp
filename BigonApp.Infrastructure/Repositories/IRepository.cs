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
        where T : class
    {
       
        public IEnumerable<T> GetAll();

        public IEnumerable<T> Get(Func<object, bool> value);

        public T Add(T model);

        public T Edit(T model);

        public T Remove(T model);
    }
}
