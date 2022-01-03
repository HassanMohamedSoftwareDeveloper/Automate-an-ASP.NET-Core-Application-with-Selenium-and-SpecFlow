using CommunityContentSubmissionPage.Specs.Drivers;
using CommunityContentSubmissionPage.Specs.PageObject;
using OpenQA.Selenium;

namespace CommunityContentSubmissionPage.Specs.StepDefinitions;

[Binding]
public class SubmissionSteps
{
    #region Fields :
    private readonly WebDriverDriver webDriverDriver;
    private readonly SubmissionPageDriver submissionPageDriver;
    #endregion

    #region CTORS :
    public SubmissionSteps(WebDriverDriver webDriverDriver,SubmissionPageDriver submissionPageDriver)
    {
        this.webDriverDriver = webDriverDriver;
        this.submissionPageDriver = submissionPageDriver;
    }
    #endregion

    #region Steps :
    [Then(@"it is possible to enter a '([^']*)' with label '([^']*)'")]
    public void ThenItIsPossibleToEnterAWithLabel(string inputType, string expectedLabel)
    {
        submissionPageDriver.CheckExistenceOfInput(inputType, expectedLabel);
    }
    [Then(@"Call Submit Button")]
    public void ThenCallSubmitButton()
    {
        submissionPageDriver.SubmitRequest();
    }
    #endregion

}
