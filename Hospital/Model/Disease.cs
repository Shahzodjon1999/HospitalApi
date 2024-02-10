using Hospital.Abstract;

namespace Hospital.Model
{
	public class Disease:EntityBase
	{
		public string Name { get; set; } = string.Empty;

		public List<Medicine>? Medicines { get; set; }
	}
}
