using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
   public class BattleArea:IBattleArea
    {
        public IPosition position { get; set; }
        public List<ICell> lstCells { get; set; }
        public List<IShip> lstShips { get; set; }  

        /// <summary>
        /// Create a battle Area to play
        /// </summary>
        /// <param name="iWidth_"></param>
        /// <param name="chHeight_"></param>
        public BattleArea(int iWidth_, char chHeight_)
        {
            lstCells = new List<ICell>();
            lstShips = new List<IShip>();
            position = new Position();
            position.Y = iWidth_;
            position.X = chHeight_;

            for (int y = 1; y <= position.Y; y++)
            {

                for (Char x = 'A'; x <= position.X; x++)
                {
                    Cell cell = new Cell();
                    cell.position.X = x;
                    cell.position.Y = y;
                    cell.status = StatusType.E;
                    lstCells.Add(cell);
                }
            }
        }
        /// <summary>
        /// Print area to watch the ship allocated positions
        /// </summary>
        public void PrintBattleArea()
        {
            Console.WriteLine();

            for (Char x = 'A'; x <= position.X; x++)
                {
                for (int y = 1; y <= position.Y; y++)
                {
                    Console.Write(lstCells.Where(C=>C.position.X.Equals(x) && C.position.Y.Equals(y)).FirstOrDefault().status);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Get Ship object by the position
        /// </summary>
        /// <param name="X_"></param>
        /// <param name="Y_"></param>
        /// <returns></returns>
        public IShip GetShipForCordinates(char X_, int Y_)
        {
            IShip _ship = null;
            foreach (IShip ship in lstShips)
            {
                if(ship.IsShipCellsMatchedWithCordinates(X_, Y_))
                {
                    _ship = ship;
                    break;
                }
            }
            return _ship;
        }
        /// <summary>
        /// To Fire the Missile on the given positions if any ship is availabe
        /// </summary>
        /// <param name="X_"></param>
        /// <param name="Y_"></param>
        /// <returns></returns>
        public bool Fire(char X_, int Y_)
        {
            bool bIsSucces = false;
            IShip _ship= GetShipForCordinates(X_, Y_);
            if(_ship!=null)
            {
                bIsSucces = _ship.IsFireSuccess(X_, Y_);
               
            }
            return bIsSucces;
        }
      
        /// <summary>
        /// To Check the all ship are damaged or not
        /// </summary>
        /// <returns></returns>
       public bool IsAllShipDamaged()
        {
            foreach (IShip _ship in lstShips)
            {
                if(!_ship.IsAllCellsDamaged())
                {
                    return false;
                }

            }
            return true;
        }
        /// <summary>
        /// To Check the Empty Cells are availabe or not for new ship
        /// </summary>
        /// <param name="ship_"></param>
        /// <returns></returns>
        public bool CheckAvailablePostionForNewShip(IShip ship_)
        {
            bool _bIsPositionAvailable = false;
           foreach(ICell _cell in ship_.lstCells)
            {
                int _iCountAvailableCells = 0;
                _iCountAvailableCells = lstCells.Where(x => x.status.Equals(StatusType.E) && x.position.X == _cell.position.X && x.position.Y == _cell.position.Y).Count();
                if (_iCountAvailableCells == 1)
                {
                    _bIsPositionAvailable = true;
                }
                else
                {
                    _bIsPositionAvailable = false;
                }

            }
            return _bIsPositionAvailable;

        }
        /// <summary>
        /// Setting the status as Fiiled on The BattleArea for new allocated ship
        /// </summary>
        /// <param name="ship_"></param>
        public void SetBattleAreaCellsForShip(IShip ship_)
        {
            foreach(ICell _shipCell in ship_.lstCells)
            {
                ICell battleCell = lstCells.Where(x => x.status.Equals(StatusType.E) && x.position.X == _shipCell.position.X && x.position.Y == _shipCell.position.Y).FirstOrDefault();
                if(battleCell!=null)
                {
                    battleCell.status = StatusType.F;
                }
            }
        }
        /// <summary>
        /// Adding a new and return the staus 
        /// </summary>
        /// <param name="ship_"></param>
        /// <returns></returns>
        public bool AddShip(IShip ship_)
        {
            
            if (CheckAvailablePostionForNewShip(ship_))
            {
                lstShips.Add(ship_);
                SetBattleAreaCellsForShip(ship_);
                //PrintBattleArea();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
