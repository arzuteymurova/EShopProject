using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Business.Abstract;
using EShop.DataAccess.Abstract;
using EShop.Entities.Concrete;

namespace EShop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }


        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //Business codes...
            _productDal.Update(product2);
        }

        public Product GetById(int id)
        {
            return _productDal.GetAll(p => p.ProductId == id).FirstOrDefault();
        }

        public List<Product> GetByCategoryName(string name)
        {
            return _productDal.GetAll(p => p.CategoryName.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Product> GetByProductName(string name)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min & p.UnitPrice <= max).ToList();
        }
    }
}
