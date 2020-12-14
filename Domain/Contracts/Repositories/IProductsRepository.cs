using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IProductsRepository
    {
        List<Product> Get();
        Product Get(int ProductID);
        Product Create(Product product);
        Product Update(Product product);
        int Delete(int ProductoID);
    }
}
