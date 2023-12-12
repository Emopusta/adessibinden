﻿using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarBrands.Commands.Create
{
    public class CreatedCarBrandResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
