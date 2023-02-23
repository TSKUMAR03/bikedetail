using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Service.ADO.Models
{
    public class BikeModelADO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Milage { get; set; }

        public string? Model { get; set; }

        public DateTime SalesDate { get; set; }



    }
}
