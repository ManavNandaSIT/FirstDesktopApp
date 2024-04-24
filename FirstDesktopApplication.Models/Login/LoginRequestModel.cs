using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDesktopApplication.Models.Login
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage ="Email field is required.")]
        [EmailAddress(ErrorMessage ="Please enter valid email.")]
        public string EmailId { get; set;}

        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set;}
    }
}
