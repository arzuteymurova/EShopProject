using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities.Concrete;

namespace EShop.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        void TransactionalOperation(Category category1, Category category2);
        Category GetById(int id);
        List<Category> GetByCategoryName(string name);
        List<Category> GetByDescription(string text);

    }
}
