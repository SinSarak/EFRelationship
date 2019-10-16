using EFRelationship.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFRelationship
{
    class EFContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameResource> GameResources { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(@"Data Source=./Sample.db;");
            optionsBuilder.UseSqlServer(@"Data Source=123;Initial Catalog=EFRelationship;Integrated Security=false;User ID=sa;Password=1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many
            modelBuilder.Entity<Game>()
                .HasMany(c => c.GameResources)
                .WithOne(e => e.Game)
                .IsRequired();
            //One to One
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Game)
                .WithOne(b => b.Account)
                .HasForeignKey<Game>(b => b.AccountId);

            //Many to Many
            modelBuilder.Entity<GameCategory>()
                .HasKey(gc => new { gc.GameId, gc.CategoryId });
            modelBuilder.Entity<GameCategory>()
                .HasOne(gc => gc.Game)
                .WithMany(c => c.GameCategories)
                .HasForeignKey(c => c.GameId);
            modelBuilder.Entity<GameCategory>()
                .HasOne(gc => gc.Category)
                .WithMany(g => g.GameCategories)
                .HasForeignKey(g => g.CategoryId);

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Username = "Account1", Status = 1 },
                new Account { Id = 2, Username = "Account2", Status = 1 },
                new Account { Id = 3, Username = "Account3", Status = 1 },
                new Account { Id = 4, Username = "Account4", Status = 1 }
            );

            modelBuilder.Entity<GameResource>().HasData(
                new GameResource { Id = 1, GameId = 1, path = "path1", type = "type1"},
                new GameResource { Id = 2, GameId = 1, path = "path2", type = "type1" },
                new GameResource { Id = 3, GameId = 1, path = "path3", type = "type1" },
                new GameResource { Id = 4, GameId = 2, path = "path4", type = "type1" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "Game1", Status = 1, AccountId = 1 },
                new Game { Id = 2, Name = "Game2", Status = 1, AccountId = 2 },
                new Game { Id = 3, Name = "Game3", Status = 1, AccountId = 3 },
                new Game { Id = 4, Name = "Game4", Status = 1, AccountId = 4 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category1", Status = 1 },
                new Category { Id = 2, Name = "Category2", Status = 1 },
                new Category { Id = 3, Name = "Category3", Status = 1 },
                new Category { Id = 4, Name = "Category4", Status = 1 }
            );

            modelBuilder.Entity<GameCategory>().HasData(
                new GameCategory { GameId = 1, CategoryId = 1 },
                new GameCategory { GameId = 1, CategoryId = 2 },
                new GameCategory { GameId = 1, CategoryId = 3 },
                new GameCategory { GameId = 2, CategoryId = 1 },
                new GameCategory { GameId = 2, CategoryId = 2 }
            );
        }
    }
}