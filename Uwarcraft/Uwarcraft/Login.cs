using System.Collections.Generic;

namespace Uwarcraft
{
    public interface Login
    {
        bool AddUser(List<User> user, string Nume, string password);
        
        
    }
}
