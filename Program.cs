using System;
using System.Collections.Generic;
using System.Security.Principal;

class SMSLowBalanceNotifyer : INotifyer
{
    private string _phone;
    private decimal _lowBalanceValue;
    public SMSLowBalanceNotifyer(string phone, decimal lowBalanceValue)
    {
        _phone = phone;
        _lowBalanceValue = lowBalanceValue;
    }

    public void Notify(decimal balance)
    {
        if (balance < _lowBalanceValue)
            Console.WriteLine($"SMSLowBalanceNotifier {balance}");
    }
}

class EMailBalanceChangedNotifyer : INotifyer
{
    public void Notify(decimal balance)
    {
        Console.WriteLine($"EMailBalanceChangedNotifier {balance}");
    }

    private string _email;
    public EMailBalanceChangedNotifyer(string email)
    {
        _email = email;
    }
}

interface INotifyer
{
    public void Notify(decimal balance);

}

class Account
{
    private decimal _balance;
    private List<INotifyer> _notifier;
    private void Notification()
    {
        for (int i = 0; i < _notifier.Count; i++)
        {
            _notifier[i].Notify(_balance);
            // Console.WriteLine($"SMSLowBalanceNotifier {_notifier[i]}");

        }
    }

    public Account()
    {
        _balance = 0;
        _notifier = new List<INotifyer>(10);
    }

    public Account(decimal balance)
    {
        _balance = balance;
        _notifier = new List<INotifyer>(10);
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void AddNotifyer(INotifyer notifyer)
    {
        _notifier.Add(notifyer);
    }

    public void ChangeBalance(decimal value)
    {
        _balance = value;
        Notification();
    }
}

class Notify
{
    public static int Main()
    {
        string phone = "89139466171";
        string email = "user@mail.ru";
        Account account = new Account(100);
        SMSLowBalanceNotifyer smsNotifyer = new SMSLowBalanceNotifyer(phone, 1000);
        EMailBalanceChangedNotifyer emailNotifyer = new EMailBalanceChangedNotifyer(email);
        account.AddNotifyer(smsNotifyer);
        account.AddNotifyer(emailNotifyer);
        account.ChangeBalance(200);

        return 0;
    }
}