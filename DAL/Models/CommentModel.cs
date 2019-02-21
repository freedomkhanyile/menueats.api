using System;

namespace menueats.api.DAL.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string Rating { get; set; }
        public string DishComment { get; set; }
        public DateTime date { get; set; }
        public string Author { get; set; }
    }
}