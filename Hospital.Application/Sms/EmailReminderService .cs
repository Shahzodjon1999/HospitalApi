using Hospital.Application.InterfaceRepositoryes;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol.Core.Types;

namespace Hospital.Application.Sms;

public class EmailReminderService: BackgroundService
{
    private readonly IAppointmentRepository _repository;

    public EmailReminderService(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await SendReminderEmails();

            // Wait for 5 minutes before checking again
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }

    public async Task SendReminderEmails()
    {
        var getClients = _repository.GetAll();

        foreach (var item in getClients)
        {
            if (DateTime.Now > item.AppointmentDate.AddMinutes(-30))
            {
                string subject = "Appointment Reminder";
                string body = "This is a reminder that your appointment is scheduled in 30 minutes. Please be on time.";

                await SendEmail(item.Email, subject, body);

                // Update client record to indicate that email has been sent
                //item.EmailSent = true;
                //_repository.Update(item);
            }
        }
    }

    private async Task SendEmail(string recipientEmail, string subject, string body)
    {
        // Email sending logic remains the same
    }
}
