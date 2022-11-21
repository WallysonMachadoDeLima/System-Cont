using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Cont.Models
{
    internal class Tarefa
    {
        public int Id { get; set; }
        public DateTime? Data_Inicio { get; set; }
        public DateTime? Data_Termino { get; set; }
        public Processo Processo { get; set; }
    }
}
