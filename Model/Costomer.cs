using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer:Person
    {
        public string Address { get; set; }
        public string Date { get; set; }
        public string CustomerNum { get; set; }
        public string Email { get; set; }
        public string PParticipation { get; set; }

    }
}
