namespace MoneyMonitor.Models
{
    public class Year 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WealthId { get; set; }
        public Wealth Wealth { get; internal set; }
        public int Order { get; set; }
    }
}
