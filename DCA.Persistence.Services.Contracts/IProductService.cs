using DCA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DCA.Persistence.Services.Contracts
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id);

        void Add(Product product);
    }
}
