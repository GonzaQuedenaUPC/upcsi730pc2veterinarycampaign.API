namespace upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Resources;

public record ManagerResource(string FirstName, string LastName, int Status, DateTime ApprovedAt, DateTime ReportedAt,
    DateTime ContactedAt, int AssignedSalesAgentId, Guid VeterinaryCampaignManagerId);