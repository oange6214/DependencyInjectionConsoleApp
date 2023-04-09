using ConfigServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new();

// 配置中心服務器 
services.AddLayeredConfig();

// 本地環境變數
services.AddScoped<IConfigService, EnvVarConfigService>();

// 本地配置檔
services.AddIniFileConfig(@"mail.ini");

services.AddConsoleLog();
services.AddScoped<IMailService, MailService>();

using (var sp = services.BuildServiceProvider())
{
    // 第一個的 root object 只能用 Service Locator
    var mailService = sp.GetRequiredService<IMailService>();
    mailService.Send("Hello", "hi6214@gmail.com", "Mr. Lin, 你好");

}