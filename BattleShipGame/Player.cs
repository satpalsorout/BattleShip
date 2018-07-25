using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
   public class Player:IPlayer
    {

        public string Name { get; set; }
        public IBattleArea battleArea { get; set; }
        public List<string> lstMissile { get; set; }
        /// <summary>
        /// Create a Battle Area
        /// </summary>
        /// <param name="iWidth_"></param>
        /// <param name="chHeight_"></param>
        public void CreateBattelArea(int iWidth_, char chHeight_)
        {
            battleArea = new BattleArea(iWidth_, chHeight_);
        }
        /// <summary>
        /// Fire the missile untill miss and having missiles
        /// </summary>
        /// <returns></returns>
        public bool Move()
        {
            bool _bIsMoveSuccess = false;
            string _strPlayerName = string.Empty;
            if (Name == "Player-1")
            {
                _strPlayerName = "Player-2";
            }
            else
            {
                _strPlayerName = "Player-1";
            }
            Console.WriteLine();
            if (lstMissile.Count > 0)
            {
                string _hittingCordinate = String.Empty;
                _hittingCordinate = lstMissile[0];
                char _X = Convert.ToChar(_hittingCordinate.Substring(0, 1));
                int _Y = Convert.ToInt32(_hittingCordinate.Substring(1, _hittingCordinate.Length-1));
                lstMissile.RemoveAt(0);
                _bIsMoveSuccess = battleArea.Fire(_X, _Y);
                Console.Write(_strPlayerName + " fires a missile with target "+ _hittingCordinate);
                if (_bIsMoveSuccess)
                {
                    Console.Write(" which got hit");
                }
                else
                {
                    Console.Write(" which got miss");
                }
                if (_bIsMoveSuccess && !battleArea.IsAllShipDamaged())
                {

                    Move();
                }
            }
            else
            {
                Console.Write(_strPlayerName + " has no more missile to launch");
            }
            return _bIsMoveSuccess;

        }

        public void AddingShips(List<string> lstInput_, int iShipCount_,List<IPlayer> lstPlayers_)
        {
           

            int _iPlayerNumber = 0;
            if (Name == "Player-1")
            {
                _iPlayerNumber = 1;
            }
            else
            {
                _iPlayerNumber = 2;
            }

            for (int _iShipNumber = 0; _iShipNumber < iShipCount_; _iShipNumber++)
            {
                char _chShipType = Convert.ToChar(lstInput_[2 + _iShipNumber].Split(new char[0], StringSplitOptions.RemoveEmptyEntries)[0]);
                IPosition _shipStartCordinatePosition = new Position();
                int _shipHeight = Convert.ToInt32(lstInput_[2 + _iShipNumber].Split(new char[0], StringSplitOptions.RemoveEmptyEntries)[1]);
                int _shipWidth = Convert.ToInt32(lstInput_[2 + _iShipNumber].Split(new char[0], StringSplitOptions.RemoveEmptyEntries)[2]);
                string _shipStartingCordinate = lstInput_[2 + _iShipNumber].Split(new char[0], StringSplitOptions.RemoveEmptyEntries)[2 + _iPlayerNumber];
                _shipStartCordinatePosition.X = Convert.ToChar(_shipStartingCordinate.Substring(0, 1));
                _shipStartCordinatePosition.Y = Convert.ToInt32(_shipStartingCordinate.Substring(1, _shipStartingCordinate.Length - 1));
                ShipsType _shipType = _chShipType == 'Q' ? ShipsType.Q : ShipsType.P;
                IShip _ship = new Ship(_shipHeight, _shipWidth, _shipStartCordinatePosition, _shipType);
                
                if (lstPlayers_.Where(x => x.battleArea.CheckAvailablePostionForNewShip(_ship)).Count() > 1)      
                {

                    battleArea.AddShip(_ship);
                }
                else
                {
                    Console.WriteLine("Ship Already added on same position");

                }

            }
        }
    }
}
