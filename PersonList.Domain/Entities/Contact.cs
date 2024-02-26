using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Domain.Entities
{
    public class Contact
    {
        public string phoneNumber { get; set; } = string.Empty;
        public string adress { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
