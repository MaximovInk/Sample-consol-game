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
        //Здоровье
        public int health
        {
            get { return _health; }
            set {
                _health = value;
                if (_health <= 0)
                    Program.GameOver();
            }
        }
        private int _health = 1;
        
        public Player(int x , int y) : base(x,y)
        {
            Draw();
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="back_color">Цвет фона</param>
        /// <param name="color">Цвет символа</param>
        /// <param name="symbol">Символ</param>
        public Player(int x, int y, ConsoleColor back_color, ConsoleColor color, char symbol) : this(x, y)
        {
            this.back_color = back_color;
            this.color = color;
            this.symbol = symbol;
            Draw();
        }
        /// <summary>
        /// Нанесение урона
        /// </summary>
        /// <param name="value">Значение</param>
        public void Damage(int value)
        {
            health -= value;
        }
    }
}
