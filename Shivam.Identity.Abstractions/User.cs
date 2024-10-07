using Microsoft.AspNetCore.Identity;

namespace Shivam.Identity.Abstractions;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}
