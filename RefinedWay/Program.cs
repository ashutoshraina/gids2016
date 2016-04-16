using System;

namespace RefinedWay
{
    class Program
    {
        static void Main(string[] args)
        {
            //var user = new User { Ip = "10.12.3.4", Message = "bad" };
            //var firstResult = ChatBotValidator.IsUsingBannedWords(user);
            //firstResult.Select(r => r);
            
            RefinedValidator();

            Console.ReadLine();
        }

        static void RefinedValidator()
        {
            new CustomerService(new CustomerRepository()).Delete(-1);
        }
    }
}
