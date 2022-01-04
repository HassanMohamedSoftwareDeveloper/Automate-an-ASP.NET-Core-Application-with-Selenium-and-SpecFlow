using CommunityContentSubmissionPage.Specs.Drivers;
using CommunityContentSubmissionPage.Specs.PageObject;
using CommunityContentSubmissionPage.Specs.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;

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


    [Given(@"the filled out submission entry form")]
    public void GivenTheFilledOutSubmissionEntryForm(Table table)
    {
       var rows= table.CreateSet<SubmissionEntryFormRowObject>();
        submissionPageDriver.InputForm(rows);
    }

    [When(@"the submission entry form is submitted")]
    public void WhenTheSubmissionEntryFormIsSubmitted()
    {
       submissionPageDriver.SubmitForm();
    }

    [Then(@"there is a new submission entry stored")]
    public void ThenThereIsANewSubmissionEntryStored()
    {
        throw new PendingStepException();
    }


    #endregion

}
