using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dto.ParamDto
{
    public class PPlaceDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Gezi Adı")]
        [StringLength(100)]
        public string PlaceName { get; set; }

        
        [Required]
        [StringLength(5000)]
        [DisplayName("Gezi Yazısı")]
        [DataType(DataType.MultilineText)]
        public string PlaceText { get; set; }


        [DisplayName("Oluşturulma Tarihi")]
        [DisplayFormat(DataFormatString = "{0 : dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }
}
