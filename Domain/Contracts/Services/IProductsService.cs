using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Services
{
    public interface IProductsService
    {
        List<Product> Get();
        Product Get(int ProductID);
        Product Create(Product product);
        Product Update(Product product);
        int Delete(int ProductoID);
    }
}
