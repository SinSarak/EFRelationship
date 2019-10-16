using System;
using System.Collections.Generic;
using System.Text;

namespace EFRelationship.Domain
{
    class GameResource
    {
        public int Id { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
