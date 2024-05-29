using Microsoft.EntityFrameworkCore;

namespace GetPatientInfo.Models;

public class DbContextClass: DbContext
{
    protected readonly IConfiguration Configuration;

    public DbContextClass(IConfiguration configuration, DbContextOptions<DbContextClass> options) : base(options) 
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Patient> Patients => Set<Patient>();
}
