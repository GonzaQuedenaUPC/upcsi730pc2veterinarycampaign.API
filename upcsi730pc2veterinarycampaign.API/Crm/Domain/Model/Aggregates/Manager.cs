using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Commands;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.ValueObjects;

namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;

public partial class Manager
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public int Status { get; private set; }
    
    public DateTime ApprovedAt { get; private set; }
    public DateTime ReportedAt { get; private set; }
    public DateTime ContactedAt { get; private set; }
    
    public AssignedSalesAgentId AgentId { get; private set; }
    public VeterinaryCampaignManagerId VeterinaryId { get; private set; }
    
    public int AssignedSalesAgentId => AgentId.AgentId;
    public Guid VeterinaryCampaignManagerId => VeterinaryId.Identifier;
    
    public Manager()
    {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Status = 0;
        
        this.ApprovedAt = new DateTime();
        this.ReportedAt = new DateTime();
        this.ContactedAt = new DateTime();
        
        this.AgentId = new AssignedSalesAgentId(0);
        this.VeterinaryId = new VeterinaryCampaignManagerId();
    }

    public Manager(CreateManagerCommand command)
    {
        this.FirstName = command.FirstName;
        this.LastName = command.LastName;
        
        this.Status = command.Status;

        this.ApprovedAt = new DateTime();
        this.ReportedAt = new DateTime();
        this.ContactedAt = new DateTime();
       
        this.AgentId = new AssignedSalesAgentId(command.AssignedSalesAgentId);
        this.VeterinaryId = new VeterinaryCampaignManagerId(command.VeterinaryCampaignManagerId);
    }
}