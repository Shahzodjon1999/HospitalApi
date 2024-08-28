using Hospital.Domen.Abstract;
namespace Hospital.Domen.Model;

public class Worker : Person
{
    public Auth? Auth { get; set; }

    public Role? Role { get; set; }

    public Salary? Salary { get; set; }

    public Position? Position { get; set; }
    
    public Guid PositionId { get; set; }
}
