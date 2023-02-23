using AutoMapper;
using Bike.ADO.Repository;
using Bike.Domain.InterfaceRepo;
using Bike.Domain.Interfaces;
using Bike.Domain.Model;
using Bike.Domain.Repository;
using Bike.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Services.Services
{
    public class SalesManServiceImpl : ISalesManService
    {

        private readonly ISalesRepository _SalesRepository;

        public SalesManServiceImpl(ISalesRepository SalesRepository)
        {
            _SalesRepository = SalesRepository;
           
        }
        public async Task<SalesManDetails> CreateAsync(SalesManDetails bike)
        {
            return await _SalesRepository.CreateAsync(bike);
        }

        public async Task<SalesManDetails> DeleteAsync(int id)
        {
            return await _SalesRepository.DeleteAsync(id);
        }

        public async Task<List<SalesManDetails>> GetAllAsync()
        {
            return await _SalesRepository.GetAllAsync();
        }

        public async Task<SalesManDetails>GetByIdAsync(int id)
        {
            return await _SalesRepository.GetByIdAsync(id);
        }

        public async Task<SalesManDetails> UpdateAsync(int id, SalesManDetails Detail)
        {
            return await _SalesRepository.UpdateAsync(id,Detail);
        }
    }
}
