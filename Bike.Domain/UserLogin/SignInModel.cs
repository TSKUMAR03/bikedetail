using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Domain.Model
{
    public class SignInModel
    {
        [EmailAddress]
        public string? EmailId { get; set; }

        [DataType(DataType.Password)]
        public string? PassWord { get; set; }



    }
}
