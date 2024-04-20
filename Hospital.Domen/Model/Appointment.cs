﻿using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Appointment : EntityBase
{
    public  Doctor? Doctor { get; set; }
	
	public Guid DoctorId { get; set; }

    public string Name { get; set; }=string.Empty;

	public DateTime AppointmentDate { get; set; }
}
