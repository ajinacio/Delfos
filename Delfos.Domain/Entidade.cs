using System.Collections.Generic;

namespace Delfos.Domain
{
    public class Entidade
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Endereco { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public int PlanoConta { get; set; }
        public int PlanoHist { get; set; }
        public string Titular { get; set; }
        public string Cargo { get; set; }
        public string Contador { get; set; }
        public string RegContador { get; set; }
        public List<int> Usuarios { get; set; }
    }
}
