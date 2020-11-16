using System;

namespace Delfos.Domain
{
    public class Saldo
    {
        public int Id { get; set; }
        public Entidade Entidade { get; set; }
        public Conta Conta { get; set; }
        public int Ano { get; set; }
        public string Tipo { get; set; }
        public Double Valor { get; set; }
        public string DC { get; set; }
    }
}
