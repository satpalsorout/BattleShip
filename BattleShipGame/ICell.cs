using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    public enum StatusType
    {
        D, //Demaged
        E, //Empty
        F //Filled
       
    }
    public interface ICell
    {
        int HitCount { get; set; }
        IPosition position { get; set; }
       StatusType status { get; set; }

    }
}
