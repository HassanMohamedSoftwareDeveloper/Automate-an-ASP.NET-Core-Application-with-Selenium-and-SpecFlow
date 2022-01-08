using System.ComponentModel.DataAnnotations;

namespace CommunityContentSubmissionPage.Validations;

public class BoolHasToBeTrueAttribute : ValidationAttribute
{
    private readonly string errorMessage;

    public BoolHasToBeTrueAttribute(string errorMessage= "The value has to be true")
    {
        this.errorMessage = errorMessage;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is null) return new ValidationResult(this.errorMessage);
        if (value is not bool) return new ValidationResult(errorMessage);
        var valueAsBool = value as bool?;
        if (valueAsBool is false) return new ValidationResult(errorMessage);
        return ValidationResult.Success;
    }
}
