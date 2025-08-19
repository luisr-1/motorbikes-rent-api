using Microsoft.EntityFrameworkCore;
using motorbikes_rent_api.Core.Data;
using motorbikes_rent_api.Core.Entities;
using motorbikes_rent_api.Core.Mappers;
using motorbikes_rent_api.Core.Model;
using motorbikes_rent_api.Core.Repositories.Interfaces;

namespace motorbikes_rent_api.Core.Repositories;

public class DasherRepository : IDasherRepository
{
    private readonly AppDbContext _context;

    public DasherRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DasherEntity?> CreateAsync(DasherEntity? dasher)
    {
        if (dasher == null) return null;
        
        _context.Dashers.Add(dasher);
        await _context.SaveChangesAsync();
        return dasher;
    }

    public async Task<IEnumerable<Dasher?>> GetAllAsync()
    {
        var dashers = await _context.Dashers.ToListAsync();
        return dashers.Select(d => d.ToModel());
    }

    public async Task<DasherEntity?> GetByIdAsync(string id)
    {
        return await _context.Dashers.FirstOrDefaultAsync(d => d.Id == id);
    }
}