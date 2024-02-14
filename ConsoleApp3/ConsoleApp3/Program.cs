using SQLitePCL;

namespace ConsoleApp3
{
    public class Program
    {
        private static UseCase _useCase;
        
        public static void Main(string[] args)
        {
            _useCase = new UseCase(new DbService());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите число 1-Вход; 2-Регистрация");
                EnterOptionNumber();
            }
        }

        private static void EnterOptionNumber()
        {
            switch (Console.ReadLine())
            {
                case "1": 
                    Login();
                    break;
                
                case "2":
                    Registration();
                    break;
                    
                default: 
                    return;
            };
        }
        
        private static void Registration()
        {
            User user;
            do
            {
                user = EnterUser();

            } while (!_useCase.Add(user));
            
            Console.WriteLine("Вы успешно зарегестрировались\nДля продолжение нажмите кнопку");
            Console.ReadKey();
        }

        private static void Login()
        {
            User user;
            
            
            do
            {
                user = EnterUser();

            } while (!_useCase.Login(user));
            
            Console.WriteLine("Вы успешно вошли\nДля продолжение нажмите кнопку");
            Console.ReadKey();
        }

        private static User EnterUser()
        {
            var user = new User();
            
            Console.Clear();
            
            Console.WriteLine("Введите логин");
            user.Login = Console.ReadLine() ?? "";
            
            Console.WriteLine("Введите пароль");
            user.Password = Console.ReadLine() ?? "";

            return user;
        }
    }
}