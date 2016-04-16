using System;
using System.Threading.Tasks;

namespace ErrorsInAsyncWorld
{
    class Program
    {
        static void Main()
        {
            Task.Run(() => AsyncMain()).Wait();

            Console.ReadLine();
        }

        static async Task AsyncMain()
        {
            var userService = new UserService();
            var result = await userService.GetUserByEmail("foo@bar.com");

            result.OnSuccess(user => Console.WriteLine(user.Email))
                  .OnFailure(() => Console.WriteLine(@"We have a failure"));

        }
    } 
}
