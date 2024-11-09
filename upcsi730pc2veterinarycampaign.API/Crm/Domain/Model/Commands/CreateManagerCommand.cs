namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Commands;

public record CreateManagerCommand(string FirstName, string LastName, int Status, DateTime ApprovedAt, 
    DateTime ReportedAt, DateTime ContactedAt, int AssignedSalesAgentId, Guid VeterinaryCampaignManagerId);
    