using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Commands;
using upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.ValueObjects;

namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;

public partial class Manager
{
    public int Id { get; }
    
    [Required]
    [StringLength(40, MinimumLength = 4, ErrorMessage = "FirstName must be between 4 and 40 characters.")]
    public string FirstName { get; private set; }
    
    [Required]
    [StringLength(40, MinimumLength = 4, ErrorMessage = "LastName must be between 4 and 40 characters.")]
    public string LastName { get; private set; }
    
    public int Status { get; set; }
    
    public DateTime ApprovedAt { get; private set; }
    public DateTime ReportedAt { get; private set; }
    public DateTime ContactedAt { get; private set; }
    
    [NotMapped]
    public AssignedSalesAgentId AgentId { get; private set; }
    [NotMapped]
    public VeterinaryCampaignManagerId VeterinaryId { get; private set; }
    
    public int AssignedSalesAgentIdentifier => AgentId.AgentId ;
    public Guid VeterinaryCampaignManagerIdentifier => VeterinaryId.Identifier;
    
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

        this.ApprovedAt = command.ApprovedAt;
        this.ReportedAt = command.ReportedAt ;
        this.ContactedAt = command.ContactedAt;
       
        this.AgentId = new AssignedSalesAgentId(command.AssignedSalesAgentId);
        this.VeterinaryId = new VeterinaryCampaignManagerId(command.VeterinaryCampaignManagerId);
    }
}