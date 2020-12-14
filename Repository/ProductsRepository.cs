using System;
using System.Collections.Generic;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository.Abstractions;
using Dapper;

namespace Repository
{
    public class ProductsRepository : SuperRepository, IProductsRepository
    {
        public ProductsRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Product Create(Product p)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@ProductID", p.ProductID);
                param.Add("@ProductName", p.ProductName);
                param.Add("@TypeID", p.Type.TypeID);
                param.Add("@ProductPrice", p.ProductPrice);

                int res = conn.Execute("insert into Products(ProductID,ProductName,TypeID,ProductPrice) values(@ProductID, @ProductName, @TypeID, @ProductPrice)", param);
                if (res != 0)
                {
                    return this.Get(p.ProductID);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int ProductID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@ProductID", ProductID);

                int res = conn.Execute("delete from products where ProductID = @ProductID", param);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> Get()
        {
            try
            {
                IEnumerable<Product> Products = conn.Query<Product, Domain.Entities.Type, Product>(
                    "Select * from Products p inner join Types t on p.TypeID = t.TypeID",
                    (p, t) => {
                        p.Type = t;
                        return p;
                    },
                    null,
                    splitOn: "TypeID"
                    );

                return Products.AsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product Get(int ProductID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@ProductID", ProductID);

                IEnumerable<Product> Products = conn.Query<Product, Domain.Entities.Type, Product>(
                    "Select * from Products p inner join Types t on p.TypeID = t.TypeID where p.ProductID = @ProductID",
                    (p, t) => {
                        p.Type = t;
                        return p;
                    },
                    param,
                    splitOn: "TypeID"
                    );
                List<Product> productos = Products.AsList();
                return productos.Count > 0 ? productos[0] : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product Update(Product p)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@ProductID", p.ProductID);
                param.Add("@ProductName", p.ProductName);
                param.Add("@TypeID", p.Type.TypeID);
                param.Add("@ProductPrice", p.ProductPrice);

                int res = conn.Execute("update Products set ProductName = @ProductName,TypeID = @TypeID,ProductPrice = @ProductPrice where ProductID = @ProductID", param);
                if (res != 0)
                {
                    return this.Get(p.ProductID);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
