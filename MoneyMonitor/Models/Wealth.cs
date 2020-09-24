using System.Collections.Generic;

namespace MoneyMonitor.Models
{
    public class Wealth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public ICollection<Year> Years { get; set; }
    }
}
