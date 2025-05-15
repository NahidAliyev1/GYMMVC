using GymMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GymMVC.Contexts;

public class AppDbContext:DbContext
{
    public DbSet<ChooseProgram> ChoosePrograms { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=GYMDB;Trusted_Connection=True;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }

}
