using System;
using System.Threading.Tasks;
using AutoMapper;
using menueats.api.DAL.Contracts.IRepositoryWrapper;
using menueats.api.DAL.Entities;
using menueats.api.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace menueats.api.API.Controllers
{
    [Route("api/dishes/{id}/comments", Name = "CommentGet")]
    public class CommentsController : Controller
    {
        public CommentsController(IRepositoryWrapper repositoryWrapper, IMapper mapper, UserManager<User> userManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _userManager = userManager;
        }

        private IRepositoryWrapper _repositoryWrapper;
        private IMapper _mapper;
        private UserManager<User> _userManager;

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(int id, [FromBody] CommentModel model)
        {
            try
            {   
                var dish = _repositoryWrapper.Dish.GetDish(id);
                var comment = _mapper.Map<Comment>(model);
                comment.Dish = dish;
                var user = await _userManager.FindByNameAsync(this.User.Identity.Name);

                if(user != null){
                    comment.User = user;
                    if(_repositoryWrapper.Comment.AddComment(comment)){
                        var url = Url.Link("CommentGet", new {id = model.CommentId});
                        return Created(url, _mapper.Map<CommentModel>(comment));
                    }

                }

            }
            catch (Exception ex)
            {                
              throw new Exception(ex.Message);
            }
             return BadRequest("Could not post comment");  
        }
    }
}