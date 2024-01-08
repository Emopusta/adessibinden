using Core.Application.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Create
{
    public class CreateProductCommand : ICommandRequest<CreatedProductResponse>
    {
        public int CreatorUserId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
