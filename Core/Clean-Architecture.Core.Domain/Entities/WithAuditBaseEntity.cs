using System.ComponentModel.DataAnnotations;

namespace Clean_Architecture.Core.Domain;

public class WithAuditBaseEntity<T> : BaseEntity<T>
{

    [MaxLength(256)]
    public required string CreatedBy { get; set; }
    [MaxLength(256)]
    public string? UpdatedBy { get; set; }

    public required DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public int Version { get; set; }

}
