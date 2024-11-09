using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;
using upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Resources;

namespace upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Transform;

public class ManagerResourceFromEntityAssembler
{
    public static ManagerResource ToResourceFromEntity(Manager manager)
    {
        return new ManagerResource(manager.FirstName, manager.LastName, manager.Status, manager.ApprovedAt,
            manager.ReportedAt, manager.ContactedAt, manager.AssignedSalesAgentIdentifier, manager.VeterinaryCampaignManagerIdentifier);
    }
}