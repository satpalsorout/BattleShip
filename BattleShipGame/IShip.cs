using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    public enum ShipsType
    {
        Q,
        P
    }

    public interface IShip
    {

        ShipsType ShipType { get;set; }
        IPosition position { get; set; }
        List<ICell> lstCells { get; set; }
        bool IsFireSuccess(char chHeight_, int iWidth_);
        bool IsAllCellsDamaged();
        bool IsShipCellsMatchedWithCordinates(char chHeight_, int iWidth_);
    }
}
