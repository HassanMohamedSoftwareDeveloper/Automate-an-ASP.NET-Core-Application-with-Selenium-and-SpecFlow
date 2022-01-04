using CommunityContentSubmissionPage.Specs.PageObject;
using CommunityContentSubmissionPage.Specs.Support;
using OpenQA.Selenium;

namespace CommunityContentSubmissionPage.Specs.Drivers;

public class SubmissionPageDriver
{
    #region Fields :
    private readonly WebDriverDriver webDriverDriver;
    #endregion

    #region CTORS :
    public SubmissionPageDriver(WebDriverDriver webDriverDriver)
    {
        this.webDriverDriver = webDriverDriver;
    }
    #endregion
    public void CheckExistenceOfInput(string inputType, string expectedLabel)
    {
        var submissionPageObjectModel = new SubmissionPageObjectModel(webDriverDriver);
        switch (inputType.ToUpper())
        {
            case "URL":
                submissionPageObjectModel.UrlWebElement.Should().NotBeNull();
                submissionPageObjectModel.UrlLabel.Should().Be(expectedLabel);
                break;
            case "TYPE":
                submissionPageObjectModel.TypeWebElement.Should().NotBeNull();
                submissionPageObjectModel.TypeLabel.Should().Be(expectedLabel);
                break;
            case "EMAIL":
                submissionPageObjectModel.EMailWebElement.Should().NotBeNull();
                submissionPageObjectModel.EMailLabel.Should().Be(expectedLabel);
                break;
            case "DESCRIPTION":
                submissionPageObjectModel.DescriptionWebElement.Should().NotBeNull();
                submissionPageObjectModel.DescriptionLabel.Should().Be(expectedLabel);
                break;
            default:
                throw new NotImplementedException($"{inputType} not implemented.");
        }
    }

    public void InputForm(IEnumerable<SubmissionEntryFormRowObject> rows)
    {
        var submissionPageObjectModel = new SubmissionPageObjectModel(webDriverDriver);
        foreach (var row in rows)
        {
            switch (row.Label.ToUpper())
            {
                case "URL":
                    submissionPageObjectModel.UrlWebElement.Clear();
                    submissionPageObjectModel.UrlWebElement.SendKeys(row.Value);
                    break;
                case "TYPE":
                    submissionPageObjectModel.TypeWebElement.Clear();
                    submissionPageObjectModel.TypeWebElement.SendKeys(row.Value);
                    break;
                case "EMAIL":
                    submissionPageObjectModel.EMailWebElement.Clear();
                    submissionPageObjectModel.EMailWebElement.SendKeys(row.Value);
                    break;
                case "DESCRIPTION":
                    submissionPageObjectModel.DescriptionWebElement.Clear();
                    submissionPageObjectModel.DescriptionWebElement.SendKeys(row.Value);
                    break;
                default:
                    throw new NotImplementedException($"{row.Label} not implemented.");
            }
        }
       
    }

    public void SubmitRequest()
    {
        var submissionPageObjectModel = new SubmissionPageObjectModel(webDriverDriver);
        var action=()=> submissionPageObjectModel.SubmitButton.Click();
        action.Should().NotThrow<NoSuchElementException>();
    }
    public void SubmitForm()
    {
        var submissionPageObjectModel = new SubmissionPageObjectModel(webDriverDriver);
        submissionPageObjectModel.SubmitButton.Click();
    }
}
