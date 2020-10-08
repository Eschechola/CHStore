using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Catalog.DomainServices.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDomainService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Add(Category category)
        {
            return await _categoryRepository.Add(category);
        }

        public async Task<IList<Category>> Get()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> Get(long categoryId)
        {
            return await _categoryRepository.Get(categoryId);
        }

        public async Task<Category> Update(Category category)
        {
            return await _categoryRepository.Update(category);
        }
    }
}
