using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Resources
{
    public class SaveCurrencyResource
    {
        [Required]
        [MaxLength(30)]
        public char Name { get; set; }

        [Required]
        [MaxLength(1)]
        public char Symbol { get; set; }
    }
}
