using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relation_1to1.DataBase
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        //type? - Nulable type
        public int? ProductId { get; set; } 
        public Product Product { get; set; }

    }
}
