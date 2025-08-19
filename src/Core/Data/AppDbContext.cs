using Microsoft.EntityFrameworkCore;
using motorbikes_rent_api.Core.Entities;
using motorbikes_rent_api.Core.Model;

namespace motorbikes_rent_api.Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<DasherEntity> Dashers { get; set; } = null!;
}