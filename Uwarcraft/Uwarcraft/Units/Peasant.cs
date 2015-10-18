﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uwarcraft.Units
{
    public class Peasant : Units.IUnit
    {
        public int unitCost { get; set; }
        public int unitHealth { get; set; }
        public int unitSpeed { get; set; }
        public int unitDamageSuffered { get; set; }
        public int unitAttackPower { get; set; }
        public Game.Point position { get; set; }

        public Peasant (Game.Point xy)
        {
            position = xy;
            unitHealth = 20;
            unitSpeed = 1;
            unitAttackPower = 1;
        }

        public void Attack(IUnit target)
        {
            target.TakeHit(unitAttackPower);
        }

        public void Attack(AbstractBuilding target)
        {
            target.TakeHit(unitAttackPower);
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void TakeHit(int attackPower)
        {
            unitDamageSuffered += attackPower;
        }
    }
}