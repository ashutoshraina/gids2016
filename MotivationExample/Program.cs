using System;
namespace MotivationExample
{
    class Program
    {
        static void Main()
        {
            // DataCanBeCorrupt();
            ExceptionIsLegit();
            Console.ReadKey();
        }

        private static void DataCanBeCorrupt()
        {
            var userService = new UserService();
            var result = userService.GetUserByEmail("foo@bar.com");
            Console.WriteLine(result);
        }

        static void ExceptionIsLegit()
        {
            var connection = ConnectionFactory.GetConnection("random");
        }
    }
}
