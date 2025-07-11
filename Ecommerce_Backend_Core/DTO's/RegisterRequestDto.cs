using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Backend_Core.DTO_s
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int GovermentCode { get; set; }
        public int CityCode { get; set; }
        public int ZoneCode { get; set; }
        public int CustomerClassificationId { get; set; }
    }
}
