using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dto.ParamDto
{
    public class PCommentDto
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Yorum Tarihi"), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CommentDate { get; set; }
       
        [Required]
        [StringLength(256)]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; }

        //Oy verme zorunluluğu yoktur. Bundan dolayı nullable olabilir.
        [DisplayName("Oy türü")]
        public bool? VoteType { get; set; }
    }
}
