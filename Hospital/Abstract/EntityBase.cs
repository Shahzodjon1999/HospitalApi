namespace Hospital.Abstract;

public abstract class EntityBase
{
	public Guid Id { get; set; } = Guid.NewGuid();
}
