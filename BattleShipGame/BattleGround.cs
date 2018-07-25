using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
   public class BattleGround
    {
        string strInputText { get; set; }
        List<string> lstInputs { get; set; }
        List<IPlayer> lstPlayers { get; set; }
        /// <summary>
        /// Play the game First chance on Player-1 and untill hitting and have missile if missed replace the players
        /// </summary>
        /// <param name="player1_"></param>
        /// <param name="player2_"></param>
        public void Play(IPlayer player1_, IPlayer player2_)
        {
           if(player1_.lstMissile.Count()<1 && player2_.lstMissile.Count<1) //Quit if nomissiles available for both players
            {
                return;
            }
            if (player2_.Move())
            {
                if (player2_.battleArea.IsAllShipDamaged())
                {
                    Console.WriteLine();
                    Console.WriteLine(player1_.Name + " won the battle");
                    return;
                }
                else
                {
                    Play(player2_, player1_);//reverse the players
                }
            }
            else
            {
                Play(player2_, player1_);//reverse the players
            }

        }
     
        /// <summary>
        /// Reading the input file from application bin
        /// </summary>
        public void ReadInput()
        {
            try
            {
                strInputText = System.IO.File.ReadAllText("./input.txt");//readin input file
                if(!string.IsNullOrEmpty(strInputText))
                lstInputs = strInputText.Split('\n').ToList();//Sperating the string for every new line
            }
            catch(Exception ex)
            {
                Console.WriteLine("Input file Error "+ ex.Message);
            }
        }
        /// <summary>
        /// Start the Game
        /// </summary>
        public void StartGame()
        {
            try
            {
                ReadInput();
                IPlayer iPlayer1 = new Player();
                IPlayer iPlayer2 = new Player();
                lstPlayers = new List<IPlayer>();
                lstPlayers.Add(iPlayer1);
                lstPlayers.Add(iPlayer2);
                int _iWidth = Convert.ToInt32(lstInputs[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries)[0]);//Reading from first line first element
                char _chHeight = Convert.ToChar(lstInputs[0].Split(new char[0], StringSplitOptions.RemoveEmptyEntries)[1]);//Reading from first line seccond element onwards
                iPlayer1.Name = "Player-1";
                iPlayer2.Name = "Player-2";
                iPlayer1.CreateBattelArea(_iWidth, _chHeight);
                iPlayer2.CreateBattelArea(_iWidth, _chHeight);
                int _iShipCount = Convert.ToInt32(lstInputs[1]);//Reading Second line from input file as number of ships 
                iPlayer1.AddingShips(lstInputs, _iShipCount, lstPlayers);
                iPlayer2.AddingShips(lstInputs, _iShipCount, lstPlayers);
                iPlayer1.lstMissile = lstInputs[2 + _iShipCount + 1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();//reading post number of ships as missiles and assigning to oposite players
                iPlayer2.lstMissile = lstInputs[2 + _iShipCount].Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();//reading post number of ships as missiles and assigning to oposite players
                Play(iPlayer1, iPlayer2);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : "+ ex.Message);
            }

    }
    }
}
