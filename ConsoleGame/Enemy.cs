namespace ConsoleGame
{
    class Enemy : GameObject
    {
        //Урон за 10 мс
        public int damage = 1;
        
        public Enemy(int x,int y) : base(x ,y)
        {

        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="damage">Урон</param>
        public Enemy(int x, int y, int damage) : this(x, y)
        {
            this.damage = damage;
        }
    }
}
