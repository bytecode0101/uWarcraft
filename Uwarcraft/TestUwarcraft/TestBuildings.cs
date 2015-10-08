using NUnit.Framework;
using Uwarcraft.Buildings;
using Uwarcraft.Buildings.BasicBuildings;

namespace TestUwarcraft
{
    [TestFixture]
    public class TestBuildings
    {
        [Test]
        public void TestFarm()
        {
            IBuilding farm = new Farm();
        }
    }
}
