using System.ComponentModel.DataAnnotations.Schema;

namespace upcsi730pc2veterinarycampaign.API.Crm.Domain.Model.Aggregates;

public partial class Manager
{
    //The CreatedDate and UpdatedDate properties are used to store the date and time when the entity was
    //created and updated.
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}