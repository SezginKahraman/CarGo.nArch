using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Brands.Constants;
using CarGo.Application.Services.Repositories;
using CarGo.Domain.Entities;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace CarGo.Application.Features.Brands.Rules
{
    public class BrandBusinessRules : BaseBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Name.ToLower() == name.ToLower());

            if (brand != null)
            {
                throw new BusinessException(BrandsMessages.BrandNameExists);
            }
        }
    }
}
