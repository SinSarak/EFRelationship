using System;
using System.Collections.Generic;
using System.Text;

namespace EFRelationship.Domain
{
    class GameCategory
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
