using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepo;

        public ProductsService(IProductsRepository productsRepo)
        {
            this._productsRepo = productsRepo;
        }
        public Product Create(Product product)
        {
            try
            {
                var res = _productsRepo.Create(product);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Delete(int ProductID)
        {
            try
            {
                var res = _productsRepo.Delete(ProductID);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Product> Get()
        {
            try
            {
                var res = _productsRepo.Get();
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product Get(int ProductID)
        {
            try
            {
                var res = _productsRepo.Get(ProductID);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product Update(Product product)
        {
            try
            {
                var res = _productsRepo.Update(product);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
