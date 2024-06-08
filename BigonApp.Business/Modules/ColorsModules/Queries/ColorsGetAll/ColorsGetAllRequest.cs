using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModules.Queries.ColorsGetAll
{
    public class ColorsGetAllRequest:IRequest<IEnumerable<Color>>
    {

    }

    
}
