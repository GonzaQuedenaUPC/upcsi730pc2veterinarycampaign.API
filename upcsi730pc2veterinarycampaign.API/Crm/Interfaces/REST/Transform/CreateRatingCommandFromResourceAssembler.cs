using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Commands;
using upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Resources;

namespace upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Transform;

public class CreateRatingCommandFromResourceAssembler
{
    public static CreateManagerCommand ToCommandFromResource(CreateRatingResource resource)
    {
        return new CreateManagerCommand(resource.FirstName, resource.LastName, resource.Status, resource.ApprovedAt,
            resource.ReportedAt, resource.ContactedAt, resource.AssignedSalesAgentId, new Guid());
    }
}