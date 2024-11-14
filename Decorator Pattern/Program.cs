
using System;
using System.Collections.Generic;
using System.Security.Claims;


public interface INotifier
{
    void Send(string message);
}






    public class SMS : Decorator
    {
        public SMS(INotifier Notifier) : base(Notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }





    public class Facebook : Decorator
    {
        public Facebook(INotifier Notifier) : base(Notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Отправка сообщения на Facebook: {message}");
        }
    }





public abstract class Decorator : INotifier
{
    protected INotifier _Notifier;

    public Decorator(INotifier Notifier)
    {
        _Notifier = Notifier;
    }

    public virtual void Send(string message)
    {
        _Notifier.Send(message);
    }
}




public class Class : INotifier
{
    private List<string> _EmailList;

    public Class(List<string> EmailList)
    {
        _EmailList = EmailList;
    }

    public void Send(string message)
    {
        foreach (var email in _EmailList) Console.WriteLine($"email отправлен на {email}: {message}");
    }
}




















public class Program
{
    public static void Main(string[] args)
    {
        List<string> EmailList = new List<string> { "admin_num1@mer.ci.nsu.ru", "admin_num2@mer.ci.nsu.ru", "admin_num3@mer.ci.nsu.ru" };
        INotifier Notifier = new Class(EmailList);

        Notifier = new SMS(Notifier);
        Notifier = new Facebook(Notifier);

        Notifier.Send("Сообщение? / /acafaf ");
    }
}