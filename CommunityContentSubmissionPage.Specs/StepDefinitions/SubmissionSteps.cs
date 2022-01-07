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

    #endregion

}
public class EntryType
{
    public string TypeName { get; set; }
}
public class ExpectedSubmissionEntry
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}
