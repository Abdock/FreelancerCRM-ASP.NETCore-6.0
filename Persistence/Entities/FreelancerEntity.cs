using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;

namespace Persistence.Entities;

[Table("Freelancers")]
[Index(nameof(RowGuid), IsUnique = true, Name = "UX_Freelancers_RowGuid")]
public class FreelancerEntity : BasePersistenceEntity
{
    public FreelancerEntity()
    {
        Orders = new HashSet<OrderEntity>();
        Feedbacks = new HashSet<FeedbackEntity>();
        Skills = new HashSet<SkillEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    public UserAccountEntity Account { get; set; } = null!;
    public override Guid RowGuid { get; set; }
    public ICollection<OrderEntity> Orders { get; set; }
    public ICollection<FeedbackEntity> Feedbacks { get; set; }
    public ICollection<SkillEntity> Skills { get; set; }
}