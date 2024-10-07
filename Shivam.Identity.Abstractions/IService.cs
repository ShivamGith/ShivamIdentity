namespace Shivam.Identity.Abstractions
{
    public interface IService
    {
        Task<string> CreateUserAsync(CreateUserRequest user);
        Task<User> GetUserAsync(string id);
    }
}