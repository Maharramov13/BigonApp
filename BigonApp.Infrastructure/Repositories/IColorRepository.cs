using BigonApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Infrastructure.Repositories
{
    public interface IColorRepository : IRepository<Color>
    {
        //private readonly IColorRepository _db;
    }
}
