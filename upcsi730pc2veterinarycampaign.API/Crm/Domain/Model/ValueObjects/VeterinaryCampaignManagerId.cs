namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.ValueObjects;

public record VeterinaryCampaignManagerId(Guid Identifier)
{
    /// <summary>
    /// Default constructor for the asset identifier. 
    /// </summary>
    public VeterinaryCampaignManagerId() : this(Guid.NewGuid())
    {
    }
}