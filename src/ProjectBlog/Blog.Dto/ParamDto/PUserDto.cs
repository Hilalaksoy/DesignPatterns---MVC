using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dto.ParamDto
{
    public class PUserDto
    {
       
        [Required]
        [DisplayName("Adı")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Soyadı")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adı")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre")]
        [StringLength(256)]
        public string PasswordHash { get; set; }
    }
}
