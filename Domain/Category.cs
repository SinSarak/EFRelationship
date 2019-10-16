using System;
using System.Collections.Generic;
using System.Text;

namespace EFRelationship.Domain
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
