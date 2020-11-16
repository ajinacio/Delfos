using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delfos.Domain
{
    public class Movimento
    {
        public int Id { get; set; }
        public Entidade Entidade { get; set; }
        public Conta Conta { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public Double Devedor { get; set; }
        public Double Credor { get; set; }
    }
}
