using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModules.Queries.ColorsGet
{
    public class ColorsGetByIdRequest:IRequest<Color>
    {
        public int Id { get; set; }
    }
}
