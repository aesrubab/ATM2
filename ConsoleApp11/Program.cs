using System;

public class ATM
{
    private int balance;
    private string pin;
    private int pinAttemptCount;

    public ATM(string _pin, int _balance)
    {
        pin = _pin;
        balance = _balance;
        pinAttemptCount = 0;
    }

    private bool CheckPin()
    {
        if (pinAttemptCount >= 3)
        {
            Console.WriteLine("Account is locked ");
            return false;
        }

        Console.WriteLine("Enter Pin:");
        string enteredPin = Console.ReadLine();

        if (enteredPin == pin)
        {
            pinAttemptCount = 0; 
            return true;
        }
        else
        {
            pinAttemptCount++;
            Console.WriteLine("Incorrect Pin");
            return false;
        }
    }

    public void ShowBalance()
    {
        if (CheckPin())
        {
            Console.WriteLine($"Balance: {balance}");
        }
    }

    public void Cashout()
    {
        if (CheckPin())
        {
            Console.WriteLine("Amount: ");
            int amount;
            if (int.TryParse(Console.ReadLine(), out amount))
            {
                if (amount > balance)
                {
                    Console.WriteLine("Invalid amount");
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine($"Balance: {balance}");
                }
            }
   
        }
    }

    public void CashIn()
    {
        if (CheckPin())
        {
            Console.WriteLine("amount: ");
            int amount;
            if (int.TryParse(Console.ReadLine(), out amount))
            {
                balance += amount;
                Console.WriteLine($"balance: {balance}");
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }
    }

    public void ChangePin()
    {
        if (CheckPin())
        {
            Console.WriteLine("Enter new Pin:");
            string newPin = Console.ReadLine();
            pin = newPin;
            Console.WriteLine("Pin changed");
        }
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("__Menu:__");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. CashOut");
            Console.WriteLine("3. CashIn");
            Console.WriteLine("4. Change PIN");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowBalance();
                    break;
                case "2":
                    CashIn();
                    break;
                case "3":
                    Cashout();
                    break;
                case "4":
                    ChangePin();
                    break;
                case "5":
                    return; 
                default:
                    Console.WriteLine("Incorrect choise");
                    break;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ATM atm = new ATM("1234", 1000);
        atm.MainMenu();
    }
}

