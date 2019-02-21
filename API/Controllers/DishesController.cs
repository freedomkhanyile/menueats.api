using System.Collections.Generic;
using AutoMapper;
using menueats.api.DAL.Contracts.IRepositoryWrapper;
using menueats.api.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace menueats.api.API.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {

        public DishesController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;

        [HttpGet]
        public IActionResult Get()
        {
            var dishes = _repositoryWrapper.Dish.GetDishes();
            return Ok(_mapper.Map<IEnumerable<DishModel>>(dishes));
        }
    }
}