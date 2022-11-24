using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Cont.Models
{
    internal class Reuniao
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? DataReuniao { get; set; }
        public DateTime? HorarioIncio { get; set; }
        public DateTime? HorarioTermino { get; set; }
        public string Tema { get; set; }
    }
}
