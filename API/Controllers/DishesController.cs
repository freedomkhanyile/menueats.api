using System;
using System.Collections.Generic;
using AutoMapper;
using menueats.api.DAL.Contracts.IRepositoryWrapper;
using menueats.api.DAL.Entities;
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

        [HttpGet("{id}", Name = "GetDish")]
        public IActionResult Get(int id)
        {
            try
            {
                var dish = _repositoryWrapper.Dish.GetDishWithComments(id);
                if (dish == null) return NotFound($"Dish with {id} was not found");
                return Ok(dish);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dish model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (_repositoryWrapper.Dish.AddDish(model))
                    return CreatedAtRoute("GetDish", new { id = model.DishId }, model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return BadRequest("Server Error please try again.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Dish model)
        {
            try
            {
                 if (!ModelState.IsValid) return BadRequest(ModelState);
                 var dbmodel = _repositoryWrapper.Dish.GetDish(id);
                 if(dbmodel == null) return NotFound($"Could not find a dish with Id {id}");
                 
                 if(_repositoryWrapper.Dish.UpdateDish(dbmodel, model))   return CreatedAtRoute("GetDish", new { id = model.DishId }, model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return BadRequest("Server Error please try again.");
        }
    }
}