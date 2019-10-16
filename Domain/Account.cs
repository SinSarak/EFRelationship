using System;
using System.Collections.Generic;
using System.Text;

namespace EFRelationship.Domain
{
    class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Status { get; set; }

        public Game Game { get; set; }
    }
}
