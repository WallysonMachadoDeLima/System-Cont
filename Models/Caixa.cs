using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Cont.Models
{
    internal class Caixa
    {
        public int Id { get; set; }
        public double SaldoAtual { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
