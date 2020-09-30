using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }        
        public int InitialDate { get; set; }
        public int EndDate { get; set; }
        public int InitialHour { get; set; }
        public int EndHour { get; set; }
        public bool Status { get; set; }
        public int AccountId { get; set; }
        public int PublicationId { get; set; }
        public Account Account {get;set;}
        public Publication Publication { get; set; }
    }
}
