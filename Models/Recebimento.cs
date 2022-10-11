using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Cont.Models
{
    internal class Recebimento
    {
        public int Id { get; set; }
        public string DescricaoRec { get; set; }
        public double ValorRec { get; set; }
        public DateTime? Data_Recebimento { get; set; }
    }
}
