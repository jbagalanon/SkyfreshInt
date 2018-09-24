using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyfreshInt.GetterSetter
{
    class chequesGetSet
    {
        public int chequeId { get; set; }
        public string accountName { get; set; }
        public string bankName { get; set; }
        public int chequeNo { get; set; }
        public DateTime chequeDate { get; set; }
        public float amount { get; set; }
        public string remarks { get; set; }
        public DateTime addedDate { get; set; }
        public int addedBy { get; set; }
    }
}
