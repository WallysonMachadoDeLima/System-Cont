using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Cont.Models
{
    internal class Processo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
    }
}
