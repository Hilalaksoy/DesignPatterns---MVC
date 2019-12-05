using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Common
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime CommentDate { get; set; }

        [StringLength(256)]
        public string CommentText { get; set; }

        public bool? VoteType { get; set; }

        public int PlaceId { get; set; }

        public int UserId { get; set; }
    }
}
