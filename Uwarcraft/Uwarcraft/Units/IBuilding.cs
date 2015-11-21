using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Uwarcraft.Units
{
    public interface IBuilding : IBuildable
    {
        void StartBuilding();
    }
}
