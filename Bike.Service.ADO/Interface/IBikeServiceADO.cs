using Bike.ADO.Model;
using Bike.Service.ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Service.ADO.Interface
{
    public interface IBikeServiceADO
    {

        List<BikeModelADO> GetAll();

        List<BikesModels> GetById(int Id);

        BikeModelADO Update(BikeModelADO bikes);

        bool Delete(int Id);

        BikeModelADO Create(BikeModelADO bike);


    }
}
