using BigonApp.Business.Modules.ColorsModules.Commands.ColorsAddCommand.ColorsEditCommand;
using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModules.Commands.ColorEditCommand
{
    internal class ColorsEditRequestHandler : IRequestHandler<ColorsEditRequest, Color>
    {
        private readonly IColorRepository _colorRepository;
        public ColorsEditRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorsEditRequest request, CancellationToken cancellationToken)
        {
            var color = new Color
            {
                Id = request.Id,
                Name = request.Name,
                HaxCode = request.HaxCode,
            };
            _colorRepository.Edit(color);
            return color;
        }
    }
}
