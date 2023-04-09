using ConfigServices;
using LogServices;

namespace MailServices;

public class MailService : IMailService
{
    private readonly ILogProvider _log;
    //private readonly IConfigService _config;
    private readonly IConfigReader _config;

    public MailService(ILogProvider log, IConfigReader config)
    {
        _log = log;
        _config = config;
    }

    public void Send(string title, string to, string body)
    {
        _log.LogInfo("Ready to send email");

        string smtpServer = _config.GetValue("SmtpServer");
        string userName = _config.GetValue("UserName");
        string password = _config.GetValue("Password");

        Console.WriteLine($"郵件伺服器地址 {smtpServer}, {userName}, {password}");
        Console.WriteLine($"發送郵件! {title}, {to}");
        _log.LogInfo("Send email completed");
    }
}