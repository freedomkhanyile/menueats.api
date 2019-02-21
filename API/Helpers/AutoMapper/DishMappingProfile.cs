namespace menueats.api.API.Helpers.AutoMapper
{

    using global::AutoMapper;
    using menueats.api.DAL.Entities;
    using menueats.api.DAL.Models;

    public class DishMappingProfile : Profile
    {
        public DishMappingProfile()
        {
            CreateMap<Dish, DishModel>()
                    .ReverseMap();
            CreateMap<Comment, CommentModel>()
                    .ForMember(m => m.Author, opt => opt.ResolveUsing(u => u.User.Email.ToString()))
                    .ReverseMap();
        }
    }
}