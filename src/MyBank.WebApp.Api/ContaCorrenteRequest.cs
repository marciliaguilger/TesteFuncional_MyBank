using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.WebApp.Api
{
    public class ContaCorrenteRequest
    {
        public string Conta { get; set; }
        public decimal Valor { get; set; }
    }
}
