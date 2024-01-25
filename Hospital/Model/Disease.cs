using Hospital.Abstract;
using System;

namespace Hospital.Model
{
	public class Disease:EntityBase
	{
		public string Name { get; set; } = string.Empty;

		public Guid DoctorId { get; set; }
	}
}
