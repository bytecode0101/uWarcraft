namespace Uwarcraft.Buildings.Interfaces
{
    public abstract class AbstractBuilding: IBuilding
    {
        public int Life { get; protected set; }
        public int Cost { get; protected set; }


        public virtual void TakeHit(int hitPower)
        {
            Life -= hitPower;
        }
    }
}
