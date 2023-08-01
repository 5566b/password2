using System;

public class WrongLoginException : Exception
{
    public WrongLoginException() : base() { }

    public WrongLoginException(string message) : base(message) { }
}

public class WrongPasswordException : Exception
{
    public WrongPasswordException() : base() { }

    public WrongPasswordException(string message) : base(message) { }
}

public class UserRegistration
{
    public static bool CheckRegistrationData(string login, string password, string confirmPassword)
    {
        if (login.Length >= 20 || login.Contains(" "))
        {
            throw new WrongLoginException("Invalid login");
        }

        if (password.Length >= 20 || password.Contains(" ") || !ContainsDigit(password))
        {
            throw new WrongPasswordException("Invalid password");
        }

        if (password != confirmPassword)
        {
            throw new WrongPasswordException("Passwords do not match");
        }

        return true;
    }

    private static bool ContainsDigit(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
         
        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter login: ");
            string login = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Confirm password: ");
            string confirmPassword = Console.ReadLine();

            bool isValid = UserRegistration.CheckRegistrationData(login, password, confirmPassword);

            Console.WriteLine("Registration data is valid: " + isValid);
        }
        catch (WrongLoginException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (WrongPasswordException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unknown error: " + ex.Message);
        }
    }
}