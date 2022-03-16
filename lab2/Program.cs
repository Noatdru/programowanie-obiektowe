using System;

namespace lab2
{
    abstract class AbstractMessage
    {
        public string Content { get; init; }
        abstract public void Send();
    }

    class EmailMessage : AbstractMessage
    {
        public string To { get; init; }

        public string From { get; init; }

        public string Subject { get; init; }
        public override void Send()
        {
            Console.WriteLine($"Sending email from {From} with content {Content}"); ;

        }
    }
    class SmsMessage : AbstractMessage
    {
        public string PhoneNumber { get; init; }
        public override void Send()
        {
            Console.WriteLine($"Sending Sms to {PhoneNumber} with content {Content}"); ;
        }

    }
    class MessangerMessage : AbstractMessage
    {
        public override void Send()
        {
            Console.WriteLine($"Sending messanger ");
        }
    }
    interface IFly
    {
        void Fly();
    }
     interface IAggregate()
        {
        IIterator create IIterator
    
    class Program
    {
        static void Main(string[] args)
        {
            string messageType = "email";
            switch (messageType)
            {
                case "email":
                    Console.WriteLine("Wysyłanie emaila");
                    break;
                case "sms":
                    Console.WriteLine("Wysyłanie sms");
                    break;
                case "messanger":
                    Console.WriteLine("Wysyłanie powiadomienia");
                    break;
            }
            AbstractMessage[] messages = new AbstractMessage[3];
            messages[0] = new EmailMessage() { Content = "Hello", From = "adam@op.pl", To = "", Subject = "" };
            messages[1] = new SmsMessage() { Content = "Hello from SMS", PhoneNumber = "123123123"};
            messages[2] = new EmailMessage() { Content = "Cze sc", From = "adam@op.pl", To = "", Subject = "" };
            messages[3] = new MessangerMessage() { Content = "Czesc"};
            int mailCounter = 0;
            foreach(var message in messages)
            {
                message.Send();
                //1
              //  if (message is EmailMessage)
               // {
               //     mailCounter++;
              //  }
                //2
                EmailMessage email = message as EmailMessage;
                mailCounter += email == null ? 0 : 1;
            }
            Console.WriteLine($"Liczba wysłanych emaili: {mailCounter}");
            IFly[] flyingObjects = iFly[3];
            flyingObjects[0] new Duck ;
            flyingObjects[] new Hydroplane() ;














































































































        }
    }
}
