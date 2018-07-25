using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
   public interface IBattleArea
    {
         IPosition position { get; set; }
         bool Fire(char height_, int width_);
         bool CheckAvailablePostionForNewShip(IShip ship_);
        bool IsAllShipDamaged();
        bool AddShip(IShip ship_);
    }
}
