using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PersonList.Domain.Entities
{
    public class Person
    {
        public int id { get; set; }
        public string? firstName { get; set; } 
        public string? lastname { get; set; }
        public int age { get; set; }
        public Contact contact { get; set; } = new();
    }
}
