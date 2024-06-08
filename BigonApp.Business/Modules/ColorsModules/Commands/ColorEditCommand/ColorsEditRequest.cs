using BigonApp.Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModules.Commands.ColorsAddCommand.ColorsEditCommand
{
    public class ColorsEditRequest : IRequest<Color>
    {
        public string Name { get; set; }
        public string HaxCode { get; set; }
        public int Id { get; set; }
    }
}