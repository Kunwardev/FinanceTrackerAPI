using FinanceTrackerAPI.DTO;

namespace FinanceTrackerAPI.Service;

public interface IUserService{
    Task<bool> registerUserAsync(UserDTO user);

    Task<string?> loginAsync(UserDTO user);

}