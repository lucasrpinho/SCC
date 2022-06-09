namespace Services
{
    public interface IPedidoServ
    {
        public int vendedor { get; set; }
        public DateTime data { get; set; }
        public double valor { get; set; }
    }
}