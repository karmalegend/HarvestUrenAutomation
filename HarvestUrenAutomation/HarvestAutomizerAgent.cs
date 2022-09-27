using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace HarvestUrenAutomation;

public class HarvestAutomizerAgent
{
    private readonly WebDriver _webDriver;
    private readonly IConfiguration _configuration;
    
    public HarvestAutomizerAgent(WebDriver webDriver, IConfiguration configuration)
    {
        _webDriver = webDriver;
        _configuration = configuration;
    }

    public void LoginToZohoPeople()
    {
        _webDriver.Navigate().GoToUrl("ZoHoPeople:BaseLoginUrl");
        var email = _webDriver.FindElement(By.Id("login_id"));
        email.SendKeys(_configuration["User:Email"]);
        _webDriver.FindElement(By.Id("nextbtn")).Click();
    }
}
