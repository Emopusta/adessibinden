using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Queries.GetAll
{
    public class GetAllColorsListItemDto :IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
