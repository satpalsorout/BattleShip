using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
   public class Cell : ICell
    {
        public IPosition position { get; set; }
        public StatusType status { get; set; }
        public int HitCount { get; set; }
        public Cell()
        {
            position = new Position();
        }
    }
}
