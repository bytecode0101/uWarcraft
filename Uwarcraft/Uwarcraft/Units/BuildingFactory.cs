namespace Uwarcraft.Units
{
    public class BuildingFactory
    {
        public AbstractBuilding Build(string type, Game.Point coords)
        {
            AbstractBuilding building = null;
            switch (type)
            {
                case ("Farm"):
                    {
                        building = new Farm(coords);
                        break;
                    }
                case ("Barrack"):
                    {
                        building = new Barrack(coords);
                        break;
                    }
                case ("BowWorkshop"):
                    {
                        building = new BowWorkshop(coords);
                        break;
                    }
                case ("Tower"):
                    {
                        building = new Tower(coords);
                        break;
                    }
                default:
                    break;
            }
            return building;
        }
    }
}
