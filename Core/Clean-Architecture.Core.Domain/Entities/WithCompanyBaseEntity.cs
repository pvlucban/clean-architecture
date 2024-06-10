using System.ComponentModel.DataAnnotations.Schema;

namespace Clean_Architecture.Core.Domain;

public class WithCompanyBaseEntity<T> : WithAuditBaseEntity<T>
{
    public Guid CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public required Company company { get; set; }
}
