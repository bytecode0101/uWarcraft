namespace Uwarcraft.Units
{
    public abstract class BaseUnit
    {
        public int unitCost { get; set; }
        public int unitHealth { get; set; }
        public int unitSpeed { get; set; }
        public int unitDamageSuffered { get; set; }
        public int unitAttackPower { get; set; }
        public int position { get; set; }

        public void attack()
        {
            throw new System.NotImplementedException();
        }

        public void dismiss()
        {
            throw new System.NotImplementedException();
        }

        public void guard()
        {
            throw new System.NotImplementedException();
        }

        public void move()
        {
            throw new System.NotImplementedException();
        }

        public void stop()
        {
            throw new System.NotImplementedException();
        }
    }
}