using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Role:EntityBase
{
    public string Name { get; set; }=string.Empty;

    public bool Status { get; set; }

    public Auth? Auths { get; set; }
}
