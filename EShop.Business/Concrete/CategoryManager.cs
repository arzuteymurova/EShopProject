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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;

        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }


        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }


        public void TransactionalOperation(Category category1, Category category2)
        {
            _categoryDal.Add(category1);
            //Business codes...
            _categoryDal.Update(category2);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetAll(c => c.CategoryId == id).SingleOrDefault();
        }

        public List<Category> GetByCategoryName(string name)
        {
            return _categoryDal.GetAll(c => c.CategoryName.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Category> GetByDescription(string text)
        {
            return _categoryDal.GetAll(c => c.Description.ToLower().Contains(text.ToLower())).ToList();
        }
    }
}
