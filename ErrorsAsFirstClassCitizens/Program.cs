using System;

namespace ErrorsAsFirstClassCitizens
{
    class Program
    {
        static void Main()
        {
            var userService = new UserService();
            var result = userService.GetUserByEmail("foo@bar.com");
            
            result.OnSuccess(user => Console.WriteLine(user.Email))
                  .OnFailure(() => Console.WriteLine(@"We have a failure"));


            Console.ReadLine();
        }
    }
}
