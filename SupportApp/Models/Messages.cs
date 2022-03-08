using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApp.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Email { get; set; }
        
        public string Phone { get; set; }

        public DateTime Data { get; set; }
    }
}
