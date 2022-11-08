using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Cont.Models
{
    internal class Despesa
    {
        public int Id { get; set; }
        public string DescricaoDes { get; set; }
        public double ValorDes { get; set; }
        public DateTime? Data_Despesa { get; set; }
    }
}
