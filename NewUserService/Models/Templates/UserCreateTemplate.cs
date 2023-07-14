using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NewUserService.Models.Enums;

namespace NewUserService.Models.Templates;

public class UserCreateTemplate
{
    [RegularExpression(@"^[A-Za-z]{2,30}$", ErrorMessage = "The firstname field must be contain only characters and length must be more than 2 letters")]
    public string FirstName { get; init; }

    [RegularExpression(@"^[A-Za-z]{2,30}$", ErrorMessage = "The lastname field must be contain only characters and length must be more than 2 letters")]
    public string LastName { get; set; }

    [RegularExpression(@"^(Male|Female)$", ErrorMessage = "Gender Must be 'Male' or 'Female'")]
    public string Gender { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9]{8,30}$", ErrorMessage = "You entered invalid PASSPORT DATA")]
    public string PassportSerNum { get; set; }

    [RegularExpression(@"^\d{14}$", ErrorMessage = "The PINFL field must be 14 digits.")]
    public string PINFL { get; set; }
    
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter valid email")]
    public string Email { get; set; }
    
    [RegularExpression(@"^[a-zA-Z0-9_]{3,20}$", ErrorMessage = "Enter valid username")]
    public string Username { get; set; }

    [RegularExpression(@"^.{8,50}$", ErrorMessage = "Password must be more than or equal 8 symbols")]
    public string Password { set; get; }
}