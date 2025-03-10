using System.ComponentModel.DataAnnotations;

namespace FeedbackPages.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Введите логин")]
    public string? Login { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль")]
    public string? Password { get; set; }
}