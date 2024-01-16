﻿using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PhoneProducts.Commands.Create
{
    public class CreatePhoneProductDto : IDto
    {
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatorUserId { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public int InternalMemoryId { get; set; }
        public int RAMId { get; set; }
        public bool UsageStatus { get; set; }
        public decimal Price { get; set; }
    }
}