using Microsoft.EntityFrameworkCore;
using MiniLibrary.Models;

namespace MiniLibrary.Database
{
    public class SystemDBContext : DbContext
    {
        public bool StartUpCheck = false;
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<Bookshelf> Bookshelves { get; set; }

        public SystemDBContext(DbContextOptions<SystemDBContext> options) : base(options)
        {
            UpdateDatabaseSchema();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemType>().ToTable("ItemTypes");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Bookshelf>().ToTable("Bookshelves");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        public void EnsureDatabaseCreated()
        {
            Database.EnsureCreated();
        }

        public void ApplyMigrations()
        {
            Database.Migrate();
        }

        public void StartUp()
        {
            if (!StartUpCheck)
                this.Database.EnsureCreated();
            StartUpCheck = true;
        }

        public void UpdateDatabaseSchema()
        {
            try
            {
                var pendingMigrations = this.Database.GetPendingMigrations();
                if (pendingMigrations.Any())
                {
                    this.Database.Migrate();
                    Console.WriteLine("Database schema updated successfully.");
                }
                else
                {
                    Console.WriteLine("Database schema is up to date.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the database schema: {ex.Message}");
            }
        }

    }
}
