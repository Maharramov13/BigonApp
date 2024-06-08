﻿using BigonApp.Infrastructure.Entities;
using BigonApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Business.Modules.ColorsModules.Queries.ColorsGetAll
{

    public class ColorsGetAllRequestHandler : IRequestHandler<ColorsGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository;

        public ColorsGetAllRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<IEnumerable<Color>> Handle(ColorsGetAllRequest request, CancellationToken cancellationToken)
        {
            var colors = _colorRepository.GetWhere(x => x.DeletedAt == null);
            return colors;
        }
    }
}