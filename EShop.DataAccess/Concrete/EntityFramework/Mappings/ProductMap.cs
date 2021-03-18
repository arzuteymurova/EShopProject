using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities.Concrete;

namespace EShop.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products");
            HasKey(p => p.ProductId);
            Property(p => p.ProductId).HasColumnName("ProductId");
            Property(p => p.ProductName).HasColumnName("ProductName");
            Property(p => p.CategoryName).HasColumnName("CategoryName");
            Property(p => p.UnitPrice).HasColumnName("UnitPrice");
            Property(p => p.QuantityProduct).HasColumnName("QuantityProduct");
            Property(p => p.AmountStock).HasColumnName("AmountStock");


        }
    }
}
