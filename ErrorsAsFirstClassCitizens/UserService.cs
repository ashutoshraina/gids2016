using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorsAsFirstClassCitizens
{

    public class UserService
    {
		readonly List<User> users = new List<User> ();
		public Result<User> GetUserByEmail(string email)
        {
            try
            {
                var user = users.Single(u => string.CompareOrdinal(email, u.Email) == 0);
                return Result.FromResult(user);

            }
            catch (Exception exception)
            {
				Console.WriteLine (exception.Message);
				return Result.FromMessage<User>("We could not find the user");
            }
        }
    }
}
