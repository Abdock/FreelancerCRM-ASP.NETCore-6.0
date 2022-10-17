using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Feedbacks")]
[Index(nameof(RowGuid), IsUnique = true, Name = "UX_Feedbacks_RowGuid")]
public class FeedbackEntity : BasePersistenceEntity
{
    public FeedbackEntity()
    {
        CreationDate = DateTime.Today;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [MaxLength(256)]
    public string Title { get; set; } = default!;

    [MaxLength(8192)]
    public string Comment { get; set; } = default!;

    [Precision(5, 2)]
    public decimal Grade { get; set; }

    public DateTime CreationDate { get; set; }
    public override Guid RowGuid { get; set; }

    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }

    [ForeignKey(nameof(Freelancer))]
    public int FreelancerId { get; set; }

    public OrderEntity Order { get; set; } = default!;
    public ClientEntity Client { get; set; } = default!;
    public FreelancerEntity Freelancer { get; set; } = default!;
}