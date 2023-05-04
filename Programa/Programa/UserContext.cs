using System.Collections.Generic;

namespace Program
{
    public class UserContext
    {
        public Dictionary<string, string> UserData { get; set; }

        public UserContext()
        {
            UserData = new Dictionary<string, string>();
        }
    }
}
