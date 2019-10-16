using System;
using System.Collections.Generic;
using System.Text;

namespace EFRelationship.Domain
{
    class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public ICollection<GameResource> GameResources { get; set; }
        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
