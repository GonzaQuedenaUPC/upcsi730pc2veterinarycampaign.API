using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Repositories;
using upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using upcsi730pc2veterinarycampaign.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace upcsi730pc2veterinarycampaign.API.Crm.Infrastructure.Persistence.EFC.Repositories;

public class ManagerRepository(AppDbContext context)
    : BaseRepository<Manager>(context), IManagerRepository
{
    public async Task<Manager?> FindByFirstNameAndLastNameAsync(string firstName, string lastName)
    {
        return Context.Set<Manager>().FirstOrDefault(m => m.FirstName == firstName && m.LastName == lastName);
    }
}