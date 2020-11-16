namespace Delfos.Domain
{
    public class Conta
    {
        public int Id { get; set; }
        public int PlanoContas { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Nivel { get; set; }
    }
}
