using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Role:EntityBase
{
    public string Name { get; set; }=string.Empty;

    public Worker? Worker { get; set; }
    public Guid WorkerId { get; set; }
}
