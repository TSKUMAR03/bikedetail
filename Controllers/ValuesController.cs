using AutoMapper;
using Bike.ADO.Model;
using Bike.Domain.Model;
using Bike.Service.ADO.Interface;
using Bike.Service.ADO.Models;
using Bike.Services.Interfaces;
using BikeProject.Model;
using BikeProject.Services.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace BikeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBikeServiceADO _bikeServiceADO;

        private readonly IMapper _mapper;

        public ValuesController(IBikeServiceADO bikeServiceADO, IMapper mapper)
        {
            _bikeServiceADO = bikeServiceADO;
            _mapper = mapper;

        }

        [HttpGet("GetAll")]
        public ActionResult<BikesModels> GetAll()
        {
            try
            {
                var responce = _mapper.Map<List<GetMilageResponce>>( _bikeServiceADO.GetAll());
                return Ok(responce);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<List<BikesModels>>GetById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Bike Id cannot be less than zero.");

                var result = _bikeServiceADO.GetById(id);
                if (result == null)
                    return BadRequest("bike {id} does not exist!");

                return Ok(result);


                //if (id <= 0)
                //    throw new Exception("Bike Id cannot be less than zero.");

                //var res = _bikeServiceADO.GetById(id);
                //var result = _mapper.Map<List<BikeModelADO>>(res);
                //if (result == null)
                //    return BadRequest("bike {id} does not exist!");

                //return Ok(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<PostBikeRequest>Create(PostBikeRequest bike)
        {

            try
            {
                var Transaction =  _bikeServiceADO.Create(_mapper.Map<BikeModelADO>(bike));

                if (Transaction == null)
                    return BadRequest("error");
                return Ok(Transaction);

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
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult<UpdateBikeRequest> Update(UpdateBikeRequest bikes)
        {
            try
            {
                var update =  _bikeServiceADO.Update(_mapper.Map<BikeModelADO>(bikes));
                return Ok("Update");

                if (string.IsNullOrEmpty(bikes.Name))
                    throw new Exception(" Name is empty!");
                if (string.IsNullOrEmpty(bikes.Model))
                    throw new Exception("Model  is empty!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpDelete("{id}")]
        public ActionResult<BikesModels> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Bike Id cannot be less than zero.");

                var bikes =  _bikeServiceADO.Delete(id);
                if (bikes == null)
                    return BadRequest("bike {id} does not exist!");
                return Ok(bikes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }












































            //[Route("api/[controller]")]
            //[ApiController]
            //public class ValuesController : ControllerBase
            //{

            //    private readonly IConfiguration _Configuration;

            //    public ValuesController(IConfiguration configuration)
            //    {
            //        _Configuration = configuration;


            //    }

            //    [HttpGet]
            //    [Route("GetAll")]
            //   // public List<BikeModels> GetAll()
            //   // public async Task<ActionResult<BikesModels>>GetAllAsync()
            //    public ActionResult<BikesModels> GetAll()
            //    {
            //        List<BikesModels> Lst = new List<BikesModels>();
            //        SqlConnection Con = new SqlConnection(_Configuration.GetConnectionString("Connect"));
            //        SqlCommand command = new SqlCommand("Select * From Details", Con);
            //        SqlDataAdapter adapter = new SqlDataAdapter(command);
            //        DataTable dt = new DataTable();
            //        adapter.Fill(dt);

            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            BikesModels bike = new BikesModels();

            //            bike.Id = int.Parse(dt.Rows[i]["Id"].ToString());
            //            bike.Name = dt.Rows[i]["Name"].ToString();
            //            bike.Model = dt.Rows[i]["Model"].ToString();
            //            bike.SalesDate = (DateTime)dt.Rows[i]["SalesDate"];
            //            bike.Milage = dt.Rows[i]["Milage"].ToString();
            //            bike.Speed = dt.Rows[i]["Speed"].ToString();
            //            bike.CC = dt.Rows[i]["CC"].ToString();
            //            bike.SalesManId = int.Parse(dt.Rows[i]["SalesManId"].ToString());


            //            Lst.Add(bike);

            //        }
            //        return Ok(Lst);
            //    }

            //    [HttpGet]
            //    [Route("GetById")]
            //    //public List<BikeModels> GetById(int Id)
            //    //public async Task<ActionResult<BikesModels>>GetByIdAsync(int id)
            //    public ActionResult<BikesModels> GetById(int Id)
            //    {
            //        return Ok (GetAll().Where(x => x.Id == Id).ToList());

            //    }

            //    [HttpPost]
            //    [Route("PostItem")]
            //    // public String PostIteam(BikeModels bike)
            //    //public async Task<ActionResult<BikesModels>> PostItemAsync(BikesModels bike)
            //    public ActionResult<BikesModels> PostItem(BikesModels bike)
            //    {
            //        SqlConnection con = new SqlConnection(_Configuration.GetConnectionString("Connect"));
            //        SqlCommand command = new SqlCommand("Insert into Details values ('" + bike.Name + "','" + bike.Model + "','" + bike.SalesDate + "','" + bike.Milage + "','" + bike.Speed + "','" + bike.CC + "','" + bike.SalesManId.ToString() + "')", con);
            //        con.Open();
            //        command.ExecuteNonQuery();
            //        con.Close();
            //        return Ok("Created Successfully");
            //    }



            //    [HttpDelete]
            //    [Route("DeleteItem")]
            //    // public String DeleteIteam(int Id)
            //    // public async Task<ActionResult<BikesModels>> DeleteItemAsync(int Id)
            //    public ActionResult<BikesModels> DeleteItem(int Id)
            //    {
            //        SqlConnection con = new SqlConnection(_Configuration.GetConnectionString("Connect"));
            //        SqlCommand command = new SqlCommand("Delete From Details Where Id ='" + Id + "'", con);
            //        con.Open();
            //        command.ExecuteNonQuery();
            //        con.Close();
            //        return Ok("Deleted Successfully");
            //    }


            //    [HttpPut]
            //    [Route("PutItem")]
            //    // public String PutIteam(int Id, BikeModels bike)
            //    // public async Task<ActionResult<BikesModels>>PutItemAsync(int Id,BikesModels bike)
            //    public ActionResult<BikesModels> PutItem(int Id, BikesModels bike)
            //    {
            //        SqlConnection con = new SqlConnection(_Configuration.GetConnectionString("Connect"));
            //        SqlCommand command = new SqlCommand("Update Details set Name = '" + bike.Name + "',Model= '" + bike.Model + "',SalesDate='" + bike.SalesDate + "',Milage='" + bike.Milage + "',Speed='" + bike.Speed + "',CC='" + bike.CC + "'Where Id='" + Id + "'", con);
            //        con.Open();
            //        command.ExecuteNonQuery();
            //        con.Close();
            //        return Ok("Updated Successfully");
            //    }




    }
}
