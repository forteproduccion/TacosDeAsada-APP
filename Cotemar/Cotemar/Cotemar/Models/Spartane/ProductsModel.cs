/*
 Id => 1 quesadilla, 2 taco, 3 otro
 */
using System.Drawing;

namespace Cotemar.Models.Spartane
{
    public class ProductsModel
    {
        public long Id{ get; set;}
        public string Name { get; set; }
        public Type SelectProduct { get; set; }
        public double Price { get; set; }
        public Color BgColor { get; set; }
    }
    public partial class Type
    { 
        /*
         1 = carne, 2=otro
         */
        public long Id { get; set; }
        public string Name { get; set; }
    
    }
}
