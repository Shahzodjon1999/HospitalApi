﻿using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class DoctorPatient:EntityBase
{
	public Doctor? Doctor { get; set; }
	public Guid DoctorId { get; set; }

	public Patient? Patient { get; set; }
	public Guid PatientId { get; set; }
}
