using AutoMapper;
using Bike.ADO.Interfaces;
using Bike.ADO.Model;
using Bike.Domain.Interfaces;
using Bike.Domain.Model;
using Bike.Service.ADO.Interface;
using Bike.Service.ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Service.ADO.Services
{
    public class BikeServiceImplADO : IBikeServiceADO
    {

        private readonly IRepositoryADO _repository;

        private readonly IMapper _mapper;

        public BikeServiceImplADO(IRepositoryADO repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public BikeModelADO Create(BikeModelADO bike)
        {
            return _mapper.Map<BikeModelADO>(_repository.Create(_mapper.Map<BikesModels>(bike)));
        }

        public bool Delete(int Id)
        {
            return _repository.Delete(Id);
        }



        public List<BikeModelADO> GetAll()
        {
            var result = _repository.GetAll();

            return _mapper.Map<List<BikeModelADO>>(result);

        }




        //public List<BikeModelADO> GetAll()
        //{
        //    return _repository.GetAll();

        //}




        public List<BikesModels>GetById(int Id)
        {

            return _repository.GetById(Id);


            //var result = _repository.GetById(Id);
            //return _mapper.Map<List<BikeModelADO>>(result);
        }

        public BikeModelADO Update(BikeModelADO bikes)
        {
            return _mapper.Map<BikeModelADO>(_repository.Update(_mapper.Map<BikesModels>(bikes)));
        }
    }
}
