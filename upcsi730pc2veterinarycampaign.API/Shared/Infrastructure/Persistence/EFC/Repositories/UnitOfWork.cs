using upcsi730pc2veterinarycampaign.API.Shared.Domain.Repositories;
using upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWOrk
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}