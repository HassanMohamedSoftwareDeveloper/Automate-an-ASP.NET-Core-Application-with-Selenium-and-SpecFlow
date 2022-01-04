using CommunityContentSubmissionPage.Specs.Drivers;
using CommunityContentSubmissionPage.Specs.Support;
using TechTalk.SpecFlow.Assist;

namespace CommunityContentSubmissionPage.Specs.StepDefinitions;

[Binding]
public class SubmissionSteps
{
    #region Fields :
    private readonly SubmissionPageDriver submissionPageDriver;
    private readonly SubmissionDriver submissionDriver;
    #endregion

    #region CTORS :
    public SubmissionSteps(SubmissionPageDriver submissionPageDriver,SubmissionDriver submissionDriver)
    {
        this.submissionPageDriver = submissionPageDriver;
        this.submissionDriver = submissionDriver;
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

    [Then(@"there is one submission entry stored")]
    public void ThenThereIsANewSubmissionEntryStored()
    {
        submissionDriver.AssertOneSubmissionEntryExists();
    }


    #endregion

}
