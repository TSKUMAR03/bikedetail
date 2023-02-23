using Bike.Domain.Context;
using Bike.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bike.Domain.Model;


namespace Bike.Services.Repository
{
    public class BikeRepository :IBikeRepository
    {

        private readonly DataContext _context;


        public BikeRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<List<BikeDetails>> GetAllAsync()
        {
            return await _context.Details.ToListAsync();
        }



        public async Task<List<BikeDetails>> GetAllDetailsAsync()
        {
            return await _context.Details.ToListAsync();
        }




        public async Task<BikeDetails> GetByIdAsync(int id)
        {
            //var sales = await _context.Details.Include(x => x.SalesManDetails).FirstOrDefaultAsync(sales => sales.SalesManId == id);
            //return sales;

            var acc = await _context.Details.FindAsync(id);
            if (acc == null)
                return null;
            var Sales = await _context.Details.Include(S=>S.SalesManDetails).Where(b => b.Id == id).ToListAsync();
            return acc;

            //var details = await _context.Details.Where(user => user.SalesManId == id).FirstOrDefaultAsync();
            //return details;
        }

        public async Task<BikeDetails> UpdateAsync(BikeDetails Detail)
        {
            var users = await _context.Details.FirstOrDefaultAsync(user => user == Detail);
            if (users == null)
                throw new Exception($"Customer  doesn't exist");
            users.Name = Detail.Name;
            users.Model = Detail.Model;
            users.SalesDate = Detail.SalesDate;
           
             await _context.SaveChangesAsync();
            return users;
        }

        public async Task<BikeDetails> DeleteAsync(int id)
        {
            var users = await _context.Details.FirstOrDefaultAsync(user => user.Id == id);
            if (users == null)
                throw new Exception($"Customer {id} doesn't exist");
            _context.Details.Remove(users);
            await _context.SaveChangesAsync();
            return (users);
        }

        public async Task<BikeDetails>CreateAsync(BikeDetails bike)
        {
            var result = await _context.SalesManTable.FindAsync(bike.SalesManId);
            if (result == null)
                return null;
            var detail = new BikeDetails()
            {
                Name = bike.Name,
                Model = bike.Model,
                SalesDate = bike.SalesDate,
                Milage = bike.Milage,
                Speed = bike.Speed,
                CC = bike.CC,
                SalesManId = bike.SalesManId,
                SalesManDetails =result,

            };
            await _context.Details.AddAsync(detail);
            await _context.SaveChangesAsync();
            return (detail);
        }



    }
}
