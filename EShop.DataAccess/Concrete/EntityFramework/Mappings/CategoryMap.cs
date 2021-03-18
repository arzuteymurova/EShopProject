using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities.Concrete;

namespace EShop.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories");
            HasKey(c => c.CategoryId);
            Property(c => c.CategoryId).HasColumnName("CategoryId");
            Property(c => c.CategoryName).HasColumnName("CategoryName");
            Property(c => c.Description).HasColumnName("Description");
        }
    }
}
