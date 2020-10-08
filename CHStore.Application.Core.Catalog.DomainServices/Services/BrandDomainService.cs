using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Catalog.DomainServices.Services
{
    public class BrandDomainService : IBrandDomainService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandDomainService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> Add(Brand brand)
        {
            return await _brandRepository.Add(brand);
        }

        public async Task<IList<Brand>> Get()
        {
            return await _brandRepository.Get();
        }

        public async Task<Brand> Get(long brandId)
        {
            return await _brandRepository.Get(brandId);
        }

        public async Task<Brand> Update(Brand brand)
        {
            return await _brandRepository.Update(brand);
        }
    }
}
