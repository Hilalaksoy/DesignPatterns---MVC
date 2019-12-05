using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Common
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public int DistrictId { get; set; }
    }
}
