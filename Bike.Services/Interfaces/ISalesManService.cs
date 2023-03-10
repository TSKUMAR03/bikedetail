using Bike.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Services.Interfaces
{
    public interface ISalesManService
    {
        Task<List<SalesManDetails>> GetAllAsync();

        Task<SalesManDetails>GetByIdAsync(int id);

        Task<SalesManDetails> UpdateAsync(int id, SalesManDetails Detail);

        Task<SalesManDetails> DeleteAsync(int id);

        Task<SalesManDetails> CreateAsync(SalesManDetails bike);

    }
}
