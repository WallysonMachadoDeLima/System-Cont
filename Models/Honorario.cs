﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Cont.Models
{
    internal class Honorario
    {

        public int Id { get; set; }
        public string NumeroProcesso { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime? DataHonorario { get; set; }
        public Processo Processo { get; set; }

    }
}
