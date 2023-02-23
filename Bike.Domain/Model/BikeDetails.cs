using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Domain.Model
{
    public class BikeDetails
    {
        [Key]

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Model { get; set; }

        public DateTime SalesDate { get; set; }

        public string? Milage { get; set; }

        public string? Speed { get; set; }

        public string? CC { get; set; }


        [ForeignKey("SalesManDetails")]

        public int SalesManId { get; set; }

        public virtual SalesManDetails? SalesManDetails { get; set; }

        
    }

}
