using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Email {get; set;}
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
