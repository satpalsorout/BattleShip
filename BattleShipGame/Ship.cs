using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
 public  class Ship:IShip
    {
  
        public ShipsType ShipType { get; set; }
        public IPosition position { get; set; }
        public List<ICell> lstCells { get; set; }
        /// <summary>
        /// Create a ship with given size and on given position
        /// </summary>
        /// <param name="iHeight_"></param>
        /// <param name="iWidth_"></param>
        /// <param name="position_"></param>
        /// <param name="shipType_"></param>
        public Ship(int iHeight_,int iWidth_, IPosition position_, ShipsType shipType_)
        {
            lstCells = new List<ICell>();
            ShipType = shipType_;
            for (int _iHeight = 0; _iHeight < iHeight_; _iHeight++)
            {
                for (int _iWidth = 0; _iWidth < iWidth_; _iWidth++)
                {
                    Cell _cell = new Cell();
                    _cell.status = StatusType.F;
                    _cell.position.X = (char)((int)position_.X + _iWidth) ;
                    _cell.position.Y = position_.Y+ _iHeight;
                    lstCells.Add(_cell);
                }
            }
        }
        /// <summary>
        ///  To Fire the Missile on the cell of the ship and return the status
        /// </summary>
        /// <param name="X_"></param>
        /// <param name="Y_"></param>
        /// <returns></returns>
        public bool IsFireSuccess(char X_, int Y_)
        {
            ICell _cell = lstCells.Where(x => x.status.Equals(StatusType.F) && x.position.X.Equals(X_) && x.position.Y.Equals(Y_)).FirstOrDefault();
            if (_cell != null)
            {
                _cell.HitCount = _cell.HitCount + 1;
                if (ShipType.Equals(ShipsType.P))
                {
                    _cell.status = StatusType.D;
                }
                else if (_cell.HitCount > 1)
                {
                    _cell.status = StatusType.D;
                }
                return true;
            }

            return false;
        }
        /// <summary>
        /// To Check the ship is completely Damaged or not
        /// </summary>
        /// <returns></returns>
        public bool IsAllCellsDamaged()
        {
            if(lstCells.Where(x => x.status.Equals(StatusType.F)).Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// To Check is Cordinates are matching with cells for ship
        /// </summary>
        /// <param name="X_"></param>
        /// <param name="Y_"></param>
        /// <returns></returns>
        public bool IsShipCellsMatchedWithCordinates(char X_, int Y_)
        {
            if (lstCells.Where(x => x.position.X.Equals(X_) && x.position.Y.Equals(Y_)).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
