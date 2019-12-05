using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Common
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string CountryName { get; set; }
    }
}
