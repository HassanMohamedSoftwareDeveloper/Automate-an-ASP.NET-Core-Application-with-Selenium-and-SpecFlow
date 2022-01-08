using CommunityContentSubmissionPage.Specs.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CommunityContentSubmissionPage.Specs.PageObject;

public class SubmissionPageObjectModel
{
    #region Fields :
    private readonly WebDriverDriver webDriverDriver;
    #endregion
    #region CTORS :
    public SubmissionPageObjectModel(WebDriverDriver webDriverDriver)
    {
        this.webDriverDriver = webDriverDriver;
    }
    #endregion
    #region PROPS :
    private IWebElement UrlDivElement => GetWebElement(By.Id("UrlDiv"));
    public IWebElement UrlWebElement => GetWebElement(UrlDivElement, By.Id("Url"));
    public IWebElement UrlLabelWebElement => GetWebElement(UrlDivElement,By.TagName("label"));
    public string UrlLabel => UrlLabelWebElement.Text;

    private IWebElement TypeDivElement => GetWebElement(By.Id("TypeDiv"));
    public SelectElement TypeWebElement =>new(GetWebElement(TypeDivElement, By.Id("Type")));
    public IWebElement TypeLabelWebElement => GetWebElement(TypeDivElement, By.TagName("label"));
    public string TypeLabel => TypeLabelWebElement.Text;

    private IWebElement EMailDivElement => GetWebElement(By.Id("EMailDiv"));
    public IWebElement EMailWebElement => GetWebElement(EMailDivElement, By.Id("EMail"));
    public IWebElement EMailLabelWebElement => GetWebElement(EMailDivElement, By.TagName("label"));
    public string EMailLabel => EMailLabelWebElement.Text;

    private IWebElement DescriptionDivElement => GetWebElement(By.Id("DescriptionDiv"));
    public IWebElement DescriptionWebElement => GetWebElement(DescriptionDivElement, By.Id("Description"));
    public IWebElement DescriptionLabelWebElement => GetWebElement(DescriptionDivElement, By.TagName("label"));
    public string DescriptionLabel => DescriptionLabelWebElement.Text;


    private IWebElement PolicyDivElement => GetWebElement(By.Id("PolicyDiv"));
    public IWebElement AcceptPrivacyPolicyWebElement => GetWebElement(PolicyDivElement, By.Id("AcceptPrivacyPolicy"));

    public IWebElement SubmitButton => GetWebElement(By.Id("BtnSubmit"));
    public IWebElement ResetButton => GetWebElement(By.Id("BtnReset"));


    
    #endregion
    #region Helpers :
    private IWebElement GetWebElement(By by)
    {
        try
        {
            return webDriverDriver.WebDriver.FindElement(by);
        }
        catch (NoSuchElementException ex)
        {
            throw ex;
        }
    }
    private static IWebElement GetWebElement(IWebElement webElement,By by)
    {
        try
        {
            return webElement.FindElement(by);
        }
        catch (NoSuchElementException ex)
        {
            throw ex;
        }
    }
    #endregion
}
