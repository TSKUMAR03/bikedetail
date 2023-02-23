using AutoMapper;
using Bike.Domain.Interfaces;
using Bike.Domain.Model;
using Bike.Services.Interfaces;
using BikeProject.Services.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using BikeDetails = Bike.Domain.Model.BikeDetails;

namespace Bike.Services.RepositoryService
{

    public class BikeServiceImpl : IBikeService
    {

        private readonly IBikeRepository _repository;

        private readonly IMapper _mapper;

        public BikeServiceImpl(IBikeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BikeModels> CreateAsync(BikeModels bike)
        {

            return _mapper.Map<BikeModels>(await _repository.CreateAsync(_mapper.Map<BikeDetails>(bike)));
        }

        public async Task<BikeDetails> DeleteAsync(int id)
        {

            return await _repository.DeleteAsync(id);
        }

        public async Task<List<BikeModels>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return _mapper.Map<List<BikeModels>>(result);

        }


        public async Task<List<BikeModels>> GetAllDetailsAsync()
        {
            var data = await _repository.GetAllDetailsAsync();
            //return data;

            // return (await _repository.GetAllDetailsAsync());
            return _mapper.Map<List<BikeModels>>(data);
        }

        public async Task<BikeDetails> GetByIdAsync(int id)
        {

            return await _repository.GetByIdAsync(id);
        }

        public async Task<BikeModels> UpdateAsync(BikeModels Detail)
        {

            return _mapper.Map<BikeModels>(await _repository.UpdateAsync(_mapper.Map<BikeDetails>(Detail)));

            // return await _repository.UpdateAsync(id, Detail);
        }


    }







































    //public class BikeServiceImpl : IBikeService
    //{

    //    private readonly IBikeRepository _repository;

    //    private readonly IMapper _mapper;

    //    public BikeServiceImpl(IBikeRepository repository, IMapper mapper)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //    }
    //    public async Task<BikeDetails> CreateAsync(BikeDetails bike)
    //    {

    //        // return _mapper.Map<BikeModels>(await _repository.CreateAsync(_mapper.Map<BikeDetails>(bike)));
    //        var results = await _repository.CreateAsync(bike);

    //        return results;
    //    }

    //    public async Task<BikeDetails> DeleteAsync(int id)
    //    {

    //        return await _repository.DeleteAsync(id);
    //    }

    //    public async Task<List<BikeModels>> GetAllAsync()
    //    {
    //        var result = await _repository.GetAllAsync();

    //        return _mapper.Map<List<BikeModels>>(result);

    //    }


    //    public async Task<List<BikeDetails>> GetAllDetailsAsync()
    //    {
    //        var data = await _repository.GetAllDetailsAsync();
    //        return data;

    //        // return (await _repository.GetAllDetailsAsync());

    //    }

    //    public async Task<BikeDetails>GetByIdAsync(int id)
    //    {

    //        return await _repository.GetByIdAsync(id);
    //    }

    //    // public async Task<BikeModels> UpdateAsync(BikeModels Detail)
    //    public async Task<BikeDetails> UpdateAsync(BikeDetails Detail)
    //    {

    //       // return _mapper.Map<BikeModels>(await _repository.UpdateAsync(_mapper.Map<BikeDetails>(Detail)));

    //         return await _repository.UpdateAsync(Detail);
    //    }


    //}
























    //public class BikeServiceImpl : IBikeService
    //{

    //    private readonly IBikeRepository _repository;

    //    private readonly IMapper _mapper;

    //    public BikeServiceImpl(IBikeRepository repository, IMapper mapper)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //    }
    //    public async Task<BikeModels> CreateAsync(BikeModels bike)
    //    {

    //        return _mapper.Map<BikeModels>(await _repository.CreateAsync(_mapper.Map<BikeDetails>(bike)));
    //    }

    //    public async Task<BikeDetails> DeleteAsync(int id)
    //    {

    //        return await _repository.DeleteAsync(id);
    //    }

    //    public async Task<List<BikeModels>> GetAllAsync()
    //    {
    //        var result = await _repository.GetAllAsync();

    //        return _mapper.Map<List<BikeModels>>(result);

    //    }


    //    public async Task<List<BikeDetails>> GetAllDetailsAsync()
    //    {
    //        var data = await _repository.GetAllDetailsAsync();
    //        return data;

    //        // return (await _repository.GetAllDetailsAsync());

    //    }

    //    public async Task<BikeDetails> GetByIdAsync(int id)
    //    {

    //        return await _repository.GetByIdAsync(id);
    //    }

    //    public async Task<BikeModels> UpdateAsync(BikeModels Detail)
    //    {

    //        return _mapper.Map<BikeModels>(await _repository.UpdateAsync(_mapper.Map<BikeDetails>(Detail)));

    //        // return await _repository.UpdateAsync(id, Detail);
    //    }


    //}














































}
    //return await _repository.CreateAsync(_mapper.Map<BikeModels>(bike));

    //return await _repository.CreateAsync(bike);

    //var response = await _repository.CreateAsync(_mapper.Map<PostBikeRequest,BikeModels>(bike))





