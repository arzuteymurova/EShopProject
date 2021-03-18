using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities.Concrete;

namespace EShop.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        void TransactionalOperation(Product product1, Product product2);

        Product GetById(int id);
        List<Product> GetByCategoryName(string name);
        List<Product> GetByProductName(string name);
        List<Product> GetByUnitPrice(decimal min, decimal max);
    }
}
