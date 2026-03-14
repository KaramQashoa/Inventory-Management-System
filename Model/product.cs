using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class product:BaseEntity
    {
        public string Name { get; set; }
        public int  GB { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public byte[] image { get; set; }

    }
}
