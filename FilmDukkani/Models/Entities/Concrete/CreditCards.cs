using System;

namespace FilmDukkani.Models.Entities.Concrete
{
    public class CreditCards
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public int CvcCode { get; set; }
    }
}
