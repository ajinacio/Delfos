using System;

namespace Delfos.Domain
{
    public class Lancamento
    {
        public int Id { get; set; }
        public Entidade Entidade { get; set; }
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public string DC { get; set; }
        public Conta Conta { get; set; }
        public Historico Historico { get; set; }
        public string Complemento { get; set; }
        public Double Valor { get; set; }

    }
}
