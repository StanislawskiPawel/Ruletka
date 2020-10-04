using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Player
    {

        private string _name = "we";
        private int _money = 0;

        public string Name
        {
            get => _name;
            set
            {

                if (value != string.Empty)
                {
                    _name = value;
                }

                else
                {
                    throw new ArgumentException("_name cannot be null", "original");
                }

            }
        }

        public int Money
        {
            get => _money;
            set
            {
                if (value >= 0)
                {
                    _money = value;
                }

                else
                {
                    throw new ArgumentException("_money cannot be non positive", "original");
                }

            }
        }


        public Player() { }

        public Player(string playerName, int playerMoney)
        {
            Money = playerMoney;
            Name = playerName;
        }

    }
}
