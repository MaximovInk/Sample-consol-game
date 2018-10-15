using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class MovedEnemy : Enemy
    {
        //Поток для передвижения
        public static Thread movement_thread;
        //Задержка передвижения
        public int interval_speed = 2;
        //Точки пути
        public List<Point> WayPoints = new List<Point>();
        //Текущая точка
        public int current_point { get; private set; } = 0;
        
        //public MovedType movedType;
        private readonly EventWaitHandle waitHandle = new AutoResetEvent(false);

        public MovedEnemy(int x ,int y ): base(x,y)
        {
            movement_thread = new Thread(Move);
            movement_thread.Start();
        }

        public MovedEnemy(int x, int y, int damage, int interval_speed/*, MovedType movedType*/, List<Point> points) : this(x,y)
        {
            this.damage = damage;
            this.interval_speed = interval_speed;
            //this.movedType = movedType;
            WayPoints = points;
        }

        public void Move()
        {
            if (current_point >= WayPoints.Count - 1)
            {
                current_point = 0;
            }
            int x = WayPoints[current_point].x - pos_x;
            int y = WayPoints[current_point].x - pos_y;
            if (x > 0)
            {
                while (x > 0)
                {
                    waitHandle.WaitOne(interval_speed);
                    x--;
                    Move(1, 0);
                    waitHandle.Reset();
                }
            }
            else if (x < 0)
            {
                while (x < 0)
                {
                   waitHandle.WaitOne(interval_speed);
                    x++;
                    Move(-1, 0);
                    waitHandle.Reset();
                }
            }
            if (y > 0)
            {
                while (y > 0)
                {
                    waitHandle.WaitOne(interval_speed);
                    y--;
                    Move(0, 1);
                    waitHandle.Reset();
                }
            }
            else if (y < 0)
            {
                while (y < 0)
                {
                    waitHandle.WaitOne(interval_speed);
                    y++;
                    Move(0, -1);
                    waitHandle.Reset();
                }
            }
            current_point++;
            Move();
        }

        /*public enum MovedType
        {
           round, //Start >...> End >...> Start
           line //Start >...> End > Start
        }*/
    }

    public class Point
    {
        public int x = 0;
        public int y = 0;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
