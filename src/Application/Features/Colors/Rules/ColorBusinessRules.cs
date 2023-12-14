using Application.Features.Colors.Constants;
using Core.Application.GenericRepository;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Rules
{
    public class ColorBusinessRules : BaseBusinessRules
    {
        private readonly IGenericRepository<Color> _colorRepository;

        public ColorBusinessRules(IGenericRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task ColorNameCannotDuplicate(string name)
        {
            var color =  await _colorRepository.GetAsync(c => c.Name == name);
            if (color != null) throw new BusinessException(ColorsBusinessMessages.ColorNameDuplicated);

        }
    }
}
