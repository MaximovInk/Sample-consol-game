using System;

namespace ConsoleGame
{
    /// <summary>
    /// Игровой объект
    /// </summary>
    class GameObject
    {
        //Позиция по x и y
        public int pos_x;
        public int pos_y;
        //Объект может контактировать
        public bool can_contact = true;
        //Длина
        public int width = 1;
        //Высота
        public int height = 1;
        //Символ
        public char symbol = '1';
        //Цвет символа
        public ConsoleColor color;
        //Фон объекта
        public ConsoleColor back_color;
        /// <summary>
        /// Констуктор
        /// </summary>
        /// <param name="x">Начальная позиция x</param>
        /// <param name="y">Начальная позиция y</param>
        public GameObject(int x ,int y)
        {
            pos_x = x;
            pos_y = y;
            color = ConsoleColor.White;
            Draw();
        }
        /// <summary>
        /// Констуктор
        /// </summary>
        /// <param name="x">Начальная позиция x</param>
        /// <param name="y">Начальная позиция y</param>
        /// <param name="width">Длина</param>
        /// <param name="height">Высота</param>
        public GameObject(int x, int y, int width, int height) : this(x,y)
        {
            this.width = width;
            this.height = height;
            Draw();
        }
        /// <summary>
        /// Констуктор
        /// </summary>
        /// <param name="x">Начальная позиция x</param>
        /// <param name="y">Начальная позиция y</param>
        /// <param name="width">Длина</param>
        /// <param name="height">Высота</param>
        /// <param name="can_contact">Объект может контактировать</param>
        /// <param name="symbol">Символ</param>
        public GameObject(int x, int y, int width, int height, char symbol, bool can_contact) : this(x, y, width,height)
        {
            this.symbol = symbol;
            this.can_contact = can_contact;
            Draw();
        }
        /// <summary>
        /// Констуктор
        /// </summary>
        /// <param name="x">Начальная позиция x</param>
        /// <param name="y">Начальная позиция y</param>
        /// <param name="width">Длина</param>
        /// <param name="height">Высота</param>
        /// <param name="can_contact">Объект может контактировать</param>
        /// <param name="symbol">Символ</param>
        /// <param name="f_color">Цвет символа</param>
        /// <param name="b_color">Фон объекта</param>
        public GameObject(int x, int y, int width, int height, bool can_contact, char symbol, ConsoleColor f_color, ConsoleColor b_color) : this(x, y, width,height, symbol,can_contact)
        {
            color = f_color;
            back_color = b_color;
            Draw();
        }
        /// <summary>
        /// Отобразить
        /// </summary>
        public void Draw()
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    Console.SetCursorPosition(pos_x + w, pos_y + h);
                    Console.ForegroundColor = color;
                    Console.BackgroundColor = back_color;
                    Console.Write(symbol);
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(0, 0);
        }
        /// <summary>
        /// Подвинуть на x по оси x и на y по оси y
        /// </summary>
        public void Move(int x, int y)
        {
            //Если объект передвигается вправо
            if (x > 0)
            {
                if (pos_x + width + x > Program.level.Width)
                    return;
            }
            //Если объект передвигается влево
            else if (x < 0)
            {
                if (pos_x + x < 0)
                    return;
            }
            //Если объект передвигается вниз
            if (y > 0)
            {
                if (pos_y + height + y > Program.level.Height)
                    return;
            }
            //Если объект передвигается вверх
            else if (y < 0)
            {
                if (pos_y + y < 0)
                    return;
            }
            //Если в конечные координаты нельзя двигаться
            if (Program.level.Can_move(pos_x, pos_y, x , y,width,height) == false)
            {
                return;
            }
            //Перерисовать игрока
            Console.SetCursorPosition(pos_x, pos_y);
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    Console.SetCursorPosition(pos_x + w, pos_y + h);
                    Console.Write(" ");
                }
            }
            pos_x += x;
            pos_y += y;
            Draw();
            Program.level.Redraw();
        }
    }
}
