namespace Clean_Architecture.Core.Domain;

public record class Result<T>
{

    public bool Success { get; init; }
    public required string ErrorMessage { get; init; }
    public T? Data { get; init; }
}
