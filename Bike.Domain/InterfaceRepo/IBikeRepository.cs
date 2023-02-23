
using Bike.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Domain.Interfaces
{
    public interface IBikeRepository
    {
        Task<List<BikeDetails>> GetAllAsync();

        Task<List<BikeDetails>>GetAllDetailsAsync();

        Task<BikeDetails>GetByIdAsync(int id);

        Task<BikeDetails> UpdateAsync(BikeDetails Detail);

        Task<BikeDetails> DeleteAsync(int id);

        Task<BikeDetails> CreateAsync(BikeDetails bike);

       
    }

}
