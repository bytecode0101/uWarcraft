﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwarcraft.Units
{
    public interface IUnit
    {
         int unitCost { get; set; }
         int unitHealth { get; set; }
         int unitSpeed { get; set; }
         int unitDamageSuffered { get; set; }
         int unitAttackPower { get; set; }
         Game.Point position { get; set; }

        void Attack(IUnit target);
        void Attack(AbstractBuilding target);
        void Move();
        void Stop();
        void TakeHit(int attackPower);
    }
}
