namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.ValueObjects;

public record VeterinaryCampaignManagerId
{
    public string ManagerId { get; }

    //Constructor sin parámetros que asigna un GUID por defecto como string
    public VeterinaryCampaignManagerId() : this(Guid.NewGuid().ToString())
    {
    }

    // Constructor principal con validación
    public VeterinaryCampaignManagerId(string managerId)
    {
        if (string.IsNullOrWhiteSpace(managerId))
        {
            throw new ArgumentException("Manager ID cannot be null or empty", nameof(managerId));
        }

        ManagerId = managerId;
    }
}