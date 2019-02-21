using System;

namespace menueats.api.DAL.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int Rating { get; set; }
        public string DishComment { get; set; }
        public DateTime date { get; set; }
        public User User { get; set; }
        public Dish Dish { get; set; }
    }
}