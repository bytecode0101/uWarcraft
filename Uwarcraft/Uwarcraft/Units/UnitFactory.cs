namespace Uwarcraft.Units
{
    public class UnitFactory
    {
        public IUnit Train(string type, Game.Point coords)
        {
            IUnit unit = null;
            switch (type)
            {
                case ("Peasant"):
                    {
                        unit = new Peasant(coords);
                        break;
                    }
                case ("Archer"):
                    {
                        unit = new Archer(coords);
                        break;
                    }
                //case ("Clubman"):
                //    {
                //        building = new BowWorkshop(coords);
                //        break;
                //    }
                //case ("SwordFighter"):
                //    {
                //        building = new Tower(coords);
                //        break;
                //    }
                default:
                    break;
            }
            return unit;
        }
    }
}