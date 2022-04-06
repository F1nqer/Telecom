namespace Domain.Models
{
    public class ProviderPrefix
    {
        public int Id { get; set; }
        public int Prefix { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}