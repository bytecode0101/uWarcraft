using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft
{
   public interface Login
    {
        bool AddUser(List<User> user, string Nume, string password);
        
        
    }
}
