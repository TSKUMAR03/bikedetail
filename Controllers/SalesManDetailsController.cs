using AutoMapper;
using Bike.Domain.Context;
using Bike.Domain.Model;
using Bike.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeProject.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class SalesManDetailsController : ControllerBase
    { 
        private readonly ISalesManService _SalesManService;
        public SalesManDetailsController(ISalesManService SalesManService)
        {
            _SalesManService = SalesManService;
        }


        [HttpGet("GetAllDetail")]
        public async Task<ActionResult<SalesManDetails>> GetAllAsync()
        {
            var bikes = await _SalesManService.GetAllAsync();
            return Ok(bikes);
        }

        [HttpGet("GetByBikeId{id}")]
        public async Task<ActionResult<SalesManDetails>> GetByIdAsync(int id)
        {
            var bike = await _SalesManService.GetByIdAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            return Ok(bike);
        }



        // PUT: api/Bikes/5
        [HttpPut("UpdateBike{id}")]
        public async Task<IActionResult> UpdateAsync(int id, SalesManDetails Detail)
        {
           
            var bike = await _SalesManService.UpdateAsync(id, Detail);

            return Ok(bike);
        }



        // POST: api/Bikes
        [HttpPost("PostBike")]
        public async Task<ActionResult<SalesManDetails>> CreateAsync(SalesManDetails bike)
        {
            var bikes = new SalesManDetails()
            {
                Name = bike.Name,
                EmailId = bike.EmailId,
                PassWord = bike.PassWord,
                PhoneNumber = bike.PhoneNumber,
                Address = bike.Address,
                
            };

            var Sales =await _SalesManService.CreateAsync(bike);

            return Ok(Sales);
       
           
        }



        // DELETE: api/Bikes/5
        [HttpDelete("{id}RemoveBike")]
        public async Task<ActionResult<SalesManDetails>> DeleteAsync(int id)
        {
           
            var data =await _SalesManService.DeleteAsync(id);
            return Ok("data");
        }

    }
}
