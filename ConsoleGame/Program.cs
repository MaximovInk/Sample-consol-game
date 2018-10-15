using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleGame
{
    class Program
    {
        //Идет игра
        public static bool playing = true;
        //Текущий уровень
        public static Level level;
        //Текущий игрок
        public static Player player;
        //Объект, синхронизирующий передвижение всех объектов
        public static object locker = new object();

        public static float time = 1f;


        private static void Main(string[] args)
        {
            Sample();
            
        }
        /// <summary>
        /// Простой пример
        /// </summary>
        private static void Sample()
        {
            //ScreenBuffer sb = new ScreenBuffer();
            level = new Level(20, 20, new Finish(19, 19));
            level.AddObject(new GameObject(5, 5, 3, 3, '|', false));
            player = new Player(0, 0, ConsoleColor.DarkYellow, ConsoleColor.Yellow, '*');
            level.AddObject(new Enemy(4, 4));
            level.AddObject(new MovedEnemy(4, 4, 0, 200/*, MovedEnemy.MovedType.line*/, new List<Point>() { new Point(1, 5), new Point(5, 5), new Point(5,1), new Point(1,1) }));
            level.AddObject(new GameObject(2, 2, 1, 1, false, 'L', ConsoleColor.Magenta, ConsoleColor.Magenta));           
            Play();
        }
        /// <summary>
        /// Предоставляет управление игроком
        /// </summary>
        public static void Play()
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            if (consoleKeyInfo.KeyChar == 'w')
            {
                player.Move(0, -1);
            }
            if (consoleKeyInfo.KeyChar == 's')
            {
                player.Move(0, 1);
            }
            if (consoleKeyInfo.KeyChar == 'd')
            {
                player.Move(1, 0);
            }
            if (consoleKeyInfo.KeyChar == 'a')
            {
                player.Move(-1, 0);
            }
            if (playing)
            {
                Play();
            }
                
        }
        /// <summary>
        /// Завершение игры
        /// </summary>
        public static void GameOver()
        {
            Environment.Exit(0);
        }
    }
}
