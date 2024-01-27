using Hospital.Abstract;
using Hospital.Enam;
using System;
using System.Collections.Generic;

namespace Hospital.Models;

	public class Doctor:Person
	{
		public string Positions { get; set;} = string.Empty;
    
		public Gender Gender { get; set; }

		//public virtual List<Patient>? Patients { get; set; }

		//public List<Room>? Rooms { get; set; }

		public DateTime StartWork { get; set; }

		public DateTime EndWork { get; set; }

		public int statusFreeOrNot { get; set; }

	//public delegate void MessageDelegate(string message);

	//public event MessageDelegate? Notification;

	//public string GetInfo()
	//{
	//	return $"Doctor is Full Name : {FirstName} {LastName} {MidleName}\n Address: {Address}\n Contact:{PhoneNumber}\n Work Time's for today: From:{StartWork},To:{EndWork}";
	//}

	//public void Reservation(string? dateTimSave)
	//{
	//	if (dateTimSave == "18.01.2024 09:00:00")
	//	{
	//		Notification?.Invoke($"I am byse this time {dateTimSave};");
	//	}
	//	else
	//	{
	//		Notification?.Invoke($"I am free I can Acceptance this time {dateTimSave}");
	//	}
	//}

	//public void SendMessage(string message) => Console.WriteLine($"{message}");
}
