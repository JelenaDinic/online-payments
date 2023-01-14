using System.ComponentModel.DataAnnotations;

namespace PaymentBackend.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public double Rate { get; set; }
    }
}
