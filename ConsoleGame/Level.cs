using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ConsoleGame
{
    /// <summary>
    /// Уровень
    /// </summary>
    class Level
    {
        //Индксы листа структурой
        public int[,] structure;
        //Список статичных объектов
        public List<GameObject> gameObjects = new List<GameObject>();
        //Список объектов без коллизии
        public List<int> redraw = new List<int>();
        //Враги
        private List<Enemy> enemies = new List<Enemy>();
        //Поток для врагов
        public static Thread enemies_thread;

        /// <summary>
        /// Получить высоту уровня
        /// </summary>
        public int Width { get { return structure.GetLength(0); } }
        /// <summary>
        /// Получить длину уровня
        /// </summary>
        public int Height { get { return structure.GetLength(1); } }
        /// <summary>
        /// Констурктор нового уровня
        /// </summary>
        /// <param name="width">Длина</param>
        /// <param name="height">Высота</param>
        public Level(int width, int height)
        {
            structure = new int[width, height];
            enemies_thread = new Thread(Enemies);
            enemies_thread.Start();
        }
        /// <summary>
        /// Констурктор нового уровня
        /// </summary>
        /// <param name="width">Длина</param>
        /// <param name="height">Высота</param>
        /// <param name="finish">Объект финиша</param>
        public Level(int width, int height, Finish finish) : this(width, height)
        {
            AddObject(finish);
        }
        /// <summary>
        /// Добавить статичный объект
        /// </summary>
        public void AddObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            GenerateStructure();
            if (gameObject.can_contact)
            {
                redraw.Add(gameObjects.Count - 1);
            }
            if (gameObject is Enemy)
                enemies.Add(gameObject as Enemy);
        }
        /// <summary>
        /// Генерация структуры объектов
        /// </summary>
        public void GenerateStructure()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int w = 0; w < gameObjects[i].width; w++)
                {
                    for (int h = 0; h < gameObjects[i].height; h++)
                    {
                        structure[gameObjects[i].position.y + w, gameObjects[i].position.y + h] = i;
                    }
                }
            }
        }
        /// <summary>
        /// Перерисовать проходимые объекты
        /// </summary>
        public void Redraw()
        {
            for (int i = 0; i < redraw.Count; i++)
            {
                gameObjects[redraw[i]].Draw();
            }
            Program.player.Draw();
        }
        /// <summary>
        /// Можно ли переместить объект в координаты
        /// </summary>
        /// <param name="x">Начальная координата x</param>
        /// <param name="y">Начальная координата y</param>
        /// <param name="x1">Движение по оси x</param>
        /// <param name="y1">Движение по оси y</param>
        /// <param name="w">Высота объекта</param>
        /// <param name="h">Ширина объекта</param>
        /// <returns></returns>
        public bool Can_move(int x, int y, int x1, int y1, int w, int h)
        {
            //Получаем направление движения
            int x_direction = Math.Sign(x1);
            int y_direction = Math.Sign(y1);


            for (int w1 = 0; w1 < w; w1++)
            {
                for (int h1 = 0; h1 < h; h1++)
                {
                    //Получаем информацию о конечных координатах
                    if (gameObjects[structure[x + (w * x_direction), y + (h * y_direction)]].can_contact == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// Поток для атаки врагов
        /// </summary>
        void Enemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].position.x == Program.player.position.x && enemies[i].position.y == Program.player.position.y)
                {
                    Program.player.Damage(enemies[i].damage);
                }
            }
            Thread.Sleep(10);
            Enemies();
        }
    }
}