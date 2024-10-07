using System.Text.RegularExpressions;
using Shivam.Identity.Abstractions;

namespace Shivam.Identity.Service;

public class Service : IService
{
    public Service()
    {
    }

    public async Task<string> CreateUserAsync(CreateUserRequest request)
    {
        await ValidateUserAsync(request);
        // Logic to create user
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = passwordHash
        };
        // Save user to data source (e.g., database)
        await SaveUserAsync(user);
        return "User created successfully";
    }

    public async Task<User> GetUserAsync(string id)
    {
        // Logic to get user
        await Task.CompletedTask;
        return new User
        {
            Id = id,
            FirstName = "Shivam",
            LastName = "Kumar",
            UserName = "ShivamKumar",
            Email = "shivam@example.com", // Ensure valid email format
            PhoneNumber = "1234567890", // Set a valid phone number
            PasswordHash = "hashedPassword" // Set a valid password hash
        };
    }
    private static async Task SaveUserAsync(User user)
    {
        // Logic to save user to data source
        await Task.CompletedTask;
    }
    private async Task ValidateUserAsync(CreateUserRequest user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            throw new ArgumentNullException(nameof(user.FirstName));
        }
        if (string.IsNullOrWhiteSpace(user.LastName))
        {
            throw new ArgumentNullException(nameof(user.LastName));
        }
        if (!IsValidEmail(user.Email))
        {
            throw new ArgumentException("Invalid email format", nameof(user.Email));
        }
        if (!IsValidPhoneNumber(user.PhoneNumber))
        {
            throw new ArgumentException("Invalid phone number format", nameof(user.PhoneNumber));
        }
        if (!IsValidPassword(user.Password))
        {
            throw new ArgumentException("Invalid password format", nameof(user.Password));
        }
        await Task.CompletedTask;
    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        try
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
            return emailRegex.IsMatch(email);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return false;
        }

        try
        {
            var phoneRegex = new Regex(@"^\+?[1-9]\d{1,14}$", RegexOptions.Compiled); // E.164 format
            return phoneRegex.IsMatch(phoneNumber);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
    private static bool IsValidPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        try
        {
            // Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", RegexOptions.Compiled);
            return passwordRegex.IsMatch(password);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}