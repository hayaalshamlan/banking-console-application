// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

Console.WriteLine("Welcome to the basic banking application");
Console.WriteLine("Plase enter your name:");
string name = Console.ReadLine();
Console.WriteLine("Enter your account number");
int accountNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter your intial deposit");
double balance = double.Parse(Console.ReadLine());

Account myAccount = new Account(name, accountNumber, balance);
Console.WriteLine("Account setup successful!");

Transaction[] transactions = new Transaction[100];
int transactionCount = 0;

int choice;
do
{
    Console.WriteLine("\n Main Menu:");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. withdraw");
    Console.WriteLine("3. View balance");
    Console.WriteLine("4. List Transactions");
    Console.WriteLine("5. Exit");
    Console.WriteLine("Please select an option:");
    choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.WriteLine("Enter deposit amount");
        double depositAmount = double.Parse(Console.ReadLine());
        myAccount.Deposit(depositAmount);
        Console.WriteLine($"deposit of {depositAmount} successfully");

        transactions[transactionCount++] = new Transaction("Deposit", depositAmount);

    }
    else if (choice == 2)
    {
        Console.WriteLine("enter withdraw amount");
        double withdrawAmount = double.Parse(Console.ReadLine());
        if (myAccount.Withdraw(withdrawAmount))
        {
            //myAccount.Balance -= withdrawAmount;
            Console.WriteLine($"withraw of {withdrawAmount} successfully");
            transactions[transactionCount++] = new Transaction("Withraw", withdrawAmount);
        }
        else
        {
            Console.WriteLine("failed");
        }
    }
    else if (choice == 3)
    {
        Console.WriteLine($"current balance: {myAccount.GetBalance()}");
    }

    else if (choice == 4)
    {
        Console.WriteLine("\nTransaction History:");
        for (int i = 0; i < transactionCount; i++)
        {
            Console.WriteLine($"{i + 1}. {transactions[i].Type}: {transactions[i].Amount}");
        }
    }
    else if (choice == 5)
    {
        Console.WriteLine("try again");
    }
} while (choice != 5);
        


    
 

public class Account
{
    public string Name { get; set; }
    public int AccountNumber { get; set; }
    private double balance;
    public Account(string name, int accountNumber, double balance) {
        Name = name;
        AccountNumber = accountNumber;
        this.balance = balance;
    }
    public void Deposit(double amount)
    {
        balance = amount;
    }
    public bool Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }
    public double GetBalance()
    { 
        return balance; 
    }


}

public  class Transaction
{
    public string Type { get; set; }
public double Amount { get; set; }  

public Transaction(string type, double amount)
{
    Type = type;
    Amount = amount;
}
}


public class BankAccount
{
    private string name;
    private int accountNumber;
    private double balance;

    public BankAccount(string name, int accountNumber, double balance)
    {
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }
    public void Deposit(double amount)
    {
        balance = amount;
    }
    public bool Withdraw(double amount)
    {
        if (amount <= balance)

        {
            balance -= amount;
            return true;
        }
        return false;
    }
    public double GetBalance()
    {
        return balance;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }
}
