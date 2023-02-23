using Bike.Domain.Context;
using Bike.Domain.InterfaceRepo;
using Bike.Domain.Interfaces;
using Bike.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Domain.Repository
{
    public class SalesManRepository : ISalesRepository
    {

        private readonly DataContext _context;


        public SalesManRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<SalesManDetails> CreateAsync(SalesManDetails bike)
        {
            
            var detail = new SalesManDetails()
            {
                SalesManId = bike.SalesManId,
                Name = bike.Name,
                EmailId = bike.EmailId,
                PassWord = bike.PassWord,
                PhoneNumber = bike.PhoneNumber,
                Address = bike.Address,

            };
            await _context.SalesManTable.AddAsync(detail);
            await _context.SaveChangesAsync();
            return (detail);
        }

        public async Task<SalesManDetails> DeleteAsync(int id)
        {
            var users = await _context.SalesManTable.FirstOrDefaultAsync(user => user.SalesManId == id);
            _context.SalesManTable.Remove(users);
            await _context.SaveChangesAsync();
            return (users);
        }

        public async Task<List<SalesManDetails>> GetAllAsync()
        {
            return await _context.SalesManTable.ToListAsync();
        }


        public async Task<SalesManDetails> GetByIdAsync(int id)
        {
            var acc = await _context.SalesManTable.FindAsync(id);
            if (acc == null)

                return null;

            return (acc);
          
        }

        public async Task<SalesManDetails> UpdateAsync(int id, SalesManDetails Detail)
        {
            var users = await _context.SalesManTable.FirstOrDefaultAsync(user => user.SalesManId == id);
            if (users == null)
                throw new Exception($"Customer {id} doesn't exist");
            //users.SalesManId = Detail.SalesManId;
            users.Name = Detail.Name;
            users.EmailId = Detail.EmailId;
            users.PassWord = Detail.PassWord;
            users.PhoneNumber = Detail.PhoneNumber;
            users.Address = Detail.Address;

            await _context.SaveChangesAsync();
            return (users);

        }

    }
}
