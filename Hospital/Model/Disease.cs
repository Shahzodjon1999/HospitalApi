using Hospital.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Model
{
	public class Disease:EntityBase
	{
		public string Name { get; set; } = string.Empty;
	}
}
