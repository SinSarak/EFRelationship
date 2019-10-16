using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFRelationship
{
    class Program
    {
        static void Main(string[] args)
        {
            EFContext db = new EFContext();

            //One to Many
            var model = db.Games.Include(p=>p.GameResources).Where(p=>p.Status == 1).ToList();

            //One to One
            var modelAccount = db.Accounts.Include(p=>p.Game).Where(p=>p.Status == 1).ToList();

            //Many to Many
            var modelGame = db.Games.Include(p=>p.GameCategories).Where(p=>p.Status == 1).ToList();
            var modelCategory = db.Categories.Include(p=>p.GameCategories).Where(p=>p.Status == 1).ToList();
            var modelGameCategory = db.GameCategories.Include(p=>p.Game).Include(p=>p.Category).ToList();
            Console.WriteLine("Hello World!");
        }
    }
}
