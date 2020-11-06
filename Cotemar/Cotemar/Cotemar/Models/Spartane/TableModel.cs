
using System.Drawing;
using System.Collections.Generic;

namespace Cotemar.Models.Spartane
{
    public class TableModel
    {
        public long Id { get; set; }
        public double Current { get; set; }
        public List<Customer> Customer{get; set;}
        public Color BgColor { get; set; }

    }
    public partial class Customer {

        public long Id { get; set; }
        public double Current { get; set; }
        public List<Product> Products{ get; set; }

        public Color BgColor { get; set; }

    }

    public partial class Product {
        public ProductsModel Type{get; set;}
        public int Quantity { get; set; }
    }
}
