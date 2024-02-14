namespace ConsoleApp3;

public interface IDb
{
    public bool AddUser(User user);
    public bool Login(User insertUser);
}

public class UseCase
{
    private readonly IDb _dbService;

    public UseCase(IDb dbService)
    {
        _dbService = dbService;
    }

    public bool Add(User user)
    {
        if (!user.CheckLogin() || !user.CheckPassword())
            return false;

        _dbService.AddUser(user);
        
        return true;
    }

    public bool Login(User user) =>
        _dbService.Login(user);
}