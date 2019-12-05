using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Common
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string PlaceName { get; set; }

        [StringLength(5000)]
        public string PlaceText { get; set; }
    
        public DateTime CreatedDate { get; set; }
    }
}
