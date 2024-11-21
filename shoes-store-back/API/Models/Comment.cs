using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int ProductID { get; set; }
        public int AccountID { get; set; }
        [MaxLength(255)]
        public String Content {  get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Account Account { get; set; }
        public virtual Product Product { get; set; }
    }
}
