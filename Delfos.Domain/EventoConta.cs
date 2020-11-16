namespace Delfos.Domain
{
    public class EventoConta
    {
        public Evento evento { get; set; }
        public Conta conta { get; set; }
        public Historico historico { get; set; }
        public string DC { get; set; }
    }
}
