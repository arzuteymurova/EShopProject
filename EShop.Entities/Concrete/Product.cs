using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Entities;

namespace EShop.Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuantityProduct { get; set; }
        public int AmountStock { get; set; }

    }
}
