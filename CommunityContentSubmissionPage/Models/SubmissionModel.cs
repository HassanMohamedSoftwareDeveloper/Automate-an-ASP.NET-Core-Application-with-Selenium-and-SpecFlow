using System.ComponentModel;

namespace CommunityContentSubmissionPage.Models;

public class SubmissionModel
{
    [DisplayName("Url to content")]
    public string Url { get; set; }
    [DisplayName("Type of content")]
    public string Type { get; set; }
    [DisplayName("Your EMail address")]
    public string EMail { get; set; }
    [DisplayName("Description")]
    public string Description { get; set; }
}
