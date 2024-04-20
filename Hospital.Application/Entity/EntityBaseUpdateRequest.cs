namespace Hospital.Application.Entity;

public abstract record EntityBaseUpdateRequest
{
    public Guid Id { get; set; }
}
