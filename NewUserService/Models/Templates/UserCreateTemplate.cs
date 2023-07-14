using NewUserService.Models.Enums;

namespace NewUserService.Models.Templates;

public class UserCreateTemplate
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Gender { get; set; }

    public string PassportSerNum { get; set; }

    public string PINFL { get; set; }
    
    public string Email { get; set; }
    
    public string Username { get; set; }

    public string Password { set; get; }
}