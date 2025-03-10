using FeedbackPages.Data;
using FeedbackPages.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FeedbackPages.Services;

public class AdminService(DataContext context) : IAdminService
{
    public async Task<bool> TryLogin(LoginViewModel admin)
    {
        var foundAdmin = await context.Admins.FirstOrDefaultAsync(a => a.Login == admin.Login);

        if (foundAdmin == null)
            return false;
        
        return admin.Password == foundAdmin.Password;
    }
}