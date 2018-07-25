using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
   public interface IPlayer
    {
        string Name { get; set; }
        IBattleArea battleArea { get; set; }
        List<string> lstMissile { get; set; }
        bool Move();
         void CreateBattelArea(int width_, char height_);
        void AddingShips(List<string> lstInput_, int iShipCount_, List<IPlayer> lstPlayers_);
    }
}
