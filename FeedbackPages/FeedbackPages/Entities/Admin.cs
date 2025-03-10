namespace FeedbackPages.Entities;

public class Admin(string login, string password, string role)
{
    public int Id { get; set; }
    public string Login { get; set; } = login;
    public string Password { get; set; } = password;
    public string Role { get; set; } = role;
}