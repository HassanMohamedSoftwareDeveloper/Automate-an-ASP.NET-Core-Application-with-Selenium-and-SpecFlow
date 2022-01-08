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
    private readonly BrowserDriver browserDriver;
    #endregion

    #region CTORS :
    public SubmissionSteps(SubmissionPageDriver submissionPageDriver,SubmissionDriver submissionDriver,BrowserDriver browserDriver)
    {
        this.submissionPageDriver = submissionPageDriver;
        this.submissionDriver = submissionDriver;
        this.browserDriver = browserDriver;
    }
    #endregion

    #region Steps :
    [Then(@"it is possible to enter a '([^']*)' with label '([^']*)'")]
    public void ThenItIsPossibleToEnterAWithLabel(string inputType, string expectedLabel)
    {
        submissionPageDriver.CheckExistenceOfInput(inputType, expectedLabel);
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

    [Then(@"there is '(.*)' submission entry stored")]
    public void ThenThereIsSubmissionEntryStored(int expectedCountOfStoredEntries)
    {
        submissionDriver.AssertNumberOfEntriesStored(expectedCountOfStoredEntries);
    }
    [Then(@"there is a submission entry stored with the following data :")]
    public void ThenThereIsASubmissionEntryStoredWithTheFollowingData(Table table)
    {
       var expectedSubmissionEntry= table.CreateInstance<ExpectedSubmissionEntry>();
        submissionDriver.AssertSubmissionEntryData(expectedSubmissionEntry);
    }

    [Then(@"you can choose from the following Types:")]
    public void ThenYouCanChooseFromTheFollowingTypes(Table table)
    {
        var entries= table.CreateSet<EntryType>();
        submissionPageDriver.CheckTypeEntries(entries);
    }

    [Given(@"the submission entry form is filled")]
    public void GivenTheSubmissionEntryFormIsFilled()
    {
        submissionPageDriver.InputForm(new List<SubmissionEntryFormRowObject>
        {
            new SubmissionEntryFormRowObject{ Label="Url",Value="https://www.specflow.org"},
            new SubmissionEntryFormRowObject{ Label="Type",Value="Books"},
            new SubmissionEntryFormRowObject{ Label="Email",Value="HassanMohamed_Hm@Hotmail.com"},
            new SubmissionEntryFormRowObject{ Label="Description",Value="Test"},
        });
    }
    [Given(@"the privacy policy is not accepted")]
    public void GivenThePrivacyPolicyIsNotAccepted()
    {
        submissionPageDriver.DoNotAcceptPrivacyPolicy();
    }
    [Given(@"the privacy policy is accepted")]
    public void GivenThePrivacyPolicyIsAccepted()
    {
        submissionPageDriver.AcceptPrivacyPolicy();
    }

    [Then(@"the submittingg of data was possible")]
    public void ThenTheSubmittinggOfDataWasPossible()
    {
        browserDriver.Url.Should().EndWith("Success");
    }
    [Then(@"tthe submittingg of data was not possible")]
    public void ThenTtheSubmittinggOfDataWasNotPossible()
    {
        browserDriver.Url.Should().NotEndWith("Success");
    }

    [When(@"the form is reset")]
    public void WhenTheFormIsReset()
    {
        submissionPageDriver.ResetForm();
    }
    [Then(@"every input is set to its default values")]
    public void ThenEveryInputIsSetToItsDefaultValues()
    {
        submissionPageDriver.CheckDefaultValues();
    }


    #endregion

}
