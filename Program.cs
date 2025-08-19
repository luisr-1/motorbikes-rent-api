using Microsoft.EntityFrameworkCore;
using motorbikes_rent_api.Controllers;
using motorbikes_rent_api.Core.Data;
using motorbikes_rent_api.Core.Repositories;
using motorbikes_rent_api.Core.Repositories.Interfaces;
using motorbikes_rent_api.Infrastructure.Serialization;
using motorbikes_rent_api.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDasherRepository, DasherRepository>();
builder.Services.AddScoped<IDasherService, DasherService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.TypeInfoResolverChain.Insert(0, ApiJsonContext.Default);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.Run();