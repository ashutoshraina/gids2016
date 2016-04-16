using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorsInAsyncWorld
{

    public class UserService
    {
        readonly List<User> users = new List<User>();
        public async Task<Result<User>> GetUserByEmail(string email)
        {
            try
            {
            //Looks happy but could have been really sad
                var user = users.Single(u => string.CompareOrdinal(email, u.Email) == 0);
                var promise = new TaskCompletionSource<Result<User>>();
                promise.SetResult(Result.FromResult(user));
                return await promise.Task;

// Fake Happy Path
                //var user = new User { Email = "something@foo.com" };
                //var promise = new TaskCompletionSource<Result<User>>();
                //promise.SetResult(Result.FromResult(user));
                //return await promise.Task;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                var promise = new TaskCompletionSource<Result<User>>();
                promise.SetResult(Result.FromMessage<User>("We could not find the user"));
                return await promise.Task;
            }
        }
    }
}
