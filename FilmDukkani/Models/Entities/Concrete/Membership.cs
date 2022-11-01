using System.Collections.Generic;

namespace FilmDukkani.Models.Entities.Concrete
{
    public class Membership  
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MovieChange { get; set; }
        public int MovieNumber { get; set; }
        public List<User> Users { get; set; }
    }
}
