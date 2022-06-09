namespace Entities
{
    public class Meta
    {
        public int mes { get; set; }
        public int qtd { get; set; }

        public Meta(int mes, int qtd)
        {
            this.mes = mes;
            this.qtd = qtd;
        }
    }
}