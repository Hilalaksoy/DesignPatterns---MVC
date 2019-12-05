using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Docs
{
    public class Media
    {

        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public int PlaceId { get; set; }
    }
}
