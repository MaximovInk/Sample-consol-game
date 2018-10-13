using System;

namespace ConsoleGame
{
    class Program
    {
        public static bool playing = true;
        public static Level level;
        public static Player player;

        private static void Main(string[] args)
        {
            Sample();
        }

        /// <summary>
        /// Простой пример
        /// </summary>
        private static void Sample()
        {
            level = new Level(20, 20, new Finish(19, 19));
            level.AddObject(new GameObject(5, 5, 3, 3, '|', false));
            level.AddObject(new GameObject(2, 2, 1, 1, false, 'L', ConsoleColor.Magenta, ConsoleColor.Magenta));
            player = new Player(0, 0, ConsoleColor.DarkYellow, ConsoleColor.Yellow, '*');
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
            if (consoleKeyInfo.Key == ConsoleKey.Escape)
            {
                playing = false;
            }
            if (playing)
                Play();
        }
    }
}
