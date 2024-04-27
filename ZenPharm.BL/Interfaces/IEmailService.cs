using ZenPharm.BL.Implementations.Configs;

namespace ZenPharm.BL.Interfaces;

public interface IEmailService
{
    public EmailRequest FormEmailRequest(string? emailFrom,string emailTo, string subject, string body);
    public Task SendEmail(EmailRequest emailRequest);
}
