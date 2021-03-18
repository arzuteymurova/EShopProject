using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DataAccess.Abstract;
using EShop.Entities.Concrete;
using Project.Core.DataAccess.EntityFramework;

namespace EShop.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, EShopDbContext>, ICategoryDal
    {
    }
}
