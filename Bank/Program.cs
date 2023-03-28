public class BankAccount
{
    private decimal balance;
    private Customer customer;

    public BankAccount(Customer customer, decimal balance)
    {
        this.customer = customer;
        this.balance = balance;
    }

    public void TransferMoneyTo(BankAccount destinationAccount, decimal amount)
    {
        // Invalid use of Law of Demeter
        destinationAccount.customer.NotifyTransfer(amount);
        
        this.balance -= amount;
        destinationAccount.balance += amount;
    }
}

public class Customer
{
    private string name;
    private string email;

    public Customer(string name, string email)
    {
        this.name = name;
        this.email = email;
    }

    public void NotifyTransfer(decimal amount)
    {
        Console.WriteLine($"Dear {name}, an amount of {amount} has been transferred to your account.");
        EmailSender.SendEmail(email, "Money transfer", $"An amount of {amount} has been transferred to your account.");
    }
}

public class EmailSender
{
    public static void SendEmail(string email, string subject, string body)
    {
        Console.WriteLine($"Email sent to {email} with subject '{subject}' and body '{body}'");
    }
}
