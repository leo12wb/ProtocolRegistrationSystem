using System;
using System.Collections.Generic;

namespace ProtocolRegistrationSystem.Models
{
    public class Protocol
    {
        public int Id { get; set; }
        public required string Type { get; set; } 
        public required string Description { get; set; }
        public DateTime InputDate { get; set; }
        public DateTime Term { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
    }
}
