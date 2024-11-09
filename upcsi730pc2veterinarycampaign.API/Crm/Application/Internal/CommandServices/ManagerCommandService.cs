using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Commands;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Repositories;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Services;
using upcsi730pc2veterinarycampaign.API.Shared.Domain.Repositories;

namespace upcsi730pc2veterinarycampaign.API.Crm.Application.Internal.CommandServices;

public class ManagerCommandService(IManagerRepository managerRepository, IUnitOfWOrk unitOfWOrk)
    : IManagerCommandService
{
    public async Task<Manager?> Handle(CreateManagerCommand command)
    {
       var manager = await managerRepository.FindByFirstNameAndLastNameAsync(command.FirstName, command.LastName);

       if (manager != null)
           throw new InvalidOperationException("Manager already exists.");

       if (command is { Status: > 1, AssignedSalesAgentId: <= 0 } && command.ContactedAt.Equals(null))
           throw new InvalidOperationException("Status cannot be assigned if the " +
                                               "manager is not contacted and assigned to an agent.");

       if (command.Status > 3 && command.ApprovedAt.Equals(null))
           throw new InvalidOperationException("Status cannot be assigned if the " + "manager is not approved.");
       
       manager = new Manager(command);

       if (manager.Status.Equals(0)) manager.Status = 1;

       try
       {
           await managerRepository.AddAsync(manager);
           await unitOfWOrk.CompleteAsync();
       }
       catch (Exception e)
       {
           return null;
       }

       return manager;
    }
}