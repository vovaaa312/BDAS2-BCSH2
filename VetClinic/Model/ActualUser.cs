using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    public static class ActualUser
    {
        private static User user = null;

        public static void SetUser(User u) {
            user = u;
        }

        public static User GetUser() 
        { 
            return user; 
        }
    }
}
