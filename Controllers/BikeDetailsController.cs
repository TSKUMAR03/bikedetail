using AutoMapper;
using Azure.Core;
using Bike.Domain.Context;
using Bike.Domain.Interfaces;
using Bike.Domain.Model;
using Bike.Services.Interfaces;
using BikeProject.Model;
using BikeProject.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using BikeDetails = Bike.Domain.Model.BikeDetails;

namespace BikeProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BikeDetailsController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        private readonly IMapper _mapper;

        public BikeDetailsController(IBikeService bikeService, IMapper mapper)
        {
            _bikeService = bikeService;
            _mapper = mapper;

        }

        [HttpGet("GetAllGetAllDetails")]
        public async Task<ActionResult<List<GetMilageResponce>>> GetAllDetailsAsync()
        {
            try
            {
                var responce = await _bikeService.GetAllDetailsAsync();
                var result = _mapper.Map<List<GetMilageResponce>>(responce);
               
                if (result.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<BikeDetails>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Bike Id cannot be less than zero.");

                var bike = await _bikeService.GetByIdAsync(id);
                if (bike == null)
                    return NoContent();

                return Ok(bike);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(PostBikeRequest bike)
        {

            try
            {
                var Transaction = await _bikeService.CreateAsync(_mapper.Map<BikeModels>(bike));

                return Ok("Transaction");

                if (string.IsNullOrEmpty(bike.Name))
                    throw new Exception(" Name is empty!");
                if (string.IsNullOrEmpty(bike.Model))
                    throw new Exception("Model  is empty!");
                if (string.IsNullOrEmpty(bike.Milage))
                    throw new Exception("Milage  is empty!");
                if (string.IsNullOrEmpty(bike.Speed))
                    throw new Exception("Speed  is empty!");
                if (string.IsNullOrEmpty(bike.CC))
                    throw new Exception("CC  is empty!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

              
            }

        }

        [HttpPut]

        public async Task<ActionResult<UpdateBikeRequest>> UpdateAsync(UpdateBikeRequest detail)
        {
            try
            {
               var update = await _bikeService.UpdateAsync(_mapper.Map<BikeModels>(detail));

                return Ok("Update");

                if (string.IsNullOrEmpty(detail.Name))
                    throw new Exception(" Name is empty!");
                if (string.IsNullOrEmpty(detail.Model))
                    throw new Exception("Model  is empty!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<BikeDetails>> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Bike Id cannot be less than zero.");

                var bikes = await _bikeService.DeleteAsync(id);
                if (bikes == null)
                {
                    return BadRequest("bike {id} does not exist!");

                    return Problem(statusCode: 400, detail: $"Bike id is not Found:{id}");

                }

                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }





        }
    }

}
































//[Route("api/[controller]")]
//[ApiController]
//public class BikeController : ControllerBase
//{
//    private readonly IBikeService _bikeService;

//    private readonly IMapper _mapper;

//    public BikeController(IBikeService bikeService, IMapper mapper)
//    {
//        _bikeService = bikeService;
//        _mapper = mapper;

//    }

//    [HttpGet("GetAll")]
//    public async Task<ActionResult<BikeDetails>> GetAllAsync()
//    {
//        try
//        {
//            var responce = _mapper.Map<List<GetMilageResponce>>(await _bikeService.GetAllAsync());
//            return Ok(responce);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message);
//        }
//    }


//    [HttpGet("GetAll")]
//    public async Task<ActionResult<BikeDetails>> GetAllDetailsAsync()
//    {
//        try
//        {
//            var items = await _bikeService.GetAllDetailsAsync();
//            if (items.Count == 0)
//            {
//                return NoContent();
//            }
//            else
//            {
//                return Ok(items);
//            }
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, ex);
//        }
//    }






//    [HttpGet("{id}")]
//    public async Task<ActionResult<BikeDetails>> GetByIdAsync(int id)
//    {
//        try
//        {
//            if (id <= 0)
//                throw new Exception("Bike Id cannot be less than zero.");

//            var bike = await _bikeService.GetByIdAsync(id);
//            if (bike == null)
//                return NoContent();

//            return Ok(bike);

//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message);
//        }
//    }

//    [HttpPost]
//    public async Task<ActionResult<PostBikeRequest>> CreateAsync(PostBikeRequest bike)
//    {

//        try
//        {
//            var Transaction = await _bikeService.CreateAsync(_mapper.Map<BikeModels>(bike));

//            if (Transaction == null)
//                return BadRequest("error");
//            return Ok(Transaction);

//            if (string.IsNullOrEmpty(bike.Name))
//                throw new Exception(" Name is empty!");
//            if (string.IsNullOrEmpty(bike.Model))
//                throw new Exception("Model  is empty!");
//            if (string.IsNullOrEmpty(bike.Milage))
//                throw new Exception("Milage  is empty!");
//            if (string.IsNullOrEmpty(bike.Speed))
//                throw new Exception("Speed  is empty!");
//            if (string.IsNullOrEmpty(bike.CC))
//                throw new Exception("CC  is empty!");
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message);
//        }

//    }

//    [HttpPut]
//    public async Task<ActionResult<UpdateBikeRequest>> UpdateAsync(UpdateBikeRequest detail)
//    {
//        try
//        {
//            var update = await _bikeService.UpdateAsync(_mapper.Map<BikeModels>(detail));
//            return Ok("Update");

//            if (string.IsNullOrEmpty(detail.Name))
//                throw new Exception(" Name is empty!");
//            if (string.IsNullOrEmpty(detail.Model))
//                throw new Exception("Model  is empty!");

//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message);
//        }

//    }


//    [HttpDelete("{id}")]
//    public async Task<ActionResult<Bike.Domain.Model.BikeDetails>> DeleteAsync(int id)
//    {
//        try
//        {
//            if (id <= 0)
//                throw new Exception("Bike Id cannot be less than zero.");

//            var bikes = await _bikeService.DeleteAsync(id);
//            if (bikes == null)
//                return BadRequest("bike {id} does not exist!");
//            return Ok(bikes);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message);
//        }


//    }


























//var update = _mapper.Map<BikeModels>(detail);
//return Ok(await _bikeService.UpdateAsync(id, update));



//if (string.IsNullOrEmpty(detail.Milage))
//    throw new Exception("Milage  is empty!");
//if (string.IsNullOrEmpty(detail.Speed))
//    throw new Exception("Speed  is empty!");
//if (string.IsNullOrEmpty(detail.CC))
//    throw new Exception("CC  is empty!");

// var update = await _bikeService.UpdateAsync(id, detail);



//var bikes = await _bikeService.GetAllAsync();
//var result = _mapper.Map<List<BikeModels>>(bikes);
//var Get = _mapper.Map<List<GetMilageResponce>>(result);
//return Ok(Get);



//var bike = await _bikeService.GetAllAsync();
//var result = _mapper.Map<List<GetMilageResponce>>(bike);
//return Ok(result);





