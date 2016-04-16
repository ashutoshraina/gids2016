using System;
using System.Collections.Generic;
using System.Linq;

namespace MotivationExample
{
	public class UserService
    {
		readonly List<User> users = new List<User> ();
		public User GetUserByEmail(string email)
        {
            try
            {
                return users.Single(user => string.CompareOrdinal(email, user.Email) == 0);

            }
            catch (Exception exception)
            {
				Console.WriteLine (exception.Message);
				return null;
            }
        }
    }   
}
