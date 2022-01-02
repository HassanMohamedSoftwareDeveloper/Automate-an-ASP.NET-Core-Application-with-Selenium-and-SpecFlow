using CommunityContentSubmissionPage.Specs.PageObject;

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
}
