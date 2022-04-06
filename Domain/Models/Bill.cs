namespace Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Sum { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}