using DCA.Persistence.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCA.Entities;
using DCA.Persistence.Contracts;

namespace DCA.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IEntityFrameworkGenericRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IEntityFrameworkGenericRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);

            _unitOfWork.Commit();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
