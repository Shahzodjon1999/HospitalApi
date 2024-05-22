using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Hospital.Application.Sms;

public class SmsSender
{
    private const string TwilioAccountSid = "YOUR_TWILIO_ACCOUNT_SID";
    private const string TwilioAuthToken = "YOUR_TWILIO_AUTH_TOKEN";
    private const string TwilioPhoneNumber = "YOUR_TWILIO_PHONE_NUMBER";

    private const string GmailAddress = "Muhammadumirzoqov12@gmail.com";
    private const string GmailPassword = "Shahzodjon$$&&@1999";

    public static void SendSMS(string toPhoneNumber, string message)
    {
        TwilioClient.Init(TwilioAccountSid, TwilioAuthToken);

        var smsMessage = MessageResource.Create(
            body: message,
            from: new Twilio.Types.PhoneNumber(TwilioPhoneNumber),
            to: new Twilio.Types.PhoneNumber(toPhoneNumber)
        );

        Console.WriteLine($"SMS sent: {smsMessage.Sid}");
    }
    public static void SendEmail(string toEmail, string subject, string body)
    {
        var smtpClient = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(GmailAddress, GmailPassword)
        };

        using (var message = new MailMessage(GmailAddress, toEmail)
        {
            Subject = subject,
            Body = body
        })
        {
            smtpClient.Send(message);
            Console.WriteLine("Email sent successfully!");
        }
    }
}
