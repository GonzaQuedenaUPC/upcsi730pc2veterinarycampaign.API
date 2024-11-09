using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;
using upcsi730pc2veterinarycampaign.API.Shared.Domain.Repositories;

namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Repositories;

public interface IManagerRepository : IBaseRepository<Manager>
{
    Task<Manager?> FindByFirstNameAndLastNameAsync(string firstName, string lastName);
}