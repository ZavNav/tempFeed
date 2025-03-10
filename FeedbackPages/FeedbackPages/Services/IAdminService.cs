using FeedbackPages.ViewModels;

namespace FeedbackPages.Services;

public interface IAdminService
{ 
    Task<bool> TryLogin(LoginViewModel admin);
}