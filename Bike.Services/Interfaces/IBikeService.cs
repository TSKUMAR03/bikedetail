using Bike.Domain.Model;

using BikeProject.Services.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Services.Interfaces
{
    public interface IBikeService
    {
        Task<List<BikeModels>>GetAllAsync();

        Task<List<BikeModels>> GetAllDetailsAsync();

        Task<BikeDetails>GetByIdAsync(int id);

        Task<BikeModels> UpdateAsync(BikeModels Detail);

        Task<BikeDetails> DeleteAsync(int id);

        Task<BikeModels> CreateAsync(BikeModels bike);


    }
}
