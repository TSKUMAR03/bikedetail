using AutoMapper;
using Bike.ADO.Model;
using Bike.Domain.Model;
using Bike.Service.ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Service.ADO.Mapping
{
    public class BikeProfileADO:Profile
    {
        public BikeProfileADO()
        {
            CreateMap<BikeModelADO, BikesModels>().ReverseMap();

           
        }
        

    }
}
