using Kolokwium2Poprawaa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2Poprawaa.Database;

public class DatabaseContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Backpack> Backpack { get; set; }
    public DbSet<Character_Titles> Character_Titles { get; set; }
    public DbSet<Character> Character { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Title> Title { get; set; }
    
    
    public DatabaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character{ID = 1, FirstName = "Krzysztof", LastName = "Agaciak", CurrentWeight = 73, MaxWeight = 100},
            new Character{ID = 2, FirstName = "Andrzej", LastName = "Jackowski", CurrentWeight = 72, MaxWeight = 100},
            new Character{ID = 3, FirstName = "Michał", LastName = "Krupiewski", CurrentWeight = 71, MaxWeight = 100}
        });
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item{ID = 1, Name = "Nóż", Weight = 1},
            new Item{ID = 2, Name = "Duży nóż", Weight = 10},
            new Item{ID = 3, Name = "Chleb", Weight = 1},
            new Item{ID = 4, Name = "Wędka", Weight = 2},
            new Item{ID = 5, Name = "Czapka", Weight = 1}
        });
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title{ID = 1, Name = "Żuk"},
            new Title{ID = 2, Name = "Robłów"},
            new Title{ID = 3, Name = "Kowal"},
            new Title{ID = 4, Name = "Marchewka"},
        });
        modelBuilder.Entity<Character_Titles>().HasData(new List<Character_Titles>
        {
            new Character_Titles{CharacterId = 1, TitleId = 4, AquiredAt = DateTime.Parse("2024-03-05")},
            new Character_Titles{CharacterId = 2, TitleId = 2, AquiredAt = DateTime.Parse("2024-03-02")},
            new Character_Titles{CharacterId = 3, TitleId = 1, AquiredAt = DateTime.Parse("2024-03-03")}
        });
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack{CharacterId = 1, ItemId = 1, Amount = 1},
            new Backpack{CharacterId = 2, ItemId = 1, Amount = 1},
            new Backpack{CharacterId = 3, ItemId = 1, Amount = 1},
            new Backpack{CharacterId = 1, ItemId = 3, Amount = 2},
            new Backpack{CharacterId = 2, ItemId = 3, Amount = 2},
            new Backpack{CharacterId = 3, ItemId = 3, Amount = 2},
            new Backpack{CharacterId = 1, ItemId = 5, Amount = 1},
            new Backpack{CharacterId = 2, ItemId = 4, Amount = 1},
            new Backpack{CharacterId = 3, ItemId = 2, Amount = 1},
        });
    }
}