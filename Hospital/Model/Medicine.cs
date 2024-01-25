using Hospital.Abstract;

namespace Hospital.Model
{
	public class Medicine:EntityBase
	{
		public string Name { get; set; } = string.Empty;

		public string Location { get; set; } = string.Empty;
	}
}
