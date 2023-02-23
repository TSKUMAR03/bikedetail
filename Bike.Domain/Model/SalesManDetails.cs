using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Domain.Model
{
    public class SalesManDetails
    {
        [Key]

        public int SalesManId { get; set; }

        public string? Name { get; set; }

        public string? EmailId { get; set; }

        public string? PassWord  {get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

    }
}
