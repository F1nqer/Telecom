using System.Collections.Generic;

namespace Domain.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProviderPrefix> ProviderPrefixes = new List<ProviderPrefix>();
        public List<Bill> Bills = new List<Bill>();
    }
}