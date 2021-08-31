namespace CL.Core.Domain
{
    public class Telefone
    {
        public string Numero { get; set; }

        public long ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}