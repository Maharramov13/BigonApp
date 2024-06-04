using BigonApp.Data.Contexts;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Data.Repositories
{
    internal class ColorRepository:Repository<Color> , IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context) { }
            
    }
}
