using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Position : EntityBase
{
    public string Name { get; set; }=string.Empty;

    public List<Worker>? Workers { get; set; }
}
