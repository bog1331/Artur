using System.ComponentModel.DataAnnotations;

namespace ConsoleApp3;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Login { set; get; }
    public string Password { set; get; }

    public bool CheckLogin() =>
        this.Login.Length >= 3;
    
    public bool CheckPassword() =>
        this.Password.Length >= 3;

}