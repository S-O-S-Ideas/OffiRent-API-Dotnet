using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OffiRent.API.Resources
{
    public class SaveReservationResource
    {
  
        public string InitialDate { get; set; }
        public string FinishDate { get; set; }
        //public int InitialDate { get; set; }
        //public int EndDate { get; set; }
        //public int InitialHour { get; set; }
        //public int EndHour { get; set; }
        public bool Status { get; set; }
        public int AccountId { get; set; }
        public int OfficeId { get; set; }
    }
}
