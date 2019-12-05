using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Common
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public int CountryId { get; set; }
    }
}
