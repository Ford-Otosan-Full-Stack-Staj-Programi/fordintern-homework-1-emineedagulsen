using Microsoft.EntityFrameworkCore;
namespace FordApi.Data.Context;
//Entity yapımı(STAFF.cs) kullanan bir AppDbContext yarattım ve Dbcontextten bir miras alma işlemi yaptım.
public class AppDbContext : DbContext
{
   public AppDbContext() { }
    //EF'teki DbContext'ten türüyo
    //DbContext nesnesi veritabanı işlemlerinin yapıldığı tüm işlemlerin birleştiği bir ortamdır 
    // ve db işlemlerini yönetmek için kullandığı ana nesnedir. 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    //Bu class'ın içinde DbSet türünde bir liste tanımlamamız gerek.
    //Burdaki <STAFF> entity layer (STAFF.cs) diğeri STAFF table name
    public DbSet<Staff> STAFF { get; set; }
    //Burdaki method
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
