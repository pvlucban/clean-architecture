
namespace Clean_Architecture.Core.Domain;

public class BaseEntity<T>
{
    public required T Id { get; set; }
}
