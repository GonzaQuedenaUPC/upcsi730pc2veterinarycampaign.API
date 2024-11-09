using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Commands;

namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Services;

public interface IManagerCommandService
{
    Task<Manager?> Handle(CreateManagerCommand command);
}