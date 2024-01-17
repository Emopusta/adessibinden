using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PhoneProducts.Commands.Update
{
    public class UpdatePhoneProductDto : IDto
    {
        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public int ModelId { get; set; }

        public int InternalMemoryId { get; set; }

        public int RAMId { get; set; }

        public bool UsageStatus { get; set; }

        public decimal Price { get; set; }
    }
}
