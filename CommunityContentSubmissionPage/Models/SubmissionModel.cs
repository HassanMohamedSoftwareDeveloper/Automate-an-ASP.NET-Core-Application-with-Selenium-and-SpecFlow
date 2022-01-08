using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CommunityContentSubmissionPage.Validations;

namespace CommunityContentSubmissionPage.Models;

public class SubmissionModel
{
    [DisplayName("Url to content")]
    [Required]
    [Url]
    public string Url { get; set; }
    [Required]
    [DisplayName("Type of content")]
    public string Type { get; set; }
    [Required]
    [DisplayName("Your EMail address")]
    [EmailAddress]
    public string EMail { get; set; }
    [Required]
    [DisplayName("Description")]
    public string Description { get; set; }
    [DisplayName("You need to accept our privacy to be able to submit an entry")]
    [Required]
    [BoolHasToBeTrue]
    public bool AcceptPrivacyPolicy { get; set; }
}
