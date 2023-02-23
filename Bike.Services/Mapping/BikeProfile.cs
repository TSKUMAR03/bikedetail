using AutoMapper;
using Bike.ADO.Model;
using Bike.Domain.Model;
using BikeProject.Mapping;
using BikeProject.Services.Model;

namespace BikeProject.Mapping
{
    public class BikeProfile : Profile
    {
        public BikeProfile()
        {
              CreateMap<BikeModels,BikeDetails>().ReverseMap();
              CreateMap<BikeDetails, BikeModels>();

              
        }

    }   
   
}
