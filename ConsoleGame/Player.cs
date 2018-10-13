using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    /// <summary>
    /// Игрок
    /// </summary>
    class Player : GameObject
    {
        public Player(int x , int y) : base(x,y)
        {
            Draw();
        }

        public Player(int x, int y, ConsoleColor back_color, ConsoleColor color, char symbol) : this(x, y)
        {
            this.back_color = back_color;
            this.color = color;
            this.symbol = symbol;
            Draw();
        }
    }
}
