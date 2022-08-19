using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
{
  builder.Entity<Animal>()
      .HasData(
          new Animal { AnimalId = 1, Name = "tulip", Species = "cat", Age = 7, Gender = "Female" },
          new Animal { AnimalId = 2, Name = "rose", Species = "Dog", Age = 10, Gender = "Female" },
          new Animal { AnimalId = 3, Name = "gouda", Species = "rat", Age = 2, Gender = "Female" },
          new Animal { AnimalId = 4, Name = "Pep pep", Species = "dog", Age = 4, Gender = "Male" },
          new Animal { AnimalId = 5, Name = "Bart", Species = "cat", Age = 22, Gender = "Male" }
      );
}
    }
}