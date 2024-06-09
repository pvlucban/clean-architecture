namespace Clean_Architecture.Core.Domain;

public sealed class Company : WithAuditBaseEntity<Guid>

{
    public required string Name { get; set; }
}
