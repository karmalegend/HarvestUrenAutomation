using HarvestUrenAutomation.Exceptions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HarvestUrenAutomation;

public class HarvestAutomizerAgent
{
    private readonly WebDriver _webDriver;
    private readonly IConfiguration _configuration;
    private readonly string _email;
    private readonly string _password;
    private readonly WebDriverWait _wait;

    public HarvestAutomizerAgent(WebDriver webDriver, IConfiguration configuration)
    {
        _webDriver = webDriver;
        _configuration = configuration;
        _email = _configuration["User:Email"];
        _password = _configuration["User:Password"];
        _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
    }

    public void LoginToZohoPeople()
    {
        _webDriver.Navigate().GoToUrl(_configuration["ZoHoPeople:BaseLoginUrl"]);

        var emailField = _webDriver.FindElement(By.Id("login_id"));
        emailField.SendKeys(_email);
        _webDriver.FindElement(By.Id("nextbtn")).Click();

        _wait.Until(e => e.FindElement(By.Id("identifierId")));

        // we dont want to input login information to shady websites
        if (_webDriver.Url.StartsWith("https://accounts.google.com/"))
            _webDriver.FindElement(By.Id("identifierId")).SendKeys(_email);
        else throw new InvalidDomainException(_webDriver.Title);

        _webDriver.FindElement(By.Id("identifierNext")).Click();
        _wait.Until(e => e.FindElement(By.XPath(@"//*[@id='password']/div[1]/div/div[1]/input")))
            .SendKeys(_password);

        
        // for whatever reason google needs quite some time to fully init the page
        Thread.Sleep(3000);
        _webDriver.FindElement(By.Id("passwordNext")).Click();

        TimeTrackerManager();
    }

    private void TimeTrackerManager()
    {
        // so many scuffed slow page loads
        new WebDriverWait(_webDriver, TimeSpan.FromSeconds(600)).Until(e =>
            e.FindElement(By.XPath(@"//*[@id='serviceMainDv']/div[2]/div[2]")));
        
        Thread.Sleep(6000);

        _webDriver.FindElement(By.XPath(@"//*[@id='serviceMainDv']/div[2]/div[2]")).Click();

        for (var i = 0; i < 5; i++)
        {
            _wait.Until(e => e.FindElement(By.Id("addtimelogbutton")));
            Thread.Sleep(2500);
            _webDriver.FindElement(By.Id("addtimelogbutton")).Click();
            TrackTime(i);
        }
    }

    private void TrackTime(int offset)
    {
        _wait.Until(e => e.FindElement(By.CssSelector("#s2id_timelogProject > a:nth-child(1)"))).Click();
        _webDriver.FindElement(By.XPath("/html/body/div[14]/ul/li[2]/div/span")).Click(); //TODO:  it dies here
        _webDriver.FindElement(By.Id("zp_field_669929000000064689"))
            .SendKeys(DateTime.Now.AddDays(-offset).ToString("DD/MM/YYYY"));
        _webDriver.FindElement(By.Id("timelog_hrstime")).SendKeys("8");
        _webDriver.FindElement(By.Id("zp_forms_add_btn")).Click();
    }
}
