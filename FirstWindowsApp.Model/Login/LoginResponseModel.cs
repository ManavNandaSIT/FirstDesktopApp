using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWindowsApp.Model.Login
{
    public class LoginResponseModel
    {
        public int UserId { get; set; }
        //public string EncryptedUserId { get; set; }
        public string FullName { get; set; }
        //public string Password { get; set; }    
        //public long MobileNo { get; set; }
        public string EmailId { get; set; }
        public string JWTToken { get; set; }
        public bool IsAdmin { get; set; }
        public long AdminRoleId { get; set; }
        public long CompanyId { get; set; }
        public string Photo { get; set; }
    }
}
