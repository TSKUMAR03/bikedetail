using Bike.Domain.Model;
using Bike.Service.ADO.Models;
using BikeProject.Model;
using BikeProject.Services.Model;

namespace BikeProject.Mapping
{
    public class MappingProfile: BikeProfile
    {
        public MappingProfile()
        {
            CreateMap<BikeModels, GetMilageResponce>();

            CreateMap<PostBikeRequest, BikeModels>();

            CreateMap<UpdateBikeRequest, BikeModels>();




            CreateMap<BikeModelADO, GetMilageResponce>();

            CreateMap<PostBikeRequest, BikeModelADO>();

            CreateMap<UpdateBikeRequest, BikeModelADO>();


         
        
        
        
        
        
        
        
        }

    }
}
